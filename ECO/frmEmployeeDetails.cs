using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ECO
{
    public partial class frmEmployeeDetails : Form
    {
        //string checkBio;
        public frmEmployeeDetails()
        {
            InitializeComponent();
        }

        private void frmEmployeeDetails_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void LoadDetails(int i)
        {
            CheckOpen.cons();
            EmployeeQuery.EmpDataQuery(i);
            DataTable dtEm = new DataTable();
            dtEm.Clear();
            dtEm = EmployeeQuery.EmpdetailsDT;
            lblAddress.Text = dtEm.Rows[0][4].ToString() + " " + dtEm.Rows[0][5].ToString() + ", " + dtEm.Rows[0][6].ToString() + ", " + dtEm.Rows[0][7].ToString();
            try
            {
                lblBday.Text = Convert.ToDateTime(dtEm.Rows[0][11]).ToString("MMMM dd, yyyy");
            }
            catch
            {
                lblBday.Text = "";
            }
            
            lblBloodType.Text = dtEm.Rows[0][19].ToString();
            lblBPlace.Text = dtEm.Rows[0][12].ToString();
            lblCitizen.Text = dtEm.Rows[0][15].ToString();
            lblCivStat.Text = dtEm.Rows[0][14].ToString();
            lblConAddress.Text = dtEm.Rows[0][30].ToString() + " " + dtEm.Rows[0][31].ToString() + ", " + dtEm.Rows[0][32].ToString() + ", " + dtEm.Rows[0][34].ToString();
            lblConName.Text = dtEm.Rows[0][26].ToString() + " " + dtEm.Rows[0][27].ToString() + ". " + dtEm.Rows[0][25].ToString();
            lblConNum.Text = dtEm.Rows[0][28].ToString();
            try
            {
                lblDateHired.Text = Convert.ToDateTime(dtEm.Rows[0][20]).ToString("MMMM dd, yyyy");
            }
            catch
            {
                lblDateHired.Text = "";
            }
            
            lblEmail.Text = dtEm.Rows[0][9].ToString();
            lblEmpStatus.Text = dtEm.Rows[0][34].ToString();
            lblGender.Text = dtEm.Rows[0][13].ToString();
            lblHeight.Text = dtEm.Rows[0][17].ToString();
            lblID.Text = dtEm.Rows[0][0].ToString();
            lblName.Text = dtEm.Rows[0][2].ToString() + " " + dtEm.Rows[0][3].ToString() + ". " + dtEm.Rows[0][1].ToString();
            lblNum.Text = dtEm.Rows[0][10].ToString();
            lblPAGIBIG.Text = dtEm.Rows[0][24].ToString();
            lblPhilHealth.Text = dtEm.Rows[0][22].ToString();
            lblPos.Text = dtEm.Rows[0][36].ToString();
            lblRelationship.Text = dtEm.Rows[0][29].ToString();
            lblReligion.Text = dtEm.Rows[0][16].ToString();
            lblSSS.Text = dtEm.Rows[0][23].ToString();
            lblTIN.Text = dtEm.Rows[0][21].ToString();
            lblWeight.Text = dtEm.Rows[0][18].ToString();
            try
            {
                lblDateResigned.Text = Convert.ToDateTime(dtEm.Rows[0][35]).ToString("MMMM dd, yyyy");
            }
            catch
            {
                lblDateResigned.Text = "";
            }
            //checkBio = dtEm.Rows[0][21].ToString();
            byte[] bits = new byte[0];
            bits = (byte[])dtEm.Rows[0][37];
            MemoryStream ms = new MemoryStream(bits);
            picID.BackgroundImage = Image.FromStream(ms);
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT FingerPart FROM tblBiometric WHERE empID=" + dtEm.Rows[0][0].ToString(), msqlcon.con);
            da.Fill(dt);
            picThumb.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            picIndex.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            picMiddle.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            picRing.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            picPinky.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            if (dt.Rows.Count > 0)
            {
                for(int x=0;x <= dt.Rows.Count - 1; x++)
                {
                    string FingerPart = dt.Rows[x][0].ToString();
                    if (FingerPart == "Thumb")
                    {
                        picThumb.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                    else if (FingerPart == "Index")
                    {
                        picIndex.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                    else if (FingerPart == "Middle")
                    {
                        picMiddle.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                    else if (FingerPart == "Ring")
                    {
                        picRing.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                    else if (FingerPart == "Pinky")
                    {
                        picPinky.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                    }
                }
            }

            //if (checkBio == "YES")
            //{
            //    picBio.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
            //}
            //else
            //{
            //    picBio.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            //}
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (StoreData.EmpSelectedIndex < StoreData.TotalEmpID)
            {
                StoreData.EmpSelectedIndex++;
                LoadDetails(StoreData.EmpSelectedIndex);
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (StoreData.EmpSelectedIndex > 0)
            {
                StoreData.EmpSelectedIndex--;
                LoadDetails(StoreData.EmpSelectedIndex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CheckOpen.cons();
            DataTable dtT = new DataTable();
            MySqlDataAdapter daT = new MySqlDataAdapter("SELECT LastName, FirstName, MiddleInitial FROM emp WHERE empID=" + lblID.Text, msqlcon.con);
            daT.Fill(dtT);
            
            frmEmployeeLog fLog = new frmEmployeeLog();
            fLog.txtName.Text = dtT.Rows[0][0].ToString() + ", " + dtT.Rows[0][1].ToString() + " " + dtT.Rows[0][0].ToString() + ".";
            fLog.txtID.Text = lblID.Text;

            fLog.StartPosition = FormStartPosition.CenterScreen;
            fLog.ShowDialog();
        }

        private void picBio_Click(object sender, EventArgs e)
        {

        }
    }
}
