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
    public partial class frmResignedList : Form
    {
        public frmResignedList()
        {
            InitializeComponent();
        }

        private void frmResignedList_Load(object sender, EventArgs e)
        {
            loadList();
        }

        public void loadList()
        {
            CheckOpen.cons();
            lvwRes.Items.Clear();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT R.*, E.LastName, E.FirstName, E.MiddleInitial FROM tblresiglist AS R LEFT JOIN emp AS E ON R.empID=E.empID", msqlcon.con);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.Text = dt.Rows[x][1].ToString();
                    lst.SubItems.Add(dt.Rows[x][6].ToString() + ", " + dt.Rows[x][7].ToString() + " " + dt.Rows[x][8].ToString() + ".");
                    lst.SubItems.Add(Convert.ToDateTime(dt.Rows[x][2]).ToString("MMMM dd, yyyy"));
                    lst.SubItems.Add(dt.Rows[x][3].ToString());
                    lvwRes.Items.Add(lst);
                }
            }
        }
    }
}
