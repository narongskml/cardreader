

namespace ThaiCardIDReader
{
    public class PersonalInfo
    {
        private string _personal;
        private string _address;
        private string _issue_expire;
        private string _issuer;
        private string[] _th_personal;
        private string[] _en_personal;
        private byte[] _photo_jpeg;
        private string _photo_base64;

        public string Citizenid { get; set; }

        public string PhotoBase64
        {
            get
            {
                return _photo_base64;
            }
            set
            {
                _photo_base64 = value;
            }
        }

        public byte[] PhotoRaw
        {
            get
            {
                return _photo_jpeg;
            }
            set
            {
                _photo_jpeg = value;
            }
        }


        public string Info
        {
            set
            {
                _personal = value;
                _th_personal = _personal.Substring(0, 100).Split('#');
                _en_personal = _personal.Substring(100, 100).Split('#');
            }
        }

        public string Address
        {
            set
            {
                _address = value.Trim();
            }
            get
            {
                return _address.Replace('#', ' ');
            }
        }

        public string addrHouseNo
        {
            get
            {
                return _address.Split('#')[0].Trim();
            }
        }


        public string addrVillageNo
        {
            get
            {
                return _address.Split('#')[1].Trim();
            }
        }


        public string addrLane
        {
            get
            {
                return _address.Split('#')[2].Trim();
            }
        }

        public string addrRoad
        {
            get
            {
                return _address.Split('#')[3].Trim();
            }
        }

        public string addrTambol
        {
            get
            {
                return _address.Split('#')[5].Trim();
            }
        }

        public string addrAmphur
        {
            get
            {
                return _address.Split('#')[6].Trim();
            }
        }

        public string addrProvince
        {
            get
            {
                return _address.Split('#')[7].Trim();
            }
        }

        public string Issue_Expire
        {
            set
            {
                _issue_expire = value;
            }
        }

        public DateTime Issue
        {
            get
            {
                return new DateTime(
                    Convert.ToInt32(_issue_expire.Substring(0, 4)) - 543,
                    Convert.ToInt32(_issue_expire.Substring(4, 2)),
                    Convert.ToInt32(_issue_expire.Substring(6, 2))
                    );
            }
        }

        public DateTime Expire
        {
            get
            {
                var year = Convert.ToInt32(_issue_expire.Substring(8, 4)) - 543;
                var month = Convert.ToInt32(_issue_expire.Substring(12, 2));
                var day = Convert.ToInt32(_issue_expire.Substring(14, 2));

                return new DateTime(year, month > 12 ? 12 : month, day > 31 ? 31 : day);
            }
        }

        public string ExpireString
        {
            get
            {
                return Expire.ToString("yyyyMMdd");
            }
        }

        public DateTime Birthday
        {
            get
            {
                var dateNow = DateTime.Now;
                int year, month, day;
                year = Convert.ToInt32(_personal.Substring(200, 4));
                year = year > 0 ? year - 543 : dateNow.Year;
                month = Convert.ToInt32(_personal.Substring(204, 2));
                month = month > 0 ? month : 1;
                day = Convert.ToInt32(_personal.Substring(206, 2));
                day = day > 0 ? day : 1;

                return new DateTime(year, month, day);
            }
        }

        public string BirthdayYearString
        {
            get
            {
                return (Convert.ToInt32(_personal.Substring(200, 4)) - 543).ToString();
            }
        }

        public string Sex
        {
            get
            {
                return _personal.Substring(208, 1);
            }
        }

        public string Th_Prefix
        {
            get
            {
                return _th_personal[0].Trim();
            }
        }

        public string Th_Firstname
        {
            get
            {
                return _th_personal[1].Trim();
            }
        }

        public string Th_Middlename
        {
            get
            {
                return _th_personal[2].Trim();
            }
        }

        public string Th_Lastname
        {
            get
            {
                return _th_personal[3].Trim();
            }
        }

        public string En_Prefix
        {
            get
            {
                return _en_personal[0].Trim();
            }
        }

        public string En_Firstname
        {
            get
            {
                return _en_personal[1].Trim();
            }
        }
        public string En_Middlename
        {
            get
            {
                return _en_personal[2].Trim();
            }
        }

        public string En_Lastname
        {
            get
            {
                return _en_personal[3].Trim();
            }
        }

        public string Issuer
        {
            get
            {
                return _issuer;
            }
            set
            {
                _issuer = value;
            }
        }


    }
}
