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
    public partial class Saisi : Form
    {
        public Saisi()
        {
            InitializeComponent();
        }

        private void SaisirID_Client_Load(object sender, EventArgs e)
        {
            // Load Combobox
            Program.cnx.Open(); txtListeIDContrat.Items.Clear();
            SqlCommand cmd_ID = new SqlCommand("SELECT ID_Contrat FROM Contrat", Program.cnx);
            SqlDataReader dr;
            dr = cmd_ID.ExecuteReader(); while (dr.Read()) { txtListeIDContrat.Items.Add(dr[0]); } dr.Close(); dr.Close();  Program.cnx.Close();

        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            Program.cnx.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT ID_Client FROM Contrat WHERE ID_Contrat = " + txtListeIDContrat.Text, Program.cnx);
            SqlDataReader dr2;
            dr2 = cmd2.ExecuteReader();
            while (dr2.Read()) { Program.ID_Client_toUpdate = Convert.ToInt32(dr2[0]) ; }
           
            Program.ID_Contrat_toUpdate = Convert.ToInt32( txtListeIDContrat.Text ) ;
            MessageBox.Show("ID Contrat : " + Program.ID_Contrat_toUpdate + " ID Client : " + Program.ID_Client_toUpdate);
            dr2.Close(); 
            Program.cnx.Close();
            ControleContrat Contrat_toUpdate = new ControleContrat();
            Contrat_toUpdate.Show();



        }
    }
}
