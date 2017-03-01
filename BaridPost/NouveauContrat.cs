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
    public partial class NouveauContrat : Form
    {
        public NouveauContrat()
        {
            InitializeComponent();
            lbl_ID_CLient.Text = "Client ID :" + Program.ID_Client;
        }   

        public void ShowBenf()
        {
                DataTable dt = new DataTable(); DataSet dsx = new DataSet(); dt.Clear(); dsx.Clear();
                Program.daBéneficiaire = new SqlDataAdapter("SELECT CIN_Benificiers as CIN,Civilité,Nom,Prenom,DateValiditéCIN,Email FROM Benificiers WHERE ID_Client = " + Program.ID_Client, Program.cnx);
                Program.daBéneficiaire.MissingSchemaAction = MissingSchemaAction.Add;
                Program.daBéneficiaire.Fill(dsx); dt = dsx.Tables[0];
                DGAfficherBénéficiaire.DataSource = dt; DGAfficherBénéficiaire.Refresh();   
        }

        public void LoadBenf()
        {
                // Load Combobox
                Program.cnx.Open(); txtBenef_NumCIN.Items.Clear();
                SqlCommand cmd_ID = new SqlCommand("SELECT CIN_Benificiers FROM Benificiers WHERE ID_Client = " + Program.ID_Client, Program.cnx);
                SqlDataReader dr;
                dr = cmd_ID.ExecuteReader();  while (dr.Read())  {   txtBenef_NumCIN.Items.Add(dr[0]); } dr.Close(); Program.cnx.Close();
        }

        private void NouveauContratRéexpidition_Load(object sender, EventArgs e)
        {
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
                Program.da_Agent.Fill(Program.dsBaridPost,"Agent");
                Program.dt_Agent = Program.dsBaridPost.Tables["Agent"];
                // InformationsAbonnées
                Program.da_InformationsAbonnées = new SqlDataAdapter("SELECT * FROM InformationsAbonnées", Program.cnx);
                Program.da_InformationsAbonnées.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_InformationsAbonnées.Fill(Program.dsBaridPost,"InformationsAbonnées");
                Program.dt_InformationsAbonnées = Program.dsBaridPost.Tables["InformationsAbonnées"];
                // Benificiers
                Program.da_Benificiers = new SqlDataAdapter("SELECT * FROM Benificiers", Program.cnx);
                Program.da_Benificiers.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_Benificiers.Fill(Program.dsBaridPost,"Benificiers");
                Program.dt_Benificiers = Program.dsBaridPost.Tables["Benificiers"];
                // AncienneAdresse
                Program.da_AncienneAdresse = new SqlDataAdapter("SELECT * FROM AncienneAdresse", Program.cnx);
                Program.da_AncienneAdresse.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_AncienneAdresse.Fill(Program.dsBaridPost,"AncienneAdresse");
                Program.dt_AncienneAdresse = Program.dsBaridPost.Tables["AncienneAdresse"];
                // NouvelleAdresse
                Program.da_NouvelleAdresse = new SqlDataAdapter("SELECT * FROM NouvelleAdresse", Program.cnx);
                Program.da_NouvelleAdresse.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_NouvelleAdresse.Fill(Program.dsBaridPost,"NouvelleAdresse");
                Program.dt_NouvelleAdresse = Program.dsBaridPost.Tables["NouvelleAdresse"];
                // Contrat
                Program.da_Contrat = new SqlDataAdapter("SELECT * FROM Contrat", Program.cnx);
                Program.da_Contrat.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_Contrat.Fill(Program.dsBaridPost,"Contrat");
                Program.dt_Contrat = Program.dsBaridPost.Tables["Contrat"];
                // Centre
                Program.da_Centre = new SqlDataAdapter("SELECT * FROM Centre", Program.cnx);
                Program.da_Centre.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_Centre.Fill(Program.dsBaridPost,"Centre");
                Program.dt_Centre = Program.dsBaridPost.Tables["Centre"];
                // CentreAgence
                Program.da_CentreAgence = new SqlDataAdapter("SELECT * FROM CentreAgence", Program.cnx);
                Program.da_CentreAgence.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                Program.da_CentreAgence.Fill(Program.dsBaridPost,"CentreAgence");
                Program.dt_CentreAgence = Program.dsBaridPost.Tables["CentreAgence"];
                // END  
                ShowBenf();
               
            }
            catch (Exception ex) { MessageBox.Show("" + ex); }
        }

        private void btnConfirmerInformationsAbonnées_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_InformationsAbonnées);
            // Informations de l'abonnées
            bool ok = false;
            try
            {
                DataRow dar;
                dar = Program.dt_InformationsAbonnées.NewRow();
                //dar[0] = Program.ID_Client;
                dar[1] = txtNumPieceID.Text;
                dar[2] = txtTypePieceID.Text;
                dar[3] = txtCivilité.Text;
                dar[4] = txtDateValiditéCIN.Text;
                dar[5] = txtNom.Text;
                dar[6] = txtPrenom.Text;
                dar[7] = txtEmail.Text;
                dar[8] = txtNumTel.Text;
                Program.dt_InformationsAbonnées.Rows.Add(dar);
                Program.da_InformationsAbonnées.Update(Program.dt_InformationsAbonnées.Select("", "", DataViewRowState.Added));
                ok = true;
            }
            catch (Exception ex) { MessageBox.Show("ERR" + ex); ok = false; }
            if (ok == true)
            {
                btnConfirmerInformationsAbonnées.Enabled = false;
                btnConfirmerInformationsAbonnées.Text = "Client Bien Confirmer";
                btnAjouter_InfoBénéficiaire.Enabled = true;
                btnAjouter_InfoBénéficiaire.Text = "Ajouter Bénéficiaries";
                btnModifier.Enabled = true;
                btnSupprimer_Ben.Enabled = true;
            }


        }

        private void btnAjouter_InfoBénéficiaire_Click(object sender, EventArgs e)
        {
                SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_Benificiers);
                DataRow dar;
                dar = Program.dt_Benificiers.NewRow();
                //dar["ID_Benificier"] = increment
                dar["ID_Client"] = Program.ID_Client;
                dar["Civilité"] = txtBenef_Civilité.Text;
                dar["Nom"] = txtBenef_Nom.Text;
                dar["Prenom"] = txtBenef_Prenom.Text;
                dar["CIN_Benificiers"] = txtBenef_NumCIN.Text;
                dar["DateValiditéCIN"] = txtBenef_DateValiditéCIN.Text;
                dar["Email"] = txtBenef_Email.Text;
                Program.dt_Benificiers.Rows.Add(dar);
                Program.da_Benificiers.Update(Program.dt_Benificiers.Select("", "", DataViewRowState.Added));
                ShowBenf(); LoadBenf();
        }
        private void btnSupprimer_Ben_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_Benificiers);
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
            
            ShowBenf();                
        }
        private void btnModifier_Click(object sender, EventArgs e)
        {
                SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_Benificiers);
                int posx = -1;
                for (int i = 0; i < Program.dt_Benificiers.Rows.Count; i++)
                {
                    //MessageBox.Show("i:" + i + " CIN_Benificiers : " + Program.dt_Benificiers.Rows[i]["CIN_Benificiers"].ToString() + " == " + txtBenef_NumCIN.Text);
                    if (Program.dt_Benificiers.Rows[i]["CIN_Benificiers"].ToString() == txtBenef_NumCIN.Text)
                    {
                        posx = i;
                        break;
                    }
                }
                DataRow dar;
                dar = Program.dt_Benificiers.Rows[posx];
                dar.BeginEdit();
                dar["ID_Client"] = Program.ID_Client;
                dar["Civilité"] = txtBenef_Civilité.Text;
                dar["Nom"] = txtBenef_Nom.Text;
                dar["Prenom"] = txtBenef_Prenom.Text;
                //dar["CIN_Benificiers"] = txtBenef_NumCIN.Text;
                dar["DateValiditéCIN"] = txtBenef_DateValiditéCIN.Text;
                dar["Email"] = txtBenef_Email.Text;
                dar.EndEdit();
                Program.da_Benificiers.Update(Program.dt_Benificiers.Select("", "", DataViewRowState.ModifiedCurrent));
                ShowBenf();            
        }
        
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            try
            {
                Program.cnx.Open();
                SqlCommand cmd_ID = new SqlCommand(" DELETE FROM InformationsAbonnées WHERE ID_Client = " + Program.ID_Client, Program.cnx);
                cmd_ID.ExecuteNonQuery();
                Program.cnx.Close();
                MessageBox.Show("Contrat Annuler");
            }
            catch { }
        }
        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            try
            {
                // AncienneAdresse
                SqlCommandBuilder cmb = new SqlCommandBuilder(Program.da_AncienneAdresse);
                DataRow dar;
                dar = Program.dt_AncienneAdresse.NewRow();
                dar["ID_Client"] = Program.ID_Client;
                dar["ImmeubleResidenceBatiment"] = txtAn_Immeuble.Text;
                dar["CodePostal"] = txtAn_CodePostal.Text;
                dar["VilleLocalite"] = txtAn_Ville.Text;
                dar["TypeVoie"] = txtAn_TypedeVoie.Text;
                dar["Quartier"] = txtAn_Quartier.Text;
                dar["NomVoie"] = txtAn_NomVoie.Text;
                dar["Numéro"] = txtAn_Numero.Text;
                Program.dt_AncienneAdresse.Rows.Add(dar);
                Program.da_AncienneAdresse.Update(Program.dt_AncienneAdresse.Select("", "", DataViewRowState.Added));
                // NouvelleAdresse
                SqlCommandBuilder cmb2 = new SqlCommandBuilder(Program.da_NouvelleAdresse);
                DataRow dar2;
                dar2 = Program.dt_NouvelleAdresse.NewRow();
                dar2["ID_Client"] = Program.ID_Client;
                dar2["ImmeubleResidenceBatiment"] = txtNouv_Immeuble.Text;
                dar2["CodePostal"] = txtNouv_CodePostal.Text;
                dar2["VilleLocalite"] = txtNouv_Ville.Text;
                dar2["TypeVoie"] = txtNouv_TypedeVoie.Text;
                dar2["Quartier"] = txtNouv_Quartier.Text;
                dar2["NomVoie"] = txtNouv_NomVoie.Text;
                dar2["Numéro"] = txtNouv_Numero.Text;
                Program.dt_NouvelleAdresse.Rows.Add(dar2);
                Program.da_NouvelleAdresse.Update(Program.dt_NouvelleAdresse.Select("", "", DataViewRowState.Added));
                // Contrat
                SqlCommandBuilder cmb3 = new SqlCommandBuilder(Program.da_Contrat);
                DataRow dar3;
                // Informations Génerales
                dar3 = Program.dt_Contrat.NewRow();
                dar3["ID_Client"] = Program.ID_Client;
                dar3["MontantApaye"] = txtMontantAPaye.Text;
                dar3["Duree"] = txtDurée.Text;
                dar3["DateDebut"] = txtDateDebut.Text;
                dar3["DateFin"] = txtDateFin.Text;
                // Code de Payement
                if (rEspéce.Checked) { dar3["EspeceCheque"] = "Espéce"; };
                if (rChéque.Checked) { dar3["EspeceCheque"] = "Chéque"; };
                dar3["Banque"] = txtBanque.Text;
                dar3["NCompte"] = txtNumCompte.Text;
                if (rChéque.Checked) { dar3["NCheque"] = txtNumChéque.Text; };
                dar3["ID_Agent"] = Program.ID_Agent;
                dar3["datecreation"] = DateTime.Now;

                Program.dt_Contrat.Rows.Add(dar3);
                Program.da_Contrat.Update(Program.dt_Contrat.Select("", "", DataViewRowState.Added));
                MessageBox.Show("Contrat Enregistrer");                
                btnConfirmer.Enabled = false;
            } catch {MessageBox.Show("Contrat Non Complet"); }

        }

        private void btnQuitter_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rEspéce_CheckedChanged(object sender, EventArgs e)
        {
            if (rEspéce.Checked == true)
            {
                txtBanque.Visible = false;
                txtNumChéque.Visible = false;
                txtNumCompte.Visible = false;
            }
            else
            {
                txtBanque.Visible = true;
                txtNumChéque.Visible = true;
                txtNumCompte.Visible = true;
            }
        }

        private void txtDurée_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 3  6  9  12 mois
            if (txtDurée.SelectedIndex == 1)
            {
                txtMontantAPaye.Text = "300";
            }
            if (txtDurée.SelectedIndex == 2)
            {
                txtMontantAPaye.Text = "600";
            }
            if (txtDurée.SelectedIndex == 3)
            {
                txtMontantAPaye.Text = "900";
            }
            if (txtDurée.SelectedIndex == 4)
            {
                txtMontantAPaye.Text = "1200";
            }
        }
        
    }
}
