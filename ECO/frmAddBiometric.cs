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
using MySql;
using MySql.Data.MySqlClient;

//Let's Play 7 Billion Humans

namespace ECO
{
    delegate void Function();
    public partial class frmAddBiometric : Form, DPFP.Capture.EventHandler
    {
        private DPFP.Template Template;
        private DPFP.Capture.Capture Capturer;
        private DPFP.Processing.Enrollment Enroller = new DPFP.Processing.Enrollment();
        private frmBiometric m_Parent;
        private string Fpart,ThumbF,IndexF,MiddleF,RingF,LittleF;

        protected virtual void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();

                if (null != Capturer)
                {
                    Capturer.EventHandler = this;
                }
                else
                {
                    SetPrompt("Can't initiate capture operation!");
                }
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        public void Thumb()
        {
            CheckOpen.cons ();
            ThumbF = "Thumb";
            MySqlCommand cmd = new MySqlCommand ( "INSERT INTO biometrics (FingerPart, empID) " +
                                                "VALUES (@Fpart, @ID)", msqlcon.con );

            cmd.Parameters.Add ( "@Fpart", MySqlDbType.VarChar ).Value = ThumbF;
            cmd.Parameters.Add ( "@ID", MySqlDbType.Int32 ).Value = lblEmpID.Text;
            cmd.ExecuteNonQuery ();

            }
        public void IndexFinger()
        {
            CheckOpen.cons ();
            IndexF = "Index Finger";
            MySqlCommand cmd = new MySqlCommand ( "INSERT INTO biometrics (FingerPart, empID) " +
                                               "VALUES (@Fpart, @ID)", msqlcon.con );

            cmd.Parameters.Add ( "@Fpart", MySqlDbType.VarChar ).Value = IndexF;
            cmd.Parameters.Add ( "@ID", MySqlDbType.Int32 ).Value = lblEmpID.Text;
            cmd.ExecuteNonQuery ();
      
            }
        public void MiddleFinger()
        {
            CheckOpen.cons ();
            MiddleF = "Middle Finger";
            MySqlCommand cmd = new MySqlCommand ( "INSERT INTO biometrics (FingerPart, empID) " +
                                               "VALUES (@Fpart, @ID)", msqlcon.con );

            cmd.Parameters.Add ( "@Fpart", MySqlDbType.VarChar ).Value = MiddleF;
            cmd.Parameters.Add ( "@ID", MySqlDbType.Int32 ).Value = lblEmpID.Text;
            cmd.ExecuteNonQuery ();

            }
        public void RingFinger()
        {
            CheckOpen.cons ();
            RingF = "Ring Finger";
            MySqlCommand cmd = new MySqlCommand ( "INSERT INTO biometrics (FingerPart, empID) " +
                                               "VALUES (@Fpart, @ID)", msqlcon.con );

            cmd.Parameters.Add ( "@Fpart", MySqlDbType.VarChar ).Value = RingF;
            cmd.Parameters.Add ( "@ID", MySqlDbType.Int32 ).Value = lblEmpID.Text;
            cmd.ExecuteNonQuery ();

            }
        public void LittleFinger()
        {
            CheckOpen.cons ();
            LittleF = "Little Finger";
            MySqlCommand cmd = new MySqlCommand ( "INSERT INTO biometrics (FingerPart, empID) " +
                                               "VALUES (@Fpart, @ID)", msqlcon.con );

            cmd.Parameters.Add ( "@Fpart", MySqlDbType.VarChar ).Value = LittleF;
            cmd.Parameters.Add ( "@ID", MySqlDbType.Int32 ).Value = lblEmpID.Text;
            cmd.ExecuteNonQuery ();

            }
        public void InsertFinger(string _Fpart)
        {
            CheckOpen.cons();
            MemoryStream fingerprintData = new MemoryStream();
            Template.Serialize(fingerprintData);
            fingerprintData.Position = 0;
            BinaryReader br = new BinaryReader(fingerprintData);
            Byte[] bytes = br.ReadBytes((Int32)fingerprintData.Length);
            MySqlCommand cmd = new MySqlCommand("INSERT INTO biometrics (FingerPrint, FingerPart, empID) " + 
                                                "VALUES (@Fprint, @Fpart, @ID)", msqlcon.con);

            cmd.Parameters.Add("@Fprint", MySqlDbType.Blob).Value = bytes;
            cmd.Parameters.Add("@Fpart", MySqlDbType.VarChar).Value = _Fpart;
            cmd.Parameters.Add("@ID", MySqlDbType.Int32).Value = lblEmpID.Text;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Fingerprint is succesfully saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Stop();
            m_Parent.LoadBio();
            this.Close();    
        }

        public frmAddBiometric(frmBiometric frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            MakeReport("The fingerprint sample was captured.");
            SetPrompt("Scan the same fingerprint again.");
            Process(Sample);
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
                btnAdd.Visible = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("The fingerprint is now Saved", "Fingerprint Enrollment"); // MakeReport
                    CheckOpen.cons();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO tblbiometric(empID,FingerPrint,FingerPart) VALUES(@eID,@FPrint,@Fpart)", msqlcon.con);
                    cmd.Parameters.AddWithValue("@eID", StoreData.selectBioEmpID);
                    cmd.Parameters.AddWithValue("@FPart","");
                }
                else
                {
                    MessageBox.Show("The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment"); // MakeReport
                }
            }));
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
        private void frmAddBiometric_Load(object sender, EventArgs e)
        {
            Init();
            Start();
            cboFinger.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(cboFinger.SelectedItem.Equals("Thumb"))
            {
                Fpart = cboFinger.SelectedItem.ToString();
                IndexFinger ();
                MiddleFinger ();
                RingFinger ();
                LittleFinger ();
                InsertFinger(Fpart);
            }
            else if(cboFinger.SelectedItem.Equals("Index Finger"))
            {
                Fpart = cboFinger.SelectedItem.ToString ();
                Thumb ();
                MiddleFinger ();
                RingFinger ();
                LittleFinger (); 
                InsertFinger(Fpart);
            }
            else if(cboFinger.SelectedItem.Equals("Middle Finger"))
            {
                Fpart = cboFinger.SelectedItem.ToString ();
                Thumb ();
                IndexFinger ();
                RingFinger ();
                LittleFinger ();
                InsertFinger(Fpart);
            }
            else if(cboFinger.SelectedItem.Equals("Ring Finger"))
            {
                Fpart = cboFinger.SelectedItem.ToString ();
                Thumb ();
                IndexFinger ();
                MiddleFinger ();
                LittleFinger ();
                InsertFinger(Fpart);
            }
            else if(cboFinger.SelectedItem.Equals("Little Finger"))
            {
                Fpart = cboFinger.SelectedItem.ToString ();
                Thumb ();
                IndexFinger ();
                MiddleFinger ();
                RingFinger ();
                InsertFinger(Fpart);
            }
        }
    }
}
