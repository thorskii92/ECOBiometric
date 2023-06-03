using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using DPFP.Capture;
using System.IO;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;

namespace ECO
{
    public partial class frmAddEdBio : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Template Template;
        private DPFP.Capture.Capture Capturer;
        private DPFP.Processing.Enrollment Enroller = new DPFP.Processing.Enrollment();
        public int returnedVal;
        private DPFP.Verification.Verification Verificator = new DPFP.Verification.Verification();
        private frmViewBiometric m_parent;
        public frmAddEdBio(frmViewBiometric frm1)
        {
            InitializeComponent();
            m_parent = frm1;
            //_AdEdBio = new frmAddEdBio();
        }

        protected virtual void Init()
        {
            //try
            //{
                Capturer = new DPFP.Capture.Capture();

                if (null != Capturer)
                {
                    Capturer.EventHandler = this;
                }
                else
                {
                    SetPrompt("Can't initiate capture operation!");
                }
            //}
            //catch
            //{
            //    MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    SetPrompt("Using the fingerprint reader, scan your fingerprint.");
                }
                catch
                {
                    SetPrompt("Can't initiate capture!");
                }
            }
        }
        protected void Stop()
        {
            if (null != Capturer)
            {
                
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    SetPrompt("Can't initiate capture!");
                }
            }
        }
        private void UpdateStatus()
        {
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded));
        }

        protected void SetStatus(string status)
        {
            this.Invoke(new Function(delegate ()
            {
                lblRemark.Text = status;
            }));
        }
        protected void SetPrompt(string prompt)
        {
            this.Invoke(new Function(delegate ()
            {
                txtPrompt.Text = prompt;
            }));
        }
        protected void MakeReport(string message)
        {
            this.Invoke(new Function(delegate ()
            {
                txtStatus.AppendText(message + "\r\n");
            }));
        }
        private void DrawPicture(Bitmap bitmap)
        {
            this.Invoke(new Function(delegate ()
            {
                picFinger.Image = new Bitmap(bitmap, picFinger.Size);
            }));
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            MakeReport("The fingerprint sample was captured.");
            SetPrompt("Scan the same fingerprint again.");
            Checker(Sample);
            if (returnedVal == 1)
            {
                MessageBox.Show("Already used Fingerprint", "Fingerprint Used", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Process(Sample);
            }
            
        }
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The finger was removed from the fingerprint reader.");
        }
        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was touched.");
        }
        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was connected.");
        }
        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            MakeReport("The fingerprint reader was disconnected.");
        }
        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
            {
                MakeReport("The quality of the fingerprint sample is good.");
            }
            else
            {
                MakeReport("The quality of the fingerprint sample is poor.");
            }
        }

        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();
            Bitmap bitmap = null;
            Convertor.ConvertToPicture(Sample, ref bitmap);
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);

            if (feedback == DPFP.Capture.CaptureFeedback.Good)
            {
                return features;
            }
            else
            {
                return null;
            }
        }
        private void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                //btnAdd.Visible = (Template != null);
                if (Template != null)
                {
                    //MessageBox.Show("The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment"); // MakeReport
                     // MakeReport
                   //CheckOpen.cons();
                   if (this.Text == "New Biometric")
                    {
                        CheckOpen.cons();
                        MemoryStream fingerprintData = new MemoryStream();
                        Template.Serialize(fingerprintData);
                        fingerprintData.Position = 0;
                        BinaryReader br = new BinaryReader(fingerprintData);
                        Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO tblbiometric(empID,FingerPrint,FingerPart) VALUES(@eID,@FPrint,@Fpart)", msqlcon.con);
                        cmd.Parameters.AddWithValue("@eID", StoreData.selectBioEmpID);
                        cmd.Parameters.Add("@FPrint", MySqlDbType.Blob).Value = bytes;
                        cmd.Parameters.AddWithValue("@FPart", StoreData.FingerPart);
                        cmd.ExecuteNonQuery();
                        m_parent.loadBio(StoreData.selectBioEmpID);
                        txtPrompt.Text = "";
                        txtStatus.Text = "";
                        picFinger.Image = null;
                        picFinger.BackgroundImage = null;
                        Stop();
                        Thread.Sleep(1000);
                        MessageBox.Show("The fingerprint is now Saved", "Fingerprint Enrollment");
                        m_parent.Show();
                        this.Close();
                    }
                   else if (this.Text == "Update Biometric")
                    {
                        CheckOpen.cons();
                        MemoryStream fingerprintData = new MemoryStream();
                        Template.Serialize(fingerprintData);
                        fingerprintData.Position = 0;
                        BinaryReader br = new BinaryReader(fingerprintData);
                        Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
                        MySqlCommand cmd = new MySqlCommand("UPDATE tblbiometric SET FingerPrint=@FPrint WHERE FingerPart='" + StoreData.FingerPart + "' AND empID=" + StoreData.selectBioEmpID, msqlcon.con);
                        //cmd.Parameters.AddWithValue("@eID", StoreData.selectBioEmpID);
                        cmd.Parameters.Add("@FPrint", MySqlDbType.Blob).Value = bytes;
                        //cmd.Parameters.AddWithValue("@FPart", StoreData.FingerPart);
                        cmd.ExecuteNonQuery();
                        m_parent.loadBio(StoreData.selectBioEmpID);
                        txtPrompt.Text = "";
                        txtStatus.Text = "";
                        picFinger.Image = null;
                        picFinger.BackgroundImage = null;
                        Stop();
                        Thread.Sleep(1000);
                        MessageBox.Show("The fingerprint is now Saved", "Fingerprint Enrollment");
                        m_parent.Show();
                        this.Close();
                    }
                    
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment"); // MakeReport
                }
            }));
        }

        protected virtual void Checker(DPFP.Sample Sample)
        {
            int retVal=0;
            returnedVal = 0;
            DrawPicture(ConvertSampleToBitmap(Sample));
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            if (features != null)
            {
                CheckOpen.cons();
                //MySqlCommand command = new MySqlCommand ( );

                MySqlDataAdapter ada = new MySqlDataAdapter("SELECT B.FingerPrint, B.empID, E.FirstName FROM tblbiometric " +
                                                              "AS B LEFT JOIN emp AS E ON E.empID = B.empID", msqlcon.con);
                DataTable dt = new DataTable();
                ada.Fill(dt);

                foreach (DataRow dr in dt.Rows)
                {
                    byte[] fp_byte = (byte[])dr["FingerPrint"];
                    
                    Stream str = new MemoryStream(fp_byte);
                    DPFP.Template temp = new DPFP.Template(str);
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, temp, ref result);

                    if (result.Verified)
                    {

                        retVal = 1;
                        break;
                    }
                    else
                    {
                        retVal = 0;
                    }
                }
                returnedVal = retVal;
                
            }
        }

        protected virtual void Process(DPFP.Sample Sample)
        {

            DrawPicture(ConvertSampleToBitmap(Sample));

            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            if (features != null) try
                {

                    MakeReport("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features);
                }
                finally
                {
                    UpdateStatus();
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            OnTemplate(Enroller.Template);
                            SetPrompt("Fingerprint sample can be added.");
                            Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:
                            OnTemplate(null);
                            Enroller.Clear();
                            SetPrompt("Scan the fingerprint again.");
                            Stop();
                            UpdateStatus();
                            Start();
                            break;
                    }
                }
        }

        private void frmAddEdBio_Load(object sender, EventArgs e)
        {
            Enroller.Clear();
            Init();
            Start();
        }
    }
}
