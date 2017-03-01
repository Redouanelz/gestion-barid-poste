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
    public partial class MenuOk : Form
    {
        public MenuOk()
        {
            InitializeComponent();
            lblNomAgent.Text = "Bonjour, "+ Program.LoginAgent;
        }

        private void MenuOk_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM InformationsAbonnées", Program.cnx);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int last = dt.Rows.Count-1;
            Program.ID_DernierClient = Convert.ToInt16( dt.Rows[last][0]);
            Program.ID_Client = Program.ID_DernierClient + 1;
            if (Program.Profile_Agent == "Agent")
            {
                btnControle.Visible = false;
            }
            if (Program.Profile_Agent == "Controle")
            {

            }
        }

        private void btnNouveauContratRéexpidition_Click(object sender, EventArgs e)
        {
            NouveauContrat Contrat = new NouveauContrat();          
            Contrat.Show();
       
        }

        private void btnControle_Click(object sender, EventArgs e)
        {
            Saisi Saisi = new Saisi();           
            Saisi.Show();
        }

        private void btnHistoriqueContrat_Click(object sender, EventArgs e)
        {
            HistoriqueContrats HC = new HistoriqueContrats();
            HC.Show();
        }
    }
}
