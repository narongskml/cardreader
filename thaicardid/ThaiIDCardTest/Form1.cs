using ThaiCardIDReader;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
namespace ThaiIDCardTest
{

    public partial class Form1 : Form
    {

        ThaiIDCardReader idcard;
        bool _ismonitor = false;
        public Form1()
        {
            InitializeComponent();

        }
        public void LogLine(string text = "")
        {
            if (txtdata.InvokeRequired)
            {
                txtdata.BeginInvoke(new MethodInvoker(delegate { txtdata.AppendText(text + Environment.NewLine); }));
            }
            else
            {
                txtdata.AppendText(text + Environment.NewLine);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            idcard = new ThaiIDCardReader();
    
            idcard.eventCardRemoved += Idcard_eventCardRemoved;
            idcard.eventCardInsertedWithPhoto += Idcard_eventCardInsertedWithPhoto;

            lblLibVersion.Text = idcard.Version();
            btRefreshReader_Click(sender, e);

            if (cmbReader.Items.Count > 0)
            {
                if (cmbReader.Items[0].ToString() != "")
                    StartMonitor(cmbReader.Items[0].ToString());
            }
        }
        private void StartMonitor(string readerName)
        {
            idcard.MonitorStart(readerName);
            _ismonitor = true;
            idcard.eventCardInsertedWithPhoto += new handleCardInserted(Idcard_eventCardInserted);
            idcard.eventPhotoProgress += new handlePhotoProgress(photoProgress);

        }
        private void photoProgress(int value, int maximum)
        {

        }
        private void Idcard_eventCardInsertedWithPhoto(PersonalInfo PersonalInfo)
        {
            Debug.Print("Event CardInsert with Photo");
            if (PersonalInfo == null)
            {
                if (idcard.ErrorCode() > 0)
                {
                    MessageBox.Show(idcard.Error());
                }
                return;
            }
            if (PersonalInfo != null)
            {
                LogLine(PersonalInfo.Citizenid);
                LogLine(PersonalInfo.Birthday.ToString("dd/MM/yyyy"));
                LogLine(PersonalInfo.Sex);
                LogLine(PersonalInfo.Th_Prefix);
                LogLine(PersonalInfo.Th_Firstname);
                LogLine(PersonalInfo.Th_Lastname);
                LogLine(PersonalInfo.En_Prefix);
                LogLine(PersonalInfo.En_Firstname);
                LogLine(PersonalInfo.En_Lastname);
                LogLine(PersonalInfo.Issue.ToString("dd/MM/yyyy"));
                LogLine(PersonalInfo.Expire.ToString("dd/MM/yyyy"));


                LogLine(PersonalInfo.Address);
                LogLine(PersonalInfo.addrHouseNo); // บ้านเลขที่ 
                LogLine(PersonalInfo.addrVillageNo); // หมู่ที่
                LogLine(PersonalInfo.addrLane); // ซอย
                LogLine(PersonalInfo.addrRoad); // ถนน
                LogLine(PersonalInfo.addrTambol);
                LogLine(PersonalInfo.addrAmphur);
                LogLine(PersonalInfo.addrProvince);
                LogLine(PersonalInfo.Issuer);
                if (PersonalInfo.PhotoBase64 != null)
                {
                    using (var ms = new MemoryStream(PersonalInfo.PhotoRaw, 0, PersonalInfo.PhotoRaw.Length))
                    {
                        picPhoto.Image = Image.FromStream(ms, true);
                    }
                }
            }
        }

        private void Idcard_eventCardRemoved()
        {
            Debug.Print("Event CardRemoved");
            txtdata.BeginInvoke(new MethodInvoker(delegate { txtdata.Text = ""; }));
            picPhoto.BeginInvoke(new MethodInvoker(delegate { picPhoto.Image = null; picPhoto.Refresh(); }));

        }

        private void Idcard_eventCardInserted(PersonalInfo PersonalInfo)
        {
            Debug.Print("Event Card Insert");

        }

        private void btRefreshReader_Click(object sender, EventArgs e)
        {
            cmbReader.Items.Clear();
            try
            {
                var readerlist = idcard.GetReaders();
                foreach (var reader in readerlist)
                {
                    cmbReader.Items.Add(reader);
                }
                cmbReader.SelectedIndex = 0;

                if (!_ismonitor)
                {
                    StartMonitor(cmbReader.Items[cmbReader.SelectedIndex].ToString());
                }
            }
            catch(Exception ex)
            {
                cmbReader.Refresh();
                MessageBox.Show(ex.Message);
                
            }


        }


    }
}