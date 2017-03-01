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
    public partial class HistoriqueContrats : Form
    {
        public HistoriqueContrats()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        private void HistoriqueContrats_Load(object sender, EventArgs e)
        {
            Program.cnx.Open(); cmbIDClient.Items.Clear();
            SqlCommand cmd_ID = new SqlCommand("SELECT ID_Client FROM InformationsAbonnées", Program.cnx);
            SqlDataReader dr;
            dr = cmd_ID.ExecuteReader(); while (dr.Read()) { cmbIDClient.Items.Add(dr[0]); } dr.Close(); Program.cnx.Close();
        }

        private void cmbIDClient_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnRechercher_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Contrat WHERE ID_Client= " + cmbIDClient.Text, Program.cnx);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
        }

        private void btnAfficher_Click(object sender, EventArgs e)
        {
            Saisi AfficherContrat = new Saisi();
            AfficherContrat.Show();
        }
    }
}
