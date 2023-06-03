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
    public partial class frmUserProfile : Form
    {
        public frmChangeUserDetails _uDetails;
        public frmUserProfile()
        {
            InitializeComponent();
            _uDetails = new frmChangeUserDetails(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            frmUserLogHistory loghistory = new frmUserLogHistory();
            loghistory.logload(StoreData.loggedID);
            loghistory.StartPosition = FormStartPosition.CenterParent;
            loghistory.ShowDialog();
        }

        private void frmUserProfile_Load(object sender, EventArgs e)
        {
            profileload();
        }

        public void profileload()
        {
            DataTable dtProf = new DataTable();
            MySqlDataAdapter daProf = new MySqlDataAdapter("SELECT FullName, UserName, UserType FROM user WHERE userID=" + StoreData.loggedID, msqlcon.con);
            daProf.Fill(dtProf);
            if (dtProf.Rows.Count > 0)
            {
                lblName.Text = dtProf.Rows[0][0].ToString();
                lblUserName.Text = dtProf.Rows[0][1].ToString();
                lblType.Text = dtProf.Rows[0][2].ToString();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            _uDetails.StartPosition = FormStartPosition.CenterScreen;
            _uDetails.txtCurPass.Text = "";
            _uDetails.txtNewPass.Text = "";
            _uDetails.txtRepPass.Text = "";
            _uDetails.txtUserName.Text = "";
            _uDetails.ShowDialog();
        }
    }
}
