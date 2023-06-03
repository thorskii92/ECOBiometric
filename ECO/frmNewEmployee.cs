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
using System.IO;

namespace ECO
{
    public partial class frmNewEmployee : Form
    {
        public string imgLoc = "";
        List<int> arrPosID = new List<int>();
        private frmEmployeeManagement m_Parent;
        public frmNewEmployee(frmEmployeeManagement frm1)
        {
            InitializeComponent();
            m_Parent = frm1;
        }

        private void picID_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Choose Image (*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png;";
                opf.Title = "Select Employee Picture";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = opf.FileName.ToString();
                    picID.BackgroundImage = Image.FromFile(opf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCance_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void msktxtTIN_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           
        }

        private void msktxtTIN_Click(object sender, EventArgs e)
        {
           
        }

        private void msktxtTIN_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CheckOpen.cons();
            if (this.Text == "New Employee")
            {
                if (txtBarangay.Text == "" || txtBirthplace.Text == "" || txtCitizenship.Text == "" || txtCity.Text == "" || txtEmail.Text == "" || txtEmBarangay.Text == "" || txtEmCity.Text == "" || txtEmFN.Text == "" || txtEmHouseNum.Text == "" || txtEmLN.Text == "" || txtEmMob.Text == "" || txtEmRelationship.Text == "" || txtEmStreet.Text == "" || txtFN.Text == "" || txtHeight.Text == "" || txtHouseNum.Text == "" || txtLN.Text == "" || txtMobile.Text == "" || txtNick.Text == "" || txtReligion.Text == "" || txtStreetName.Text == "" || txtWeight.Text == "")
                {
                    MessageBox.Show("Please enter all necessarry Information", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Are you done?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        MemoryStream ms = new MemoryStream();
                        picID.BackgroundImage.Save(ms, picID.BackgroundImage.RawFormat);
                        byte[] img = ms.ToArray();
                        string contractual = "";
                        string contend = "";
                        if (cboContractType.Text == "Contract")
                        {
                            contractual = ", contractEnd";
                            contend = ", '" + dtpContractEnd.Value.ToString("yyyy-MM-dd") + "'";
                        }
                        else
                        {
                            contractual = "";
                            contend = "";
                        }
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO emp(LastName, FirstName, MiddleInitial, HouseNo, StreetName, Barangay, City, NickName, EmailAdd, MobileNo, Birthday, BirthPlace, Gender, CivilStat, Citizenship, Religion, Height, Weight, Bloodtype, DateHired, IDPic, PositionID, TIN, PhilHealth, SSSID, PAGIBIGID, ConPerLast, ConPerFirst, ConPersMI, ConPerMobNo, ConPersRelationship, ConPersHouseNo, ConPersStreetName, ConPersBarangay, ConPersCity, empStat, contractType" + contractual + ") VALUES(@LN, @FN, @MI, @HNo, @StN, @Brgy, @Cty, @NName, @EmailA, @MobNo, @Bday, @BPlace, @Gder, @CivStat, @Citizen, @Rgion, @Hgt, @Wgt, @Btype, @DHired, @IDP, @PosID, @Tax, @PHealth, @SSSNo, @PAGIBIGNo, @CPerLast, @CPerFirst, @CPersMI, @CPersMobNo, @CPersRelationship, @CPersHouseNo, @CPersStreetName, @CPersBarangay, @CPersCity, @eStat, @contType" + contend + ")", msqlcon.con);
                        cmd.Parameters.AddWithValue("@LN", txtLN.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@FN", txtFN.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@MI", txtMI.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@HNo", txtHouseNum.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@StN", txtStreetName.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@Brgy", txtBarangay.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@Cty", txtCity.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@NName", txtNick.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@EmailA", txtEmail.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@MobNo", txtMobile.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@Bday", dtpDOB.Value.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@BPlace", txtBirthplace.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@Gder", cboGender.Text);
                        cmd.Parameters.AddWithValue("@CivStat", cboCivStatus.Text);
                        cmd.Parameters.AddWithValue("@Citizen", txtCitizenship.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@Rgion", txtReligion.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@Hgt", txtHeight.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@Wgt", txtWeight.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@Btype", cboBloodType.Text);
                        cmd.Parameters.AddWithValue("@DHired", dtpHired.Value.ToString("yyyy-MM-dd"));

                        cmd.Parameters.Add("@IDP", MySqlDbType.LongBlob);
                        cmd.Parameters["@IDP"].Value = img;

                        cmd.Parameters.AddWithValue("@PosID", arrPosID[cboPosition.SelectedIndex]);
                        
                        cmd.Parameters.AddWithValue("@Tax", msktxtTIN.Text);
                        cmd.Parameters.AddWithValue("@PHealth", msktxtPhilHealth.Text);
                        cmd.Parameters.AddWithValue("@SSSNo", msktxtSSS.Text);
                        cmd.Parameters.AddWithValue("@PAGIBIGNo", msktxtPAGIBIG.Text);
                        cmd.Parameters.AddWithValue("@CPerLast", txtEmLN.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@CPerFirst", txtEmFN.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@CPersMI", txtEmMI.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@CPersMobNo", txtEmMob.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@CPersRelationship", txtEmRelationship.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@CPersHouseNo", txtEmHouseNum.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@CPersStreetName", txtEmStreet.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@CPersBarangay", txtEmBarangay.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@CPersCity", txtEmCity.Text.Replace("'", "''"));
                        cmd.Parameters.AddWithValue("@eStat", "Employed");
                        cmd.Parameters.AddWithValue("@contType", cboContractType.Text);
                        cmd.ExecuteNonQuery();
                        m_Parent.loademployees();
                        clearAll();
                        enableAll();
                        this.Close();
                    }
                }

                
            }
            else
            {
                if (MessageBox.Show("Save Changes?","Save", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CheckOpen.cons();
                    MemoryStream ms = new MemoryStream();
                    picID.BackgroundImage.Save(ms, picID.BackgroundImage.RawFormat);
                    byte[] img = ms.ToArray();
                    string contractend = "";
                    
                    if (cboContractType.Text=="Contract")
                    {
                        contractend = ", contractEnd='" + dtpContractEnd.Value.ToString("yyyy-MM-dd") + "'";
                    }
                    else
                    {
                        contractend = ", contractEnd=null";
                    }
                    MySqlCommand cmd = new MySqlCommand("UPDATE emp SET HouseNo='" + txtHouseNum.Text.Replace("'","''") + "', StreetName='" + txtStreetName.Text.Replace("'","''") + "',Barangay='" + txtBarangay.Text.Replace("'","''") + "',City='" + txtCity.Text.Replace("'","''") + "',EmailAdd='" + txtEmail.Text.Replace("'","''") + "',MobileNo='" + txtMobile.Text.Replace("'","''") + "',CivilStat='" + cboCivStatus.Text + "',Religion='" + txtReligion.Text.Replace("'","''") + "',Height=" + Convert.ToDouble(txtHeight.Text) + ",Weight=" + Convert.ToDouble(txtWeight.Text) + ",IDPIc=@img,PositionID=" + arrPosID[cboPosition.SelectedIndex] + ",TIN='" + msktxtTIN.Text + "',PhilHealth='" + msktxtPhilHealth.Text + "',SSSID='" + msktxtSSS.Text + "',PAGIBIGID='" + msktxtPAGIBIG.Text + "',ConPerLast='" + txtEmLN.Text.Replace("'","''") + "',ConPerFirst='" + txtEmFN.Text.Replace("'","''") + "',ConPersMI='" + txtEmMI.Text.Replace("'","''") + "',ConPerMobNo='" + txtEmMob.Text.Replace("'","''") + "',ConPersRelationship='" + txtEmRelationship.Text.Replace("'","''") + "',ConPersHouseNo='" + txtEmHouseNum.Text.Replace("'","''") + "',ConPersStreetName='" + txtEmStreet.Text.Replace("'","''") + "',ConPersBarangay='" + txtEmBarangay.Text.Replace("'","''") + "',ConPersCity='" + txtEmCity.Text.Replace("'","''") + "', ContractType='" + cboContractType.Text + "'" + contractend + " WHERE empID=" + StoreData.HoldUpdateEmpID, msqlcon.con);
                    cmd.Parameters.Add("@img", MySqlDbType.LongBlob);
                    cmd.Parameters["@img"].Value = img;
                    cmd.ExecuteNonQuery();
                    m_Parent.loademployees();
                    clearAll();
                    enableAll();
                    this.Close();
                }
            }
            
        }
        public void clearAll()
        {
            txtBarangay.Text = "";
            txtBirthplace.Text = "";
            txtCitizenship.Text = "";
            txtCity.Text = "";
            txtEmail.Text = "";
            txtEmBarangay.Text = "";
            txtEmCity.Text = "";
            txtEmFN.Text = "";
            txtEmHouseNum.Text = "";
            txtEmLN.Text = "";
            txtEmMI.Text = "";
            txtEmMob.Text = "";
            txtEmRelationship.Text = "";
            txtEmStreet.Text = "";
            txtFN.Text = "";
            txtHeight.Text = "";
            txtHouseNum.Text = "";
            txtLN.Text = "";
            txtMI.Text = "";
            txtMobile.Text = "";
            txtNick.Text = "";
            txtReligion.Text = "";
            txtStreetName.Text = "";
            txtWeight.Text = "";
            msktxtPAGIBIG.Text = "";
            msktxtPhilHealth.Text = "";
            msktxtSSS.Text = "";
            msktxtTIN.Text = "";
            picID.BackgroundImage = ECO.Properties.Resources.user_image_with_black_background_318_34564;
        }

        public void enableAll()
        {
            txtBarangay.Enabled = true;
            txtBirthplace.Enabled = true;
            txtCitizenship.Enabled = true;
            txtCity.Enabled = true;
            txtEmail.Enabled = true;
            txtEmBarangay.Enabled = true;
            txtEmCity.Enabled = true;
            txtEmFN.Enabled = true;
            txtEmHouseNum.Enabled = true;
            txtEmLN.Enabled = true;
            txtEmMI.Enabled = true;
            txtEmMob.Enabled = true;
            txtEmRelationship.Enabled = true;
            txtEmStreet.Enabled = true;
            txtFN.Enabled = true;
            txtHeight.Enabled = true;
            txtHouseNum.Enabled = true;
            txtLN.Enabled = true;
            txtMI.Enabled = true;
            txtMobile.Enabled = true;
            txtNick.Enabled = true;
            txtReligion.Enabled = true;
            txtStreetName.Enabled = true;
            txtWeight.Enabled = true;
            cboBloodType.Enabled = true;
            cboCivStatus.Enabled = true;
            cboGender.Enabled = true;
            cboPosition.Enabled = true;
            msktxtPAGIBIG.Enabled = true;
            msktxtPhilHealth.Enabled = true;
            msktxtSSS.Enabled = true;
            msktxtTIN.Enabled = true;
            dtpDOB.Enabled = true;
        }

        private void frmNewEmployee_Load(object sender, EventArgs e)
        {
            //loadpositions();
        }

        public void loadpositions()
        {
            CheckOpen.cons();
            arrPosID.Clear();
            cboPosition.Items.Clear();
            DataTable dtPos = new DataTable();
            dtPos.Clear();
            MySqlDataAdapter daPos = new MySqlDataAdapter("SELECT positionID, PositionName FROM empposition", msqlcon.con);
            daPos.Fill(dtPos);
            if (dtPos.Rows.Count > 0)
            {
                int x;
                for (x =0; x <= dtPos.Rows.Count - 1; x++)
                {
                    arrPosID.Add(Convert.ToInt32(dtPos.Rows[x][0]));
                    cboPosition.Items.Add(dtPos.Rows[x][1].ToString());
                }
            }
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opf = new OpenFileDialog();
                opf.Filter = "Choose Image (*.jpg; *.jpeg; *.png) | *.jpg; *.jpeg; *.png;";
                opf.Title = "Select Employee Picture";
                if (opf.ShowDialog() == DialogResult.OK)
                {
                    imgLoc = opf.FileName.ToString();
                    picID.BackgroundImage = Image.FromFile(opf.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelPic_Click(object sender, EventArgs e)
        {
            picID.BackgroundImage = ECO.Properties.Resources.user_image_with_black_background_318_34564;
        }

        private void cboContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboContractType.Text == "Regular")
            {
                lblContractEnd.Visible = false;
                dtpContractEnd.Visible = false;
            }
            else
            {
                lblContractEnd.Visible = true;
                dtpContractEnd.Visible = true;
            }
        }

        private void txtLN_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtMI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtNick_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtBirthplace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtCitizenship_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtReligion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtEmLN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtEmFN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtEmMI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
                base.OnKeyPress(e);
            }
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
