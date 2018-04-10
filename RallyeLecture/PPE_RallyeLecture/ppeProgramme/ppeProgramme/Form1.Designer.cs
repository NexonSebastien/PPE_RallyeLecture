namespace ppeProgramme
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRepertoire = new System.Windows.Forms.Label();
            this.lblFichier = new System.Windows.Forms.Label();
            this.clbFichier = new System.Windows.Forms.CheckedListBox();
            this.lblClasse = new System.Windows.Forms.Label();
            this.cbClasse = new System.Windows.Forms.ComboBox();
            this.cbSupression = new System.Windows.Forms.CheckBox();
            this.btnLancer = new System.Windows.Forms.Button();
            this.tbParcourir = new System.Windows.Forms.TextBox();
            this.btnParcourir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblRepertoire
            // 
            this.lblRepertoire.AutoSize = true;
            this.lblRepertoire.Location = new System.Drawing.Point(25, 22);
            this.lblRepertoire.Name = "lblRepertoire";
            this.lblRepertoire.Size = new System.Drawing.Size(121, 13);
            this.lblRepertoire.TabIndex = 0;
            this.lblRepertoire.Text = "Répertoire des fichiers : ";
            // 
            // lblFichier
            // 
            this.lblFichier.AutoSize = true;
            this.lblFichier.Location = new System.Drawing.Point(25, 47);
            this.lblFichier.Name = "lblFichier";
            this.lblFichier.Size = new System.Drawing.Size(111, 13);
            this.lblFichier.TabIndex = 2;
            this.lblFichier.Text = "Fichier csv à intégrer :";
            // 
            // clbFichier
            // 
            this.clbFichier.FormattingEnabled = true;
            this.clbFichier.Location = new System.Drawing.Point(171, 47);
            this.clbFichier.Name = "clbFichier";
            this.clbFichier.Size = new System.Drawing.Size(252, 94);
            this.clbFichier.TabIndex = 3;
            // 
            // lblClasse
            // 
            this.lblClasse.AutoSize = true;
            this.lblClasse.Location = new System.Drawing.Point(25, 159);
            this.lblClasse.Name = "lblClasse";
            this.lblClasse.Size = new System.Drawing.Size(44, 13);
            this.lblClasse.TabIndex = 4;
            this.lblClasse.Text = "Classe :";
            // 
            // cbClasse
            // 
            this.cbClasse.FormattingEnabled = true;
            this.cbClasse.Location = new System.Drawing.Point(171, 151);
            this.cbClasse.Name = "cbClasse";
            this.cbClasse.Size = new System.Drawing.Size(121, 21);
            this.cbClasse.TabIndex = 5;
            // 
            // cbSupression
            // 
            this.cbSupression.AutoSize = true;
            this.cbSupression.Location = new System.Drawing.Point(28, 178);
            this.cbSupression.Name = "cbSupression";
            this.cbSupression.Size = new System.Drawing.Size(313, 17);
            this.cbSupression.TabIndex = 6;
            this.cbSupression.Text = "Suppression de tous les élèves de la classe avant intégration";
            this.cbSupression.UseVisualStyleBackColor = true;
            // 
            // btnLancer
            // 
            this.btnLancer.Location = new System.Drawing.Point(162, 227);
            this.btnLancer.Name = "btnLancer";
            this.btnLancer.Size = new System.Drawing.Size(106, 23);
            this.btnLancer.TabIndex = 7;
            this.btnLancer.Text = "Lancer l\'intégration";
            this.btnLancer.UseVisualStyleBackColor = true;
            this.btnLancer.Click += new System.EventHandler(this.btnLancer_Click);
            // 
            // tbParcourir
            // 
            this.tbParcourir.Location = new System.Drawing.Point(171, 15);
            this.tbParcourir.Name = "tbParcourir";
            this.tbParcourir.Size = new System.Drawing.Size(100, 20);
            this.tbParcourir.TabIndex = 8;
            // 
            // btnParcourir
            // 
            this.btnParcourir.Location = new System.Drawing.Point(308, 15);
            this.btnParcourir.Name = "btnParcourir";
            this.btnParcourir.Size = new System.Drawing.Size(57, 20);
            this.btnParcourir.TabIndex = 9;
            this.btnParcourir.Text = "Parcourir";
            this.btnParcourir.UseVisualStyleBackColor = true;
            this.btnParcourir.Click += new System.EventHandler(this.btnParcourir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 262);
            this.Controls.Add(this.btnParcourir);
            this.Controls.Add(this.tbParcourir);
            this.Controls.Add(this.btnLancer);
            this.Controls.Add(this.cbSupression);
            this.Controls.Add(this.cbClasse);
            this.Controls.Add(this.lblClasse);
            this.Controls.Add(this.clbFichier);
            this.Controls.Add(this.lblFichier);
            this.Controls.Add(this.lblRepertoire);
            this.Name = "Form1";
            this.Text = "Alimentation de la base de données : Nouvelle classe";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRepertoire;
        private System.Windows.Forms.Label lblFichier;
        private System.Windows.Forms.CheckedListBox clbFichier;
        private System.Windows.Forms.Label lblClasse;
        private System.Windows.Forms.ComboBox cbClasse;
        private System.Windows.Forms.CheckBox cbSupression;
        private System.Windows.Forms.Button btnLancer;
        private System.Windows.Forms.TextBox tbParcourir;
        private System.Windows.Forms.Button btnParcourir;
    }
}

