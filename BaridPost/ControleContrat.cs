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
    public partial class ControleContrat : Form
    {
        public ControleContrat()
        {
            InitializeComponent();
        }

        public void loadcmb()
        { // Load Combobox
            Program.cnx.Open(); txtBenef_NumCIN.Items.Clear();
            SqlCommand cmd_ID = new SqlCommand("SELECT CIN_Benificiers FROM Benificiers WHERE ID_Client = " + Program.ID_Client_toUpdate, Program.cnx);
            SqlDataReader dr;
            dr = cmd_ID.ExecuteReader(); while (dr.Read()) { txtBenef_NumCIN.Items.Add(dr[0]); } dr.Close(); Program.cnx.Close();
        }

        public void ShowBenef()
        {
                DataTable dt = new DataTable(); DataSet dsx = new DataSet(); dt.Clear(); dsx.Clear();
                Program.daBéneficiaire = new SqlDataAdapter("SELECT CIN_Benificiers as CIN,Civilité,Nom,Prenom,DateValiditéCIN,Email FROM Benificiers WHERE ID_Client = " + Program.ID_Client_toUpdate, Program.cnx);
                Program.daBéneficiaire.MissingSchemaAction = MissingSchemaAction.Add;
                Program.daBéneficiaire.Fill(dsx); dt = dsx.Tables[0];
                DGAfficherBénéficiaire.DataSource = dt; DGAfficherBénéficiaire.Refresh();
         }
        private void ControleContrat_Load(object sender, EventArgs e)
        {           
            loadcmb();
            try
            {
                Program.dsBaridPost.EnforceConstraints = false;
                // LOAD
                // Agence
                Program.da_Agence = new SqlDataAdapter("SELECT * FROM Agence", Program.cnx);
                Program.da_Agence.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_Agence.Fill(Program.dsBaridPost, "Agence");
                Program.dt_Agence = Program.dsBaridPost.Tables["Agence"];
                // Agent
                Program.da_Agent = new SqlDataAdapter("SELECT * FROM Agent", Program.cnx);
                Program.da_Agent.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_Agent.Fill(Program.dsBaridPost, "Agent");
                Program.dt_Agent = Program.dsBaridPost.Tables["Agent"];
                // InformationsAbonnées
                Program.da_InformationsAbonnées = new SqlDataAdapter("SELECT * FROM InformationsAbonnées", Program.cnx);
                Program.da_InformationsAbonnées.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_InformationsAbonnées.Fill(Program.dsBaridPost, "InformationsAbonnées");
                Program.dt_InformationsAbonnées = Program.dsBaridPost.Tables["InformationsAbonnées"];
                // Benificiers
                Program.da_Benificiers = new SqlDataAdapter("SELECT * FROM Benificiers", Program.cnx);
                Program.da_Benificiers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_Benificiers.Fill(Program.dsBaridPost, "Benificiers");
                Program.dt_Benificiers = Program.dsBaridPost.Tables["Benificiers"];
                // AncienneAdresse
                Program.da_AncienneAdresse = new SqlDataAdapter("SELECT * FROM AncienneAdresse", Program.cnx);
                Program.da_AncienneAdresse.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_AncienneAdresse.Fill(Program.dsBaridPost, "AncienneAdresse");
                Program.dt_AncienneAdresse = Program.dsBaridPost.Tables["AncienneAdresse"];
                // NouvelleAdresse
                Program.da_NouvelleAdresse = new SqlDataAdapter("SELECT * FROM NouvelleAdresse", Program.cnx);
                Program.da_NouvelleAdresse.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_NouvelleAdresse.Fill(Program.dsBaridPost, "NouvelleAdresse");
                Program.dt_NouvelleAdresse = Program.dsBaridPost.Tables["NouvelleAdresse"];
                // Contrat
                Program.da_Contrat = new SqlDataAdapter("SELECT * FROM Contrat", Program.cnx);
                Program.da_Contrat.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_Contrat.Fill(Program.dsBaridPost, "Contrat");
                Program.dt_Contrat = Program.dsBaridPost.Tables["Contrat"];
                // Centre
                Program.da_Centre = new SqlDataAdapter("SELECT * FROM Centre", Program.cnx);
                Program.da_Centre.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_Centre.Fill(Program.dsBaridPost, "Centre");
                Program.dt_Centre = Program.dsBaridPost.Tables["Centre"];
                // CentreAgence
                Program.da_CentreAgence = new SqlDataAdapter("SELECT * FROM CentreAgence", Program.cnx);
                Program.da_CentreAgence.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_CentreAgence.Fill(Program.dsBaridPost, "CentreAgence");
                Program.dt_CentreAgence = Program.dsBaridPost.Tables["CentreAgence"];
                // END  

                // Load infos > into textboxs.
                // Informations Abonnées.
                Program.cnx.Open();
                SqlDataReader dr_InformationsAbonnées;
                SqlCommand cmd_InformationsAbonnées = new SqlCommand("SELECT * FROM InformationsAbonnées WHERE ID_Client = " + Program.ID_Client_toUpdate, Program.cnx);
                dr_InformationsAbonnées = cmd_InformationsAbonnées.ExecuteReader();
                while (dr_InformationsAbonnées.Read())
                {
                    txtNumPieceID.Text = dr_InformationsAbonnées["CIN"].ToString();
                    txtTypePieceID.Text = dr_InformationsAbonnées["TypeCIN"].ToString();
                    txtCivilité.Text = dr_InformationsAbonnées["Civilite"].ToString();
                    txtDateValiditéCIN.Text = dr_InformationsAbonnées["DateValiditeCIN"].ToString();
                    txtNom.Text = dr_InformationsAbonnées["Nom"].ToString();
                    txtPrenom.Text = dr_InformationsAbonnées["Prenom"].ToString();
                    txtEmail.Text = dr_InformationsAbonnées["Email"].ToString();
                    txtNumTel.Text = dr_InformationsAbonnées["NumTel"].ToString();
                }
                dr_InformationsAbonnées.Close();
                // Contrat
                SqlDataReader dr_Contrat;
                SqlCommand cmd_Contrat = new SqlCommand("SELECT * FROM Contrat WHERE ID_Client = " + Program.ID_Contrat_toUpdate, Program.cnx);
                dr_Contrat = cmd_Contrat.ExecuteReader();
                while (dr_Contrat.Read())
                {
                    // Informations Génerales                      
                    txtMontantAPaye.Text = dr_Contrat["MontantApaye"].ToString();
                    txtDurée.Text = dr_Contrat["Duree"].ToString();
                    txtDateDebut.Text = dr_Contrat["DateDebut"].ToString();
                    txtDateFin.Text = dr_Contrat["DateFin"].ToString();
                    // Code de Payement
                    if (dr_Contrat["EspeceCheque"].ToString() == "Espéce") { rEspéce.Checked = true; };
                    if (dr_Contrat["EspeceCheque"].ToString() == "Chéque") { rChéque.Checked = true; };
                    txtBanque.Text = dr_Contrat["Banque"].ToString();
                    txtNumCompte.Text = dr_Contrat["NCompte"].ToString();
                    txtNumChéque.Text = dr_Contrat["NCheque"].ToString();
                    //txtDateCreationContrat.Text = dr_Contrat["datecreation"].ToString();
                    //txtDateModificationContrat.Text = dr_Contrat["dateModification"].ToString();
                }
                dr_Contrat.Close();
                // Anncienne Adresse
                SqlDataReader dr_AncienneAdresse;
                SqlCommand cmd_AncienneAdresse = new SqlCommand("SELECT * FROM AncienneAdresse WHERE ID_Client = " + Program.ID_Client_toUpdate, Program.cnx);
                dr_AncienneAdresse = cmd_AncienneAdresse.ExecuteReader();
                while (dr_AncienneAdresse.Read())
                {
                    txtAn_Immeuble.Text = dr_AncienneAdresse["ImmeubleResidenceBatiment"].ToString();
                    txtAn_CodePostal.Text = dr_AncienneAdresse["CodePostal"].ToString();
                    txtAn_Ville.Text = dr_AncienneAdresse["VilleLocalite"].ToString();
                    txtAn_TypedeVoie.Text = dr_AncienneAdresse["TypeVoie"].ToString();
                    txtAn_Quartier.Text = dr_AncienneAdresse["Quartier"].ToString();
                    txtAn_NomVoie.Text = dr_AncienneAdresse["NomVoie"].ToString();
                    txtAn_Numero.Text = dr_AncienneAdresse["Numéro"].ToString();
                }
                dr_AncienneAdresse.Close();
                // Nouvelle Adresse
                SqlDataReader dr_NouvelleAdresse;
                SqlCommand cmd_NouvelleAdresse = new SqlCommand("SELECT * FROM NouvelleAdresse WHERE ID_Client = " + Program.ID_Client_toUpdate, Program.cnx);
                dr_NouvelleAdresse = cmd_NouvelleAdresse.ExecuteReader();
                while (dr_NouvelleAdresse.Read())
                {
                    txtNouv_Immeuble.Text = dr_NouvelleAdresse["ImmeubleResidenceBatiment"].ToString();
                    txtNouv_CodePostal.Text = dr_NouvelleAdresse["CodePostal"].ToString();
                    txtNouv_Ville.Text = dr_NouvelleAdresse["VilleLocalite"].ToString();
                    txtNouv_TypedeVoie.Text = dr_NouvelleAdresse["TypeVoie"].ToString();
                    txtNouv_Quartier.Text = dr_NouvelleAdresse["Quartier"].ToString();
                    txtNouv_NomVoie.Text = dr_NouvelleAdresse["NomVoie"].ToString();
                    txtNouv_Numero.Text = dr_NouvelleAdresse["Numéro"].ToString();
                }
                dr_NouvelleAdresse.Close();
                // Bénficiéres
                ShowBenef();

                Program.cnx.Close();   
            }
            catch (Exception ex) { MessageBox.Show("" + ex); }
        }





        private void txtListeIDClients_SelectedIndexChanged(object sender, EventArgs e)
        {

          
        }

        private void btnAjouter_InfoBénéficiaire_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_Benificiers);
                DataRow dar;
                dar = Program.dt_Benificiers.NewRow();
                //dar["ID_Benificier"] = auto increment
                dar["ID_Client"] = Program.ID_Client_toUpdate;
                dar["Civilité"] = txtBenef_Civilité.Text;
                dar["Nom"] = txtBenef_Nom.Text;
                dar["Prenom"] = txtBenef_Prenom.Text;
                dar["CIN_Benificiers"] = txtBenef_NumCIN.Text;
                dar["DateValiditéCIN"] = txtBenef_DateValiditéCIN.Text;
                dar["Email"] = txtBenef_Email.Text;
                Program.dt_Benificiers.Rows.Add(dar);
                Program.da_Benificiers.Update(Program.dt_Benificiers.Select("", "", DataViewRowState.Added));
                // Bénficiéres
                ShowBenef(); loadcmb();
            }
            catch { MessageBox.Show("Ajout Non Effectuer!"); }
        }

        private void btnSupprimer_Ben_Click(object sender, EventArgs e)
        {

            SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_Benificiers);
            try
            {
                int posx = -1;
                for (int i = 0; i < Program.dt_Benificiers.Rows.Count; i++)
                {
                    //MessageBox.Show("CIN_Benificiers : " + Program.dt_Benificiers.Rows[i]["CIN_Benificiers"].ToString() + " == " + txtBenef_NumCIN.Text);
                    if (Program.dt_Benificiers.Rows[i]["CIN_Benificiers"].ToString() == txtBenef_NumCIN.Text)
                    {
                        posx = i;
                        Program.dt_Benificiers.Rows[posx].Delete();

                        break;
                    }
                }
                Program.da_Benificiers.Update(Program.dt_Benificiers.Select("", "", DataViewRowState.Deleted));
            }
            catch { MessageBox.Show("Suppresion Non Effectuer!"); }
            // Bénficiéres
            ShowBenef(); loadcmb();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_Benificiers);
                int posx = -1;
                for (int i = 0; i < Program.dt_Benificiers.Rows.Count; i++)
                {
                    MessageBox.Show("CIN_Benificiers : " + Program.dt_Benificiers.Rows[i]["CIN_Benificiers"].ToString() + " == " + txtBenef_NumCIN.Text);
                    if (Program.dt_Benificiers.Rows[i]["CIN_Benificiers"].ToString() == txtBenef_NumCIN.Text)
                    {
                        posx = i;
                        break;
                    }
                }
                DataRow dar;
                dar = Program.dt_Benificiers.Rows[posx];
                dar.BeginEdit();
                dar["ID_Client"] = Program.ID_Client_toUpdate;
                dar["Civilité"] = txtBenef_Civilité.Text;
                dar["Nom"] = txtBenef_Nom.Text;
                dar["Prenom"] = txtBenef_Prenom.Text;
                //dar["CIN_Benificiers"] = txtBenef_NumCIN.Text;
                dar["DateValiditéCIN"] = txtBenef_DateValiditéCIN.Text;
                dar["Email"] = txtBenef_Email.Text;
                dar.EndEdit();
                Program.da_Benificiers.Update(Program.dt_Benificiers.Select("", "", DataViewRowState.ModifiedCurrent));
                // Bénficiéres
                ShowBenef(); loadcmb();
            }
            catch { MessageBox.Show("Modification Non Effectuer!"); }
            
        }
        
        // 
        int ID_AncienneAdresse ;   int ID_NouvelleAdresse;
        private void btnConfirmer_Click(object sender, EventArgs e)
        {
                     
            Program.cnx.Open();
            SqlCommand cmd2 = new SqlCommand("SELECT ID_AncienneAdresse FROM AncienneAdresse WHERE ID_Client = " + Program.ID_Client_toUpdate, Program.cnx);
            SqlDataReader dr2;
            dr2 = cmd2.ExecuteReader();
            while (dr2.Read()) { ID_AncienneAdresse = Convert.ToInt16(dr2[0]); }
            dr2.Close(); dr2.Close(); dr2.Close(); 
            SqlCommand cmd3 = new SqlCommand("SELECT ID_NouvelleAdresse FROM NouvelleAdresse WHERE ID_Client = " + Program.ID_Client_toUpdate, Program.cnx);
            SqlDataReader dr3;
            dr3 = cmd3.ExecuteReader();
            while (dr3.Read()) { ID_NouvelleAdresse = Convert.ToInt16(dr3[0]); }
            dr3.Close(); Program.cnx.Close();

            try
            {
                // AncienneAdresse
                SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_AncienneAdresse);
                DataRow dar;
                dar = Program.dt_AncienneAdresse.Rows.Find(ID_AncienneAdresse);
                dar.BeginEdit();
                //dar["ID_Client"] = Program.ID_Client_toUpdate;
                dar["ImmeubleResidenceBatiment"] = txtAn_Immeuble.Text;
                dar["CodePostal"] = txtAn_CodePostal.Text;
                dar["VilleLocalite"] = txtAn_Ville.Text;
                dar["TypeVoie"] = txtAn_TypedeVoie.Text;
                dar["Quartier"] = txtAn_Quartier.Text;
                dar["NomVoie"] = txtAn_NomVoie.Text;
                dar["Numéro"] = txtAn_Numero.Text;
                dar.EndEdit();
                Program.da_AncienneAdresse.Update(Program.dt_AncienneAdresse.Select("", "", DataViewRowState.ModifiedCurrent));
                // NouvelleAdresse
                SqlCommandBuilder cmb2 = new SqlCommandBuilder(Program.da_NouvelleAdresse);
                DataRow dar2;
                dar2 = Program.dt_NouvelleAdresse.Rows.Find(ID_NouvelleAdresse);
                dar2.BeginEdit();
               // dar2["ID_Client"] = Program.ID_Client_toUpdate;
                dar2["ImmeubleResidenceBatiment"] = txtNouv_Immeuble.Text;
                dar2["CodePostal"] = txtNouv_CodePostal.Text;
                dar2["VilleLocalite"] = txtNouv_Ville.Text;
                dar2["TypeVoie"] = txtNouv_TypedeVoie.Text;
                dar2["Quartier"] = txtNouv_Quartier.Text;
                dar2["NomVoie"] = txtNouv_NomVoie.Text;
                dar2["Numéro"] = txtNouv_Numero.Text;
                dar2.EndEdit();
                Program.da_NouvelleAdresse.Update(Program.dt_NouvelleAdresse.Select("", "", DataViewRowState.ModifiedCurrent));
                // Contrat
                SqlCommandBuilder cmb3 = new SqlCommandBuilder(Program.da_Contrat);
                DataRow dar3;
                // Informations Génerales
                dar3 = Program.dt_Contrat.Rows.Find(Program.ID_Contrat_toUpdate);
                dar3.BeginEdit();
                dar3["ID_Client"] = Program.ID_Client_toUpdate;
                dar3["MontantApaye"] = txtMontantAPaye.Text;
                dar3["Duree"] = txtDurée.Text;
                dar3["DateDebut"] = txtDateDebut.Text;
                dar3["DateFin"] = txtDateFin.Text;
                // Code de Payement
                if (rEspéce.Checked == true) { dar3["EspeceCheque"] = "Espéce"; };
                if (rChéque.Checked == true) { dar3["EspeceCheque"] = "Chéque"; };
                dar3["Banque"] = txtBanque.Text;
                dar3["NCompte"] = txtNumCompte.Text;
                if (rChéque.Checked) { dar3["NCheque"] = txtNumChéque.Text; };
                //dar3["ID_Agent"] = Program.ID_Agent;
                //dar3["dateModification"] = DateTime.Now;
                dar3["Profile_Agent"] = Program.Profile_Agent;
                dar3.EndEdit();
                Program.da_Contrat.Update(Program.dt_Contrat.Select("", "", DataViewRowState.ModifiedCurrent));
                MessageBox.Show("Contrat Bien Modifier");
                this.Close();
            }
            catch { MessageBox.Show("Contrat Non Modifier");  }
        }


    }
}
