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
    public partial class frmRequests : Form
    {
        public List<int> arrLID;
        private frmReviewRequest _RevReq;
        public frmRequests()
        {
            InitializeComponent();
            _RevReq = new frmReviewRequest(this);
        }

        private void frmRequests_Load(object sender, EventArgs e)
        {
            loadlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwRequests.SelectedItems.Count > 0)
            {
                 _RevReq.loadRequest(arrLID[lvwRequests.FocusedItem.Index]);
                _RevReq.StartPosition = FormStartPosition.CenterScreen;
                _RevReq.ShowDialog();
            }
        }

        public void loadlist()
        {
            CheckOpen.cons();
            DataTable dtReq = new DataTable();
            dtReq.Clear();
            MySqlDataAdapter daReq = new MySqlDataAdapter("SELECT L.leaveID, E.empID, E.LastName, E.FirstName, E.MiddleInitial, L.requestDate, L.LeaveFrom, L.LeaveTo, L.totalDays, L.leaveType, L.Purpose FROM leaves AS L LEFT JOIN emp AS E ON L.empID=E.empID WHERE RequestStatus='Pending'", msqlcon.con);
            daReq.Fill(dtReq);
            lvwRequests.Items.Clear();
            arrLID = new List<int>();
            arrLID.Clear();
            if (dtReq.Rows.Count > 0)
            {
                for (int x = 0; x <= dtReq.Rows.Count - 1; x++)
                {
                    arrLID.Add((int)dtReq.Rows[x][0]);
                    ListViewItem lst = new ListViewItem();
                    lst.Text = (x + 1).ToString();
                    lst.SubItems.Add(dtReq.Rows[x][2].ToString() + ", " + dtReq.Rows[x][3].ToString() + " " + dtReq.Rows[x][4].ToString() + ".");
                    lst.SubItems.Add(Convert.ToDateTime(dtReq.Rows[x][5]).ToString("MMMM dd, yyyy"));
                    lst.SubItems.Add(Convert.ToDateTime(dtReq.Rows[x][6]).ToString("MMMM dd, yyyy") + " to " + Convert.ToDateTime(dtReq.Rows[x][7]).ToString("MMMM dd, yyyy"));
                    lst.SubItems.Add(dtReq.Rows[x][8].ToString());
                    lst.SubItems.Add(dtReq.Rows[x][9].ToString());
                    lst.SubItems.Add(dtReq.Rows[x][10].ToString());
                    lvwRequests.Items.Add(lst);
                }
            }
        }
    }
}
