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
    public partial class frmEmployeeManagement : Form
    {
        private frmNewEmployee _EdNewEmp;
        private frmResignation _ResEmp;
        public frmEmployeeManagement()
        {
            InitializeComponent();
            _EdNewEmp = new frmNewEmployee(this);
            _ResEmp = new frmResignation(this);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //frmAddEmployee addemp = new frmAddEmployee();
            //addemp.ShowDialog();

            //frmNewEmployee newEmp = new frmNewEmployee();
            //newEmp.StartPosition = FormStartPosition.CenterScreen;
            //newEmp.ShowDialog();
            
            _EdNewEmp.StartPosition = FormStartPosition.CenterScreen;
            _EdNewEmp.Text = "New Employee";
            _EdNewEmp.loadpositions();
            _EdNewEmp.enableAll();
            _EdNewEmp.clearAll();
            _EdNewEmp.ShowDialog();

        }

        private void frmEmployeeManagement_Load(object sender, EventArgs e)
        {

            loademployees();
        }
        public void loademployees()
        {
            CheckOpen.cons();
            DataTable dtEmp = new DataTable();
            dtEmp.Clear();
            MySqlDataAdapter daEmp = new MySqlDataAdapter("SELECT E.empID, E.employmentID, E.LastName, E.FirstName, E.MiddleInitial, E.PositionID, P.PositionName, E.ContractType FROM emp AS E LEFT JOIN empposition AS P ON E.PositionID=P.PositionID WHERE E.empStat='Employed'", msqlcon.con);
            daEmp.Fill(dtEmp);
            lvwUsers.Items.Clear();
            StoreData.HoldEmpIDArr = new List<int>();
            StoreData.HoldEmpIDArr.Clear();
            if (dtEmp.Rows.Count > 0)
            {
                int x;
                StoreData.TotalEmpID = dtEmp.Rows.Count - 1;
                for (x = 0; x <= dtEmp.Rows.Count - 1; x++)
                {
                    ListViewItem lst = new ListViewItem();
                    StoreData.HoldEmpIDArr.Add(Convert.ToInt32(dtEmp.Rows[x][0]));
                    lst.Text = dtEmp.Rows[x][0].ToString();
                    lst.SubItems.Add(dtEmp.Rows[x][2].ToString() + " " + dtEmp.Rows[x][3].ToString() + " " + dtEmp.Rows[x][4].ToString());
                    lst.SubItems.Add(dtEmp.Rows[x][6].ToString());
                    lst.SubItems.Add(dtEmp.Rows[x][7].ToString());
                    lvwUsers.Items.Add(lst);
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (lvwUsers.SelectedItems.Count > 0)
            {
                StoreData.EmpSelectedIndex = lvwUsers.FocusedItem.Index;
                EmployeeQuery.EmpDataQuery(lvwUsers.FocusedItem.Index);
                StoreData.EmpSelectedIndex = lvwUsers.FocusedItem.Index;
                frmEmployeeDetails ViewEmp = new frmEmployeeDetails();
                ViewEmp.LoadDetails(lvwUsers.FocusedItem.Index);
                ViewEmp.StartPosition = FormStartPosition.CenterScreen;
                ViewEmp.ShowDialog();
            }
        }

        private void btnUpdateDetails_Click(object sender, EventArgs e)
        {
            if (lvwUsers.SelectedItems.Count > 0)
            {
                StoreData.HoldUpdateEmpID = StoreData.HoldEmpIDArr[lvwUsers.FocusedItem.Index];
                //MessageBox.Show(StoreData.HoldUpdateEmpID.ToString());
                _EdNewEmp.Text = "Edit Employee";
                _EdNewEmp.loadpositions();

                DataTable dtUp = new DataTable();
                MySqlDataAdapter daUp = new MySqlDataAdapter("SELECT E.empID, E.LastName, E.FirstName, E.MiddleInitial, E.HouseNo, E.StreetName, E.Barangay, E.City, E.NickName, E.EmailAdd, E.MobileNo, E.Birthday, E.Birthplace, E.Gender, E.CivilStat, E.Citizenship, E.Religion, E.Height, E.Weight, E.BloodType, E.DateHired, E.TIN, E.PhilHealth, E.SSSID, E.PAGIBIGID, E.ConPerLast, E.ConPerFirst, E.ConPersMI, E.ConPerMobNo, E.ConPersRelationship, E.ConPersHouseNo, E.ConPersStreetName, E.ConPersBarangay, E.ConPersCity, E.empStat, E.ResignationDate, P.PositionName, E.IDPic, contracttype, contractend  FROM emp AS E LEFT JOIN empposition AS P ON E.positionID=P.positionID WHERE E.empID=" + StoreData.HoldUpdateEmpID, msqlcon.con);
                daUp.Fill(dtUp);
                _EdNewEmp.txtFN.Text = dtUp.Rows[0][2].ToString();
                _EdNewEmp.txtLN.Text = dtUp.Rows[0][1].ToString();
                _EdNewEmp.txtMI.Text = dtUp.Rows[0][3].ToString();
                _EdNewEmp.txtHouseNum.Text  = dtUp.Rows[0][4].ToString();
                _EdNewEmp.txtStreetName.Text = dtUp.Rows[0][5].ToString();
                _EdNewEmp.txtBarangay.Text = dtUp.Rows[0][6].ToString();
                _EdNewEmp.txtCity.Text = dtUp.Rows[0][7].ToString();
                _EdNewEmp.txtNick.Text = dtUp.Rows[0][8].ToString();
                _EdNewEmp.txtEmail.Text = dtUp.Rows[0][9].ToString();
                _EdNewEmp.txtMobile.Text = dtUp.Rows[0][10].ToString();
                _EdNewEmp.dtpDOB.Value = Convert.ToDateTime(dtUp.Rows[0][11]);
                _EdNewEmp.txtBirthplace.Text = dtUp.Rows[0][12].ToString();
                _EdNewEmp.cboGender.Text = dtUp.Rows[0][13].ToString();
                _EdNewEmp.cboCivStatus.Text = dtUp.Rows[0][14].ToString();
                _EdNewEmp.txtCitizenship.Text = dtUp.Rows[0][15].ToString();
                _EdNewEmp.txtReligion.Text = dtUp.Rows[0][16].ToString();
                _EdNewEmp.txtHeight.Text = dtUp.Rows[0][17].ToString();
                _EdNewEmp.txtWeight.Text = dtUp.Rows[0][18].ToString();
                _EdNewEmp.cboBloodType.Text = dtUp.Rows[0][19].ToString();
                _EdNewEmp.msktxtTIN.Text = dtUp.Rows[0][21].ToString();
                _EdNewEmp.msktxtPhilHealth.Text = dtUp.Rows[0][22].ToString();
                _EdNewEmp.msktxtSSS.Text = dtUp.Rows[0][23].ToString();
                _EdNewEmp.msktxtPAGIBIG.Text = dtUp.Rows[0][24].ToString();
                _EdNewEmp.txtEmLN.Text = dtUp.Rows[0][25].ToString();
                _EdNewEmp.txtEmFN.Text = dtUp.Rows[0][26].ToString();
                _EdNewEmp.txtEmMI.Text = dtUp.Rows[0][27].ToString();
                _EdNewEmp.txtEmMob.Text= dtUp.Rows[0][28].ToString();
                _EdNewEmp.txtEmRelationship.Text = dtUp.Rows[0][29].ToString();
                _EdNewEmp.txtEmHouseNum.Text = dtUp.Rows[0][30].ToString();
                _EdNewEmp.txtEmStreet.Text = dtUp.Rows[0][31].ToString();
                _EdNewEmp.txtEmBarangay.Text = dtUp.Rows[0][32].ToString();
                _EdNewEmp.txtEmCity.Text = dtUp.Rows[0][33].ToString();
                _EdNewEmp.cboPosition.Text = dtUp.Rows[0][36].ToString();
                _EdNewEmp.cboContractType.Text = dtUp.Rows[0][38].ToString();
                try
                {
                    _EdNewEmp.dtpContractEnd.Value = Convert.ToDateTime(dtUp.Rows[0][39]);
                    _EdNewEmp.dtpContractEnd.Visible = true;
                    _EdNewEmp.lblContractEnd.Visible = true;
                   
                }
                catch
                {
                    _EdNewEmp.lblContractEnd.Visible = false;
                    _EdNewEmp.dtpContractEnd.Visible = false;
                }
                
                byte[] bits = new byte[0];
                bits = (byte[])dtUp.Rows[0][37];
                MemoryStream ms = new MemoryStream(bits);
                _EdNewEmp.picID.BackgroundImage = Image.FromStream(ms);
                _EdNewEmp.enableAll();
                _EdNewEmp.txtBirthplace.Enabled = false;
                _EdNewEmp.txtFN.Enabled = false;
                _EdNewEmp.txtLN.Enabled = false;
                _EdNewEmp.txtMI.Enabled = false;
                _EdNewEmp.txtNick.Enabled = false;
                _EdNewEmp.dtpDOB.Enabled = false;
                

                _EdNewEmp.StartPosition = FormStartPosition.CenterScreen;
                _EdNewEmp.ShowDialog();
            }
        }

        private void btnOB_Click(object sender, EventArgs e)
        {
            frmOfficialBusiness frmob = new frmOfficialBusiness();
            frmob.StartPosition = FormStartPosition.CenterScreen;
            frmob.ShowDialog();
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            frmResignedList resList = new frmResignedList();
            resList.StartPosition = FormStartPosition.CenterScreen;
            resList.ShowDialog();
        }

        private void btnResign_Click(object sender, EventArgs e)
        {
            if (lvwUsers.SelectedItems.Count > 0)
            {
                CheckOpen.cons();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT empID, LastName, FirstName, MiddleInitial FROM emp WHERE empID=" + StoreData.HoldEmpIDArr[lvwUsers.FocusedItem.Index], msqlcon.con);
                da.Fill(dt);
                StoreData.HoldEmpID = StoreData.HoldEmpIDArr[lvwUsers.FocusedItem.Index];
                
                //frmResignation frmRes = new frmResignation();
                _ResEmp.txtID.Text = StoreData.HoldEmpIDArr[lvwUsers.FocusedItem.Index].ToString();
                _ResEmp.txtName.Text = dt.Rows[0][1].ToString() + ", " + dt.Rows[0][2].ToString() + " " + dt.Rows[0][3].ToString() + ".";
                _ResEmp.txtReason.Text = "";
                _ResEmp.StartPosition = FormStartPosition.CenterScreen;
                _ResEmp.ShowDialog();
            }
        }
    }
}
