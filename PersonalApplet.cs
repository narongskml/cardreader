using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*********************
*  Credit from https://github.com/somprasongd/thai-smartcard-nodejs
*  Convert to C# using chatGPT4
**********************/
namespace PersonalApplet
{
    public class PersonalApplet
    {
        private Card card;
        private Request req;

        public PersonalApplet(Card card)
        {
            this.card = card;
            this.req = new Request();
        }

        public async Task<Dictionary<string, dynamic>> GetPersonalInfo(Dictionary<string, bool> q)
        {
            var info = new Dictionary<string, dynamic>();
            byte[] data;

            foreach (var item in q)
            {
                if (item.Value)
                {
                    string cmd = GetCommand(item.Key);
                    data = await reader.GetData(this.card, cmd, this.req);

                    if (item.Key == "dob" || item.Key == "issueDate" || item.Key == "expireDate")
                    {
                        info[item.Key] = ParseDateData(data);
                    }
                    else if (item.Key == "photo")
                    {
                        info[item.Key] = GetPhotoData(data);
                    }
                    else
                    {
                        info[item.Key] = Encoding.GetEncoding(874).GetString(data.Take(data.Length - 2).ToArray());
                    }
                }
            }

            return info;
        }

        private string GetCommand(string key)
        {
            switch (key)
            {
                case "firstName":
                    return apduPerson.CMD_FIRSTNAME;
                case "lastName":
                    return apduPerson.CMD_LASTNAME;
                case "dob":
                    return apduPerson.CMD_DOB;
                case "gender":
                    return apduPerson.CMD_GENDER;
                case "issuer":
                    return apduPerson.CMD_ISSUER;
                case "issueDate":
                    return apduPerson.CMD_ISSUE;
                case "expireDate":
                    return apduPerson.CMD_EXPIRE;
                case "address":
                    return apduPerson.CMD_ADDR;
                case "photo":
                    return apduPerson.CMD_PHOTO1;
                default:
                    throw new Exception("Invalid key");
            }
        }

        private string ParseDateData(byte[] data)
        {
            string dateString = Encoding.UTF8.GetString(data.Take(data.Length - 2).ToArray());
            int year = int.Parse(dateString.Substring(0, 4)) - 543;
            string formattedDate = $"{year}-{dateString.Substring(4, 2)}-{dateString.Substring(6)}";
            return formattedDate;
        }

        private string GetPhotoData(byte[] data)
        {
            string photo = "";
            string hexString = BitConverter.ToString(data.Take(data.Length - 4).ToArray()).Replace("-", "");

            for (int i = 0; i < hexString.Length; i += 2)
            {
                photo += hexString.Substring(i, 2);
            }

            return photo;
        }
    }
}
