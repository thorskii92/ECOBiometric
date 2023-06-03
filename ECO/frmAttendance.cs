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
    public partial class frmAttendance : Form
    {
        List<int> empIDHold;
        public frmAttendance()
        {
            InitializeComponent();
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            loadattendance(DateTime.Now.Date);
        }

        public void loadattendance(DateTime det)
        {
            //det.ToShortDateString();
            lblDate.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            CheckOpen.cons();
            DataTable dtA = new DataTable();
            MySqlDataAdapter daA = new MySqlDataAdapter("SELECT empID, LastName, FirstName, MiddleInitial FROM emp", msqlcon.con);
            daA.Fill(dtA);
            lvwAttendance.Items.Clear();
            empIDHold = new List<int>();
            if (dtA.Rows.Count > 0)
            {
                for (int x = 0; x <= dtA.Rows.Count - 1; x++)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.Text = dtA.Rows[x][0].ToString();
                    empIDHold.Add((int)dtA.Rows[x][0]);
                    lst.SubItems.Add(dtA.Rows[x][1].ToString() + ", " + dtA.Rows[x][2].ToString() + " " + dtA.Rows[x][1].ToString() + ".");
                    DataTable dtAt = new DataTable();
                    MySqlDataAdapter daAt = new MySqlDataAdapter("SELECT TimeIn1, TimeOut1, TimeIn2, TimeOut2 FROM attendance WHERE empID=" + dtA.Rows[x][0].ToString() + " AND datein=current_date()", msqlcon.con);
                    daAt.Fill(dtAt);
                    if (dtAt.Rows.Count > 0)
                    {
                        lst.SubItems.Add(dtAt.Rows[0][0].ToString());
                        lst.SubItems.Add(dtAt.Rows[0][1].ToString());
                        lst.SubItems.Add(dtAt.Rows[0][2].ToString());
                        lst.SubItems.Add(dtAt.Rows[0][3].ToString());  
                    }
                    else
                    {
                        lst.SubItems.Add("");
                        lst.SubItems.Add("");
                        lst.SubItems.Add("");
                        lst.SubItems.Add("");
                    }

                    lvwAttendance.Items.Add(lst);
                }
                
            }
           
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.Date.ToString("MMMM dd, yyyy");
            loadattendance(DateTime.Now.Date);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadattendance(DateTime.Now.Date);
        }

        private void btnCheckAttendance_Click(object sender, EventArgs e)
        {
            if (lvwAttendance.SelectedItems.Count > 0)
            {
                DataTable dt = new DataTable();
                CheckOpen.cons();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT empID, LastName, FirstName, MiddleInitial FROM emp WHERE empID=" + empIDHold[lvwAttendance.FocusedItem.Index] , msqlcon.con);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    frmCheckAttendance cAtt = new frmCheckAttendance();
                    cAtt.txtName.Text = dt.Rows[0][1].ToString() + ", " + dt.Rows[0][2].ToString() + " " + dt.Rows[0][3].ToString() + ".";
                    cAtt.txtID.Text = dt.Rows[0][0].ToString();
                    cAtt.StartPosition = FormStartPosition.CenterScreen;
                    cAtt.ShowDialog();
                }
            }
            
        }
    }
}
