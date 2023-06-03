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
    public partial class frmUserLogHistory : Form
    {
        public frmUserLogHistory()
        {
            InitializeComponent();
        }

        private void frmUserLogHistory_Load(object sender, EventArgs e)
        {

        }

        public void logload(int uID)
        {
            CheckOpen.cons();
            DataTable dtLogs = new DataTable();
            dtLogs.Clear();
            MySqlDataAdapter daLogs = new MySqlDataAdapter("SELECT * FROM userlog WHERE uID=" + uID, msqlcon.con);
            daLogs.Fill(dtLogs);
            lvwLog.Items.Clear();
            if (dtLogs.Rows.Count > 0)
            {
                int x = 0;
                for (x=0; x < dtLogs.Rows.Count - 1; x++)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.Text = Convert.ToDateTime(dtLogs.Rows[x][2]).ToString("MMMM dd, yyyy");
                    lst.SubItems.Add(dtLogs.Rows[x][3].ToString());
                    lst.SubItems.Add(dtLogs.Rows[x][4].ToString());
                    lvwLog.Items.Add(lst);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
