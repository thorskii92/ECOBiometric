using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ECO
{
    public partial class frmBiometric : Form
    {
        private frmViewBiometric addBio;
        private frmUpdateBio upBio;
        public frmBiometric()
        {
            InitializeComponent();
            addBio = new frmViewBiometric();
            upBio = new frmUpdateBio(this);
        }

        public void LoadBio()
        {
            CheckOpen.cons();
            DataTable dt = new DataTable();
            MySqlDataAdapter ada = new MySqlDataAdapter("SELECT E.empID, E.LastName, E.FirstName, E.MiddleInitial, P.PositionName, if ((SELECT count(*) " + 
                                                        "FROM emp WHERE empID = E.empID) > 0, 'YES','NO') AS IsBio FROM emp AS E LEFT JOIN " + 
                                                        "empposition AS P ON E.positionID = P.positionID WHERE E.empstat='Employed'", msqlcon.con);
            ada.Fill(dt);
            lvwBio.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    ListViewItem lst = new ListViewItem();
                    lst.Text = dt.Rows[x][0].ToString();
                    lst.SubItems.Add(dt.Rows[x][1].ToString() + ", " + dt.Rows[x][2].ToString() + " " + dt.Rows[x][3].ToString() + ".");
                    lst.SubItems.Add(dt.Rows[x][4].ToString());
                    lst.SubItems.Add(dt.Rows[x][5].ToString());
                    lvwBio.Items.Add(lst);
                }
            }
        }

        private void btnAddBio_Click(object sender, EventArgs e)
        {
            if (lvwBio.SelectedItems.Count > 0)
                {
                StoreData.selectBioHold = Convert.ToInt32 ( lvwBio.FocusedItem.Text );
                DataTable dtUp = new DataTable ();
                MySqlDataAdapter ada = new MySqlDataAdapter ( "SELECT E.empID, E.LastName, E.FirstName, E.MiddleInitial, P.PositionName  " +
                                                              "FROM emp AS E LEFT JOIN empposition AS P ON E.positionID=P.positionID WHERE E.empID = " + lvwBio.FocusedItem.Text, msqlcon.con );
                ada.Fill ( dtUp );
                addBio.lblEmpID.Text = dtUp.Rows[0][0].ToString ();
                addBio.lblName.Text = dtUp.Rows[0][1].ToString () + ", " + dtUp.Rows[0][2].ToString () + " " + dtUp.Rows[0][3].ToString() + ".";
                //addBio.lblPosition.Text = dtUp.Rows[0][4].ToString ();
                addBio.loadBio(Convert.ToInt32( dtUp.Rows[0][0]));
                addBio.StartPosition = FormStartPosition.CenterScreen;
                addBio.ShowDialog ();
                }
            }

        private void frmBiometric_Load(object sender, EventArgs e)
        {
            LoadBio();
        }
        private void btnUpdateBio_Click(object sender, EventArgs e)
        {
              if (lvwBio.SelectedItems.Count > 0)
                {
                    StoreData.selectBioHold = Convert.ToInt32 ( lvwBio.FocusedItem.Text );
                    DataTable dtUp = new DataTable ();
                    MySqlDataAdapter ada = new MySqlDataAdapter ( "SELECT E.empID, E.LastName, E.FirstName, E.MiddleInitial, P.PositionName FROM emp AS E LEFT JOIN " +
                                                                  "empposition AS P ON E.positionID = P.positionID WHERE E.empID = " + lvwBio.FocusedItem.Text, msqlcon.con );
                    ada.Fill ( dtUp );
                    upBio.lblEmpID.Text = dtUp.Rows[0][0].ToString ();
                    upBio.lblName.Text = dtUp.Rows[0][1].ToString () + ", " + dtUp.Rows[0][2].ToString () + " " + dtUp.Rows[0][3].ToString() + ".";
                    upBio.lblPosition.Text = dtUp.Rows[0][4].ToString ();
                    upBio.StartPosition = FormStartPosition.CenterScreen;
                    upBio.ShowDialog ();
                    //this.Dispose ();
                 }
         }

        private void lvwBio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (lvwBio.SelectedItems.Count > 0)
                {
                    btnAddBio.Visible = true;
                    //btnUpdateBio.Visible = true;
                }
                else
                {
                    btnAddBio.Visible = false;
                    //btnUpdateBio.Visible = false;
                }
            }
            catch
            {
                
            }
        }

        private void txtSearch_Enter (object sender, EventArgs e)
            {
                this.AcceptButton = btnSearch;
            }

        private void btnSearch_Click (object sender, EventArgs e)
            {
                if(txtSearch.Text != "")
                    {
                        DataTable dt = new DataTable ();
                        MySqlDataAdapter ada = new MySqlDataAdapter ( "SELECT E.empID, E.LastName, E.FirstName, E.MiddleInitial, P.PositionName, if ((SELECT count(*) " +
                                                                      "FROM biometrics WHERE empID = E.empID) > 0, 'YES','NO') AS IsBio FROM emp AS E LEFT JOIN " +
                                                                      "empposition AS P ON E.positionID = P.positionID WHERE LastName LIKE '%" + txtSearch.Text + "%' OR " +
                                                                      "FirstName LIKE '%" + txtSearch.Text + "%' OR empID = '" + txtSearch.Text + "'", msqlcon.con );
                        ada.Fill ( dt );
                        lvwBio.Items.Clear ();

                        if (dt.Rows.Count > 0)
                            {
                                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                                    {
                                        ListViewItem lst = new ListViewItem ();
                                        lst.Text = dt.Rows[x][0].ToString ();
                                        lst.SubItems.Add ( dt.Rows[x][1].ToString () + " " + dt.Rows[x][2].ToString () + " " + dt.Rows[x][3].ToString () );
                                        lst.SubItems.Add ( dt.Rows[x][4].ToString () );
                                        lst.SubItems.Add ( dt.Rows[x][5].ToString () );
                                        lvwBio.Items.Add ( lst );
                                    }
                            }
                    }
                else
                    {
                        MessageBox.Show ( "Data not found.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    }
            }
        }
}
