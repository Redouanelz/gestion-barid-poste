namespace BaridPost
{
    partial class MenuOk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNouveauContratRéexpidition = new System.Windows.Forms.Button();
            this.lblNomAgent = new System.Windows.Forms.Label();
            this.lblDernierClient = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHistoriqueContrat = new System.Windows.Forms.Button();
            this.btnControle = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNouveauContratRéexpidition
            // 
            this.btnNouveauContratRéexpidition.Location = new System.Drawing.Point(114, 180);
            this.btnNouveauContratRéexpidition.Name = "btnNouveauContratRéexpidition";
            this.btnNouveauContratRéexpidition.Size = new System.Drawing.Size(189, 51);
            this.btnNouveauContratRéexpidition.TabIndex = 0;
            this.btnNouveauContratRéexpidition.Text = "Nouveau Contrat Réexpidition";
            this.btnNouveauContratRéexpidition.UseVisualStyleBackColor = true;
            this.btnNouveauContratRéexpidition.Click += new System.EventHandler(this.btnNouveauContratRéexpidition_Click);
            // 
            // lblNomAgent
            // 
            this.lblNomAgent.AutoSize = true;
            this.lblNomAgent.Location = new System.Drawing.Point(12, 122);
            this.lblNomAgent.Name = "lblNomAgent";
            this.lblNomAgent.Size = new System.Drawing.Size(13, 13);
            this.lblNomAgent.TabIndex = 1;
            this.lblNomAgent.Text = "+";
            // 
            // lblDernierClient
            // 
            this.lblDernierClient.AutoSize = true;
            this.lblDernierClient.Location = new System.Drawing.Point(12, 145);
            this.lblDernierClient.Name = "lblDernierClient";
            this.lblDernierClient.Size = new System.Drawing.Size(13, 13);
            this.lblDernierClient.TabIndex = 2;
            this.lblDernierClient.Text = "+";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "MENU";
            // 
            // btnHistoriqueContrat
            // 
            this.btnHistoriqueContrat.Location = new System.Drawing.Point(114, 294);
            this.btnHistoriqueContrat.Name = "btnHistoriqueContrat";
            this.btnHistoriqueContrat.Size = new System.Drawing.Size(189, 51);
            this.btnHistoriqueContrat.TabIndex = 6;
            this.btnHistoriqueContrat.Text = "Historique des Contrats";
            this.btnHistoriqueContrat.UseVisualStyleBackColor = true;
            this.btnHistoriqueContrat.Click += new System.EventHandler(this.btnHistoriqueContrat_Click);
            // 
            // btnControle
            // 
            this.btnControle.Location = new System.Drawing.Point(114, 237);
            this.btnControle.Name = "btnControle";
            this.btnControle.Size = new System.Drawing.Size(189, 51);
            this.btnControle.TabIndex = 7;
            this.btnControle.Text = "Controle des Contrats";
            this.btnControle.UseVisualStyleBackColor = true;
            this.btnControle.Click += new System.EventHandler(this.btnControle_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BaridPost.Properties.Resources.BaridPost;
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 119);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MenuOk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(434, 414);
            this.Controls.Add(this.btnControle);
            this.Controls.Add(this.btnHistoriqueContrat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblDernierClient);
            this.Controls.Add(this.lblNomAgent);
            this.Controls.Add(this.btnNouveauContratRéexpidition);
            this.Name = "MenuOk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.MenuOk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNouveauContratRéexpidition;
        private System.Windows.Forms.Label lblNomAgent;
        private System.Windows.Forms.Label lblDernierClient;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHistoriqueContrat;
        private System.Windows.Forms.Button btnControle;
    }
}