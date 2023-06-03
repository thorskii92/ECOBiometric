using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace ECO
{
    public partial class frmViewBiometric : Form
    {
        private frmAddEdBio _AdEdBio;
        public frmViewBiometric()
        {
            InitializeComponent();
            _AdEdBio = new frmAddEdBio(this);
        }

        private void frmViewBiometric_Load(object sender, EventArgs e)
        {

        }

        public void loadBio(int empID)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT FingerPrint FROM tblBiometric WHERE empID=" + empID, msqlcon.con);
            da.Fill(dt);
            picThumb.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            picIndex.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            picMiddle.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            picRing.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            picPinky.BackgroundImage = ECO.Properties.Resources.BiometricsUnavailable;
            btnDeleteThumb.Visible = false;
            btnIndex.Visible = false;
            btnMiddle.Visible = false;
            btnRing.Visible = false;
            btnPinky.Visible = false;
            if (dt.Rows.Count > 0)
            {

                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    string FingerPart = dt.Rows[x][0].ToString();
                    if (FingerPart == "Thumb")
                    {
                        picThumb.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                        btnDeleteThumb.Visible = true;
                    }
                    else if (FingerPart == "Index")
                    {
                        picIndex.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                        btnIndex.Visible = true;
                    }
                    else if (FingerPart == "Middle")
                    {
                        picMiddle.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                        btnMiddle.Visible = true;
                    }
                    else if (FingerPart == "Ring")
                    {
                        picRing.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                        btnRing.Visible = true;
                    }
                    else if (FingerPart == "Pinky")
                    {
                        picPinky.BackgroundImage = ECO.Properties.Resources.BiometricsAvailable;
                        btnPinky.Visible = true;
                    }
                }
            }
        }

        private void picThumb_Click(object sender, EventArgs e)
        {
            ShowEdit(Convert.ToInt32(lblEmpID.Text), "Thumb");
        }

        public void ShowEdit(int empID, string FPart)
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM tblBiometric WHERE FingerPart='" + FPart + "' and empID=" + lblEmpID.Text, msqlcon.con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                //if (MessageBox.Show("Do you want to Update or Delete Biometric?", "Update or Delete Biometric", mess))
                _AdEdBio.Text = "Update Biometric";
                StoreData.selectBioEmpID = Convert.ToInt32(lblEmpID.Text);
                StoreData.FingerPart = FPart;
                _AdEdBio.lblFinger.Text = FPart;
                _AdEdBio.StartPosition = FormStartPosition.CenterScreen;
                _AdEdBio.ShowDialog();
            }
            else
            {
                _AdEdBio.Text = "New Biometric";
                StoreData.selectBioEmpID = Convert.ToInt32(lblEmpID.Text);
                StoreData.FingerPart = FPart;
                _AdEdBio.lblFinger.Text = FPart;
                _AdEdBio.StartPosition = FormStartPosition.CenterScreen;
                _AdEdBio.ShowDialog();
            }
        }

        private void picIndex_Click(object sender, EventArgs e)
        {
            ShowEdit(Convert.ToInt32(lblEmpID.Text), "Index");
        }

        private void picMiddle_Click(object sender, EventArgs e)
        {
            ShowEdit(Convert.ToInt32(lblEmpID.Text), "Middle");
        }

        private void picRing_Click(object sender, EventArgs e)
        {
            ShowEdit(Convert.ToInt32(lblEmpID.Text), "Ring");
        }

        private void picPinky_Click(object sender, EventArgs e)
        {
            ShowEdit(Convert.ToInt32(lblEmpID.Text), "Pinky");
        }

        private void btnDeleteThumb_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Finger Print?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                deleteFingerPrint(Convert.ToInt32(lblEmpID.Text), "Thumb");
            }
           
        }

        public void deleteFingerPrint(int empID, string FingerType)
        {
            CheckOpen.cons();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tblBiometric WHERE empID=" + empID + " AND FingerPart='" + FingerType + "'", msqlcon.con);
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Finger Print has been Deleted", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadBio(Convert.ToInt32(lblEmpID.Text));
        }

        private void btnIndex_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Finger Print?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                deleteFingerPrint(Convert.ToInt32(lblEmpID.Text), "Index");
            }
        }

        private void btnMiddle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Finger Print?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                deleteFingerPrint(Convert.ToInt32(lblEmpID.Text), "Middle");
            }
        }

        private void btnRing_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Finger Print?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                deleteFingerPrint(Convert.ToInt32(lblEmpID.Text), "Ring");
            }
        }

        private void btnPinky_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Finger Print?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                deleteFingerPrint(Convert.ToInt32(lblEmpID.Text), "Pinky");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
