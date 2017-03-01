using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace BaridPost
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnSeConnecter_Click(object sender, EventArgs e)
        {
            bool ok = false;
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM AGENT",Program.cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
              
                if (dt.Rows[i][1].ToString() == txtLoginAgent.Text && dt.Rows[i][2].ToString() == txtPasswordAgent.Text)
                {                   
                    Program.ID_Agent = Convert.ToInt16( dt.Rows[i][0].ToString() );
                   // MessageBox.Show("ID_Agent Avant" + Program.ID_Agent);
                    Program.LoginAgent = txtLoginAgent.Text;
                    if(dt.Rows[i][4].ToString() == "Agent")
                    {
                        Program.Profile_Agent = "Agent";
                    }
                    if(dt.Rows[i]["Profile_Agent"].ToString() == "Controle")
                    {
                        Program.Profile_Agent = "Controle";
                    }
                    MenuOk Menu = new MenuOk();
                    this.Hide();
                    Menu.Show();
                    ok = true;  break;
                }

            }
            if (ok == false)
            {
                MessageBox.Show("Informations incorrecte.");
            }


        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
