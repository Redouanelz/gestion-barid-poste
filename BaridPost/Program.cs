using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BaridPost
{
    static class Program
    {
        public static SqlConnection cnx = new SqlConnection(@"Data Source=.;Initial Catalog=BaridPost;Integrated Security=True");
        public static int ID_Client;
        public static int ID_Client_toUpdate;
        public static int ID_Contrat_toUpdate;
        public static int ID_Agent;
        public static string LoginAgent;
        public static int ID_DernierClient;
        public static string Profile_Agent;
        public static SqlDataAdapter adapter;

        // TABLES
        public static DataSet ds = new DataSet();
        public static DataSet dsBaridPost = new DataSet();         
        public static DataTable dt_Agence = new DataTable();
        public static DataTable dt_Agent = new DataTable();
        public static DataTable dt_InformationsAbonnées = new DataTable();
        public static DataTable dt_Benificiers = new DataTable();
        public static DataTable dt_AncienneAdresse = new DataTable();
        public static DataTable dt_NouvelleAdresse = new DataTable();
        public static DataTable dt_Contrat = new DataTable();
        public static DataTable dt_Centre = new DataTable();
        public static DataTable dt_CentreAgence = new DataTable();
        // DATASETS 
        public static DataSet ds_Agence = new DataSet();
        public static DataSet ds_Agent = new DataSet();
        public static DataSet ds_InformationsAbonnées = new DataSet();
        public static DataSet ds_Benificiers = new DataSet();
        public static DataSet ds_AncienneAdresse = new DataSet();
        public static DataSet ds_NouvelleAdresse = new DataSet();
        public static DataSet ds_Contrat = new DataSet();
        public static DataSet ds_Centre = new DataSet();
        public static DataSet ds_CentreAgence = new DataSet();
        // ADAPTERS
        public static SqlDataAdapter da_Agence ;
        public static SqlDataAdapter da_Agent ;
        public static SqlDataAdapter da_InformationsAbonnées ;
        public static SqlDataAdapter da_Benificiers ;
        public static SqlDataAdapter da_AncienneAdresse;
        public static SqlDataAdapter da_NouvelleAdresse;
        public static SqlDataAdapter da_Contrat;
        public static SqlDataAdapter da_Centre;
        public static SqlDataAdapter da_CentreAgence;
     
        //
        public static SqlDataAdapter daBéneficiaire;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
