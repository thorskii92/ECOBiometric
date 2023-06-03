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

namespace ECO
    {
    public partial class frmUpdateBio : Form, DPFP.Capture.EventHandler
        {
        private DPFP.Template Template;
        private DPFP.Capture.Capture Capturer;
        private DPFP.Processing.Enrollment Enroller = new DPFP.Processing.Enrollment ();
        private frmBiometric m_Parent;
        private string Fpart, checkBio1, checkBio2, checkBio3, checkBio4, checkBio5;

        protected virtual void Init ( )
            {
            try
                {
                Capturer = new DPFP.Capture.Capture ();

                if (null != Capturer)
                    {
                        Capturer.EventHandler = this;
                    }
                else
                    {
                        SetPrompt ( "Can't initiate capture operation!" );
                    }
                }
            catch
                {
                    MessageBox.Show ( "Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }

        protected void Start ( )
            {
            if (null != Capturer)
                {
                try
                    {
                        Capturer.StartCapture ();
                        SetPrompt ( "Using the fingerprint reader, scan your fingerprint." );
                    }
                catch
                    {
                        SetPrompt ( "Can't initiate capture!" );
                    }
                }
            }

        protected void Stop ( )
            {
            if (null != Capturer)
                {
                    try
                    {
                        Capturer.StopCapture ();
                    }
                    catch
                    {
                        SetPrompt ( "Can't initiate capture!" );
                    }
                }
            }
        public void UpdateFinger ( string _Fpart )
            {
                MemoryStream fingerprintData = new MemoryStream ();
                Template.Serialize ( fingerprintData );
                fingerprintData.Position = 0;
                BinaryReader br = new BinaryReader ( fingerprintData );
                Byte[] bytes = br.ReadBytes ( (Int32) fingerprintData.Length );
                MySqlCommand cmd = new MySqlCommand ( "UPDATE biometrics SET FingerPrint = @Fprint WHERE FingerPart = '"+_Fpart+"' AND empID = '"+lblEmpID.Text+"'", msqlcon.con );
                cmd.Parameters.Add ( "@Fprint", MySqlDbType.Blob ).Value = bytes;
                cmd.ExecuteNonQuery ();
                MessageBox.Show ( "Fingerprint is succesfully updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information );
                m_Parent.LoadBio ();
                this.Close ();
            }
        public void LoadFinger1()
            {
                CheckOpen.cons ();
                DataTable dt = new DataTable ();
                dt.Clear ();
                MySqlDataAdapter ada = new MySqlDataAdapter ( "SELECT if ((SELECT COUNT(FingerPrint) FROM biometrics  " + 
                                                              "WHERE empID = '"+lblEmpID.Text+"' AND FingerPart = 'Thumb') > 0, 'YES','NO') AS IsBio", msqlcon.con);
                ada.Fill ( dt );
                checkBio1 = dt.Rows[0][0].ToString ();
               
                if (checkBio1 == "YES")
                    {
                        picFinger1.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                else
                    {
                        picFinger1.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
                    }

            }
        public void LoadFinger2()
            {
                CheckOpen.cons ();
                DataTable dt = new DataTable ();
                dt.Clear ();
                MySqlDataAdapter ada = new MySqlDataAdapter ( "SELECT if ((SELECT COUNT(FingerPrint) FROM biometrics WHERE empID = '" + lblEmpID.Text + "' AND FingerPart = 'Index Finger') > 0, 'YES','NO') AS IsBio", msqlcon.con );
                ada.Fill ( dt );
                checkBio2 = dt.Rows[0][0].ToString ();

                if (checkBio2 == "YES")
                    {
                        picFinger2.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                else
                    {
                        picFinger2.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
                    }
            }
        public void LoadFinger3()
            {
                CheckOpen.cons ();
                DataTable dt = new DataTable ();
                dt.Clear ();
                MySqlDataAdapter ada = new MySqlDataAdapter ( "SELECT if ((SELECT COUNT(FingerPrint) FROM biometrics WHERE empID = '" + lblEmpID.Text + "' AND FingerPart = 'Middle Finger') > 0, 'YES','NO') AS IsBio", msqlcon.con );
                ada.Fill ( dt );
                checkBio3 = dt.Rows[0][0].ToString ();

                if (checkBio3 == "YES")
                    {
                        picFinger3.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                else
                    {
                        picFinger3.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
                    }
            }
        public void LoadFinger4()
            {
                CheckOpen.cons ();
                DataTable dt = new DataTable ();
                dt.Clear ();
                MySqlDataAdapter ada = new MySqlDataAdapter ( "SELECT if ((SELECT COUNT(FingerPrint) FROM biometrics WHERE empID = '" + lblEmpID.Text + "' AND FingerPart = 'Ring Finger') > 0, 'YES','NO') AS IsBio", msqlcon.con );
                ada.Fill ( dt );
                checkBio4 = dt.Rows[0][0].ToString ();

                if (checkBio4 == "YES")
                    {
                        picFinger4.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                else
                    {
                        picFinger4.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
                    }
            }
        public void LoadFinger5()
            {
                CheckOpen.cons ();
                DataTable dt = new DataTable ();
                dt.Clear ();
                MySqlDataAdapter ada = new MySqlDataAdapter ( "SELECT if ((SELECT COUNT(FingerPrint) FROM biometrics WHERE empID = '" + lblEmpID.Text + "' AND FingerPart = 'Little Finger') > 0, 'YES','NO') AS IsBio", msqlcon.con );
                ada.Fill ( dt );
                checkBio5 = dt.Rows[0][0].ToString ();

                if (checkBio5 == "YES")
                    {
                        picFinger5.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                else
                    {
                        picFinger5.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
                    }
            }
        private void UpdateStatus ( )
            {
                SetStatus ( String.Format ( "Fingerprint samples needed: {0}", Enroller.FeaturesNeeded ) );
            }
        public frmUpdateBio (frmBiometric frm2)
            {
                InitializeComponent ();
                m_Parent = frm2;
            }

        private void frmUpdateBio_Load (object sender, EventArgs e)
            {
                Init ();
                Start ();
                cboFinger.SelectedIndex = 0;
                LoadFinger1 ();
                LoadFinger2 ();
                LoadFinger3 ();
                LoadFinger4 ();
                LoadFinger5 ();
            }
        public void OnComplete (object Capture, string ReaderSerialNumber, Sample Sample)
            {
                MakeReport ( "The fingerprint sample was captured." );
                SetPrompt ( "Scan the same fingerprint again." );
                Process ( Sample );
            }

        public void OnFingerGone (object Capture, string ReaderSerialNumber)
            {
                MakeReport ( "The finger was removed from the fingerprint reader." );
            }

        public void OnFingerTouch (object Capture, string ReaderSerialNumber)
            {
                MakeReport ( "The fingerprint reader was touched." );
            }

        public void OnReaderConnect (object Capture, string ReaderSerialNumber)
            {
                MakeReport ( "The fingerprint reader was connected." );
            }

        public void OnReaderDisconnect (object Capture, string ReaderSerialNumber)
            {
                MakeReport ( "The fingerprint reader was disconnected." );
            }

        public void OnSampleQuality (object Capture, string ReaderSerialNumber, CaptureFeedback CaptureFeedback)
            {
            if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                {
                    MakeReport ( "The quality of the fingerprint sample is good." );
                }
            else
                {
                    MakeReport ( "The quality of the fingerprint sample is poor." );
                }
            }

        protected Bitmap ConvertSampleToBitmap (DPFP.Sample Sample)
            {
                DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion ();
                Bitmap bitmap = null;
                Convertor.ConvertToPicture ( Sample, ref bitmap );
                return bitmap;
            }

        protected DPFP.FeatureSet ExtractFeatures (DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
            {
                DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction ();
                DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
                DPFP.FeatureSet features = new DPFP.FeatureSet ();
                Extractor.CreateFeatureSet ( Sample, Purpose, ref feedback, ref features );

            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                {
                    return features;
                }
            else
                {
                    return null;
                }
            }
        private void OnTemplate (DPFP.Template template)
            {
            this.Invoke ( new Function ( delegate ( )
                {
                    Template = template;
                    btnUpdate.Visible = (Template != null);
                    if (Template != null)
                        {
                            MessageBox.Show ( "The fingerprint template is ready for fingerprint verification.", "Fingerprint Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Information ); // MakeReport
                        }
                    else
                        {
                            MessageBox.Show ( "The fingerprint template is not valid. Repeat fingerprint enrollment.", "Fingerprint Enrollment", MessageBoxButtons.OK, MessageBoxIcon.Information ); // MakeReport
                        }
                }));
            }

        protected virtual void Process (DPFP.Sample Sample)
            {
            DrawPicture ( ConvertSampleToBitmap ( Sample ) );

            DPFP.FeatureSet features = ExtractFeatures ( Sample, DPFP.Processing.DataPurpose.Enrollment );
            if (features != null) try
                    {
                        MakeReport ( "The fingerprint feature set was created." );
                        Enroller.AddFeatures ( features );
                    }
                finally
                    {
                    UpdateStatus ();
                    switch (Enroller.TemplateStatus)
                        {
                        case DPFP.Processing.Enrollment.Status.Ready:
                            OnTemplate ( Enroller.Template );
                            SetPrompt ( "Fingerprint sample can be added." );
                            Stop ();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:
                            OnTemplate ( null );
                            Enroller.Clear ();
                            SetPrompt ( "Scan the fingerprint again." );
                            Stop ();
                            UpdateStatus ();
                            Start ();
                            break;
                        }
                    }
            }

        private void frmUpdateBio_FormClosed (object sender, FormClosedEventArgs e)
            {

            }

        protected void SetStatus (string status)
            {
            this.Invoke ( new Function ( delegate ( )
                {
                    lblRemark.Text = status;
                }));
            }
        protected void SetPrompt (string prompt)
            {
            this.Invoke ( new Function ( delegate ( )
                {
                    txtPrompt.Text = prompt;
                }));
            }
        protected void MakeReport (string message)
            {
            this.Invoke ( new Function ( delegate ( )
                {
                    txtStatus.AppendText ( message + "\r\n" );
                 }));
            }
        private void DrawPicture (Bitmap bitmap)
            {
            this.Invoke ( new Function ( delegate ( )
                {
                    picFinger.Image = new Bitmap ( bitmap, picFinger.Size );
                }));
            }

        private void btnUpdate_Click (object sender, EventArgs e)
            {
                Fpart = cboFinger.SelectedItem.ToString ();
                UpdateFinger (Fpart);
            picFinger.BackgroundImage = null;
            picFinger.Image = null;
            Enroller.Clear();
            }
        }
    }
