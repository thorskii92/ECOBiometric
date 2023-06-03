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
    public partial class frmOfficialBusiness : Form
    {
        List<int> arrOB;
        private frmBookOB _BookOB;
        public frmOfficialBusiness()
        {
            InitializeComponent();
            _BookOB = new frmBookOB(this);
        }

        private void frmOfficialBusiness_Load(object sender, EventArgs e)
        {
            loadOB();
        }

        public void loadOB()
        {
            arrOB = new List<int>();
            arrOB.Clear();
            lvwOB.Items.Clear();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT O.empID, E.LastName, E.FirstName, E.MiddleInitial, O.DateFrom, O.DateTo, O.Destination, O.obID FROM officialbusiness AS O LEFT JOIN emp AS E ON O.empID=E.empID", msqlcon.con);
            da.Fill(dt);     
            if (dt.Rows.Count > 0)
            {
                for (int x=0; x <= dt.Rows.Count -1; x++)
                {
                    ListViewItem lst = new ListViewItem();
                    arrOB.Add((int)dt.Rows[x][7]);
                    lst.Text = dt.Rows[x][1].ToString() + ", " + dt.Rows[x][2].ToString() + " " + dt.Rows[x][3].ToString() + ". ";
                    lst.SubItems.Add(Convert.ToDateTime(dt.Rows[x][4]).ToString("yyyy-MM-dd"));
                    lst.SubItems.Add(Convert.ToDateTime(dt.Rows[x][5]).ToString("yyyy-MM-dd"));
                    lst.SubItems.Add(dt.Rows[x][6].ToString());
                    lvwOB.Items.Add(lst);
                }
            }
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            _BookOB.StartPosition = FormStartPosition.CenterScreen;
            _BookOB.cboNames.Enabled = true;
            _BookOB.loadnames();
            _BookOB.txtDestination.Text = "";
            _BookOB.txtID.Text = "";
            _BookOB.Text = "Book OB";
            _BookOB.ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (lvwOB.SelectedItems.Count > 0)
            {
                CheckOpen.cons();
                _BookOB.loadnames();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT O.obID, O.empID, E.LastName, E.FirstName, E.MiddleInitial, O.DateFrom, O.DateTo, O.Destination FROM officialbusiness AS O LEFT JOIN emp AS E ON O.empID=E.empID WHERE O.obID=" + arrOB[lvwOB.FocusedItem.Index], msqlcon.con);
                da.Fill(dt);
                _BookOB.cboNames.Text = dt.Rows[0][2].ToString() + ", " + dt.Rows[0][3].ToString() + " " + dt.Rows[0][4].ToString() + ". ";
                _BookOB.cboNames.Enabled = false;
                _BookOB.txtID.Text = dt.Rows[0][1].ToString();
                _BookOB.dtpFrom.Value = Convert.ToDateTime(dt.Rows[0][5]);
                _BookOB.dtpTo.Value = Convert.ToDateTime(dt.Rows[0][6]);
                _BookOB.Text = "Modify OB";
                _BookOB.txtDestination.Text = dt.Rows[0][7].ToString();
                _BookOB.StartPosition = FormStartPosition.CenterScreen;
                _BookOB.ShowDialog();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvwOB.SelectedItems.Count > 0)
            { 
                if (MessageBox.Show("Remove Selected OB?", "Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    CheckOpen.cons();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM officialbusiness WHERE obID=" + arrOB[lvwOB.FocusedItem.Index], msqlcon.con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("OB has been removed", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadOB();
                }
            }
        }
    }
}
