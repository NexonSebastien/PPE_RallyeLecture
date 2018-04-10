using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace ppeProgramme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string scx;
            MySqlConnection connexion;
            scx = "user=adminRallyeLecture;password=siojjr;database=rallyelecture;host=172.16.0.144";
            //try
            //{
                connexion = new MySqlConnection(scx);
                connexion.Open();
            //}
            //catch (Exception except)
            //{
            //   MessageBox.Show(except.Message);

            //}
            renameAuteurDe(connexion);
            string sSelectClasse = "Select classe.id,niveauScolaire from niveau inner join classe on niveau.id = classe.idNiveau";
            MySqlCommand selectClasse = new MySqlCommand(sSelectClasse, connexion);
            MySqlDataReader reader = selectClasse.ExecuteReader();
            while (reader.Read())
            {
                cbClasse.Items.Add(reader["id"] + " " + reader["niveauScolaire"]);
                
            }
            reader.Close();
            connexion.Close();
        }

        private void btnParcourir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openfildialog1 = new FolderBrowserDialog();
            openfildialog1.ShowDialog();
            tbParcourir.Text = openfildialog1.SelectedPath;
            string[] filepaths = Directory.GetFiles(openfildialog1.SelectedPath, "*.csv", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < filepaths.Length; i++)
            {
                clbFichier.Items.Add(filepaths[i].Replace(openfildialog1.SelectedPath + "\\", ""));
            }
        }

        private void btnLancer_Click(object sender, EventArgs e)
        {
            string scx;
            MySqlConnection connexion;
            scx = "user=adminRallyeLecture;password=siojjr;database=rallyelecture;host=172.16.0.144";
            connexion = new MySqlConnection(scx);
            connexion.Open();
            if (cbSupression.Checked == true)
            {   //Code de la supression des Eleve avant l'insertion des nouveau pendant l'integraiton
                string [] NiveauClasse;
                NiveauClasse = cbClasse.Text.Split(' ');

                string sSupprimeUserGroup = "delete autg.* from aauth_user_to_group autg inner join eleve e on autg.user_id = e.idAuth inner join classe c on e.idClasse = c.id inner join niveau n on c.idNiveau = n.id where niveauScolaire = @niveau;";
                MySqlCommand supressionUserGroup = new MySqlCommand(sSupprimeUserGroup, connexion);
                supressionUserGroup.Parameters.AddWithValue("@niveau", NiveauClasse[1]);
                supressionUserGroup.ExecuteNonQuery();

                string sSupprimeUser = "delete au.* from aauth_users au inner join eleve e on au.id = e.idAuth inner join classe c on e.idClasse = c.id inner join niveau n on c.idNiveau = n.id where niveauScolaire = @niveau;";
                MySqlCommand supressionUser = new MySqlCommand(sSupprimeUser, connexion);
                supressionUser.Parameters.AddWithValue("@niveau", NiveauClasse[1]);
                supressionUser.ExecuteNonQuery();

                string sSupprimeEleve = "delete e.* from eleve e inner join classe c on e.idClasse = c.id inner join niveau n on c.idNiveau = n.id where niveauScolaire = @niveau;";
                MySqlCommand supressionClasse = new MySqlCommand(sSupprimeEleve, connexion);
                supressionClasse.Parameters.AddWithValue("@niveau", NiveauClasse[1]);
                supressionClasse.ExecuteNonQuery();
                //MessageBox.Show("Suppression fait");

                // coder l'insertion avec le csv

                string txt = tbParcourir.Text + "\\" + clbFichier.Text;
                //MessageBox.Show(txt);

                StreamReader sr = new StreamReader(txt);
                Console.ReadLine();
                sr.ReadLine();

                //INSERTION DE LA NOUVELLE CLASSE
                while (!sr.EndOfStream)
                {
                    string Line = sr.ReadLine();
                    string[] csvLecture = Line.Split(';');
                    string nom = csvLecture[1];
                    string prenom = csvLecture[2];
                    string adresseMail = csvLecture[3];
                    //MessageBox.Show(nom);


                    //INSERTION DANS aauth_users
                    string sInsertAauth = "Insert into aauth_users (email,pass) value(@email,@mdp);";
                    MySqlCommand InsertionAauth = new MySqlCommand(sInsertAauth, connexion);
                    InsertionAauth.Parameters.AddWithValue("@email", adresseMail);
                    InsertionAauth.Parameters.AddWithValue("@mdp", GetSha256FromString("siojjr"));
                    InsertionAauth.ExecuteNonQuery();

                    //RECUPERATION DE L'ID AAUTH_USERS
                    string sSelectAauth = "Select id from aauth_users where email = @email";
                    MySqlCommand selectAauth = new MySqlCommand(sSelectAauth, connexion);
                    selectAauth.Parameters.AddWithValue("@email", adresseMail);
                    MySqlDataReader reader = selectAauth.ExecuteReader();
                    reader.Read();
                    int idAauth = Convert.ToInt32(reader["id"]);
                    reader.Close();
                    //INSERTION BDD
                    string sInsertEleve = "Insert into Eleve (idClasse,nom,prenom,login,idAuth)values(@idClasse,@nom,@prenom,@login,@idAuth);";
                    MySqlCommand insertionEleve = new MySqlCommand(sInsertEleve, connexion);
                    string sIdClasse = Convert.ToString(cbClasse.Text);
                    string[] sTblIdClasse = sIdClasse.Split(' ');
                    int idClasse = Convert.ToInt32(sTblIdClasse[0]);
                    insertionEleve.Parameters.AddWithValue("@idClasse", idClasse);
                    insertionEleve.Parameters.AddWithValue("@nom", nom);
                    insertionEleve.Parameters.AddWithValue("@prenom", prenom);
                    insertionEleve.Parameters.AddWithValue("@login", adresseMail);
                    insertionEleve.Parameters.AddWithValue("@idAuth", idAauth);
                    insertionEleve.ExecuteNonQuery();

                    string sInsertAauthGroups = "Insert into aauth_user_to_group value (@aauthId,4);";
                    MySqlCommand insertionAauthGroups = new MySqlCommand(sInsertAauthGroups, connexion);;
                    insertionAauthGroups.Parameters.AddWithValue("@aauthId",idAauth);
                    insertionAauthGroups.ExecuteNonQuery();
                }
                connexion.Close();
            }

            else
            {

                string txt = tbParcourir.Text + "\\" + clbFichier.Text;
                //MessageBox.Show(txt);

                StreamReader sr = new StreamReader(txt);
                Console.ReadLine();
                sr.ReadLine();

                //INSERTION DE LA NOUVELLE CLASSE
                while (!sr.EndOfStream)
                {
                    string Line = sr.ReadLine();
                    string[] csvLecture = Line.Split(';');
                    string nom = csvLecture[1];
                    string prenom = csvLecture[2];
                    string adresseMail = csvLecture[3];
                    //MessageBox.Show(nom);


                    //INSERTION DANS aauth_users
                    string sInsertAauth = "Insert into aauth_users (email,pass) value(@email,@mdp);";
                    MySqlCommand InsertionAauth = new MySqlCommand(sInsertAauth, connexion);
                    InsertionAauth.Parameters.AddWithValue("@email", adresseMail);
                    InsertionAauth.Parameters.AddWithValue("@mdp", GetSha256FromString("siojjr"));
                    InsertionAauth.ExecuteNonQuery();

                    //RECUPERATION DE L'ID AAUTH_USERS
                    string sSelectAauth = "Select id from aauth_users where email = @email";
                    MySqlCommand selectAauth = new MySqlCommand(sSelectAauth, connexion);
                    selectAauth.Parameters.AddWithValue("@email", adresseMail);
                    MySqlDataReader reader = selectAauth.ExecuteReader();
                    reader.Read();
                    int idAauth = Convert.ToInt32(reader["id"]);
                    reader.Close();
                    //INSERTION BDD
                    string sInsertEleve = "Insert into Eleve (idClasse,nom,prenom,login,idAuth)values(@idClasse,@nom,@prenom,@login,@idAuth);";
                    MySqlCommand insertionEleve = new MySqlCommand(sInsertEleve, connexion);
                    string sIdClasse = Convert.ToString(cbClasse.Text);
                    string[] sTblIdClasse = sIdClasse.Split(' ');
                    int idClasse = Convert.ToInt32(sTblIdClasse[0]);
                    insertionEleve.Parameters.AddWithValue("@idClasse", idClasse);
                    insertionEleve.Parameters.AddWithValue("@nom", nom);
                    insertionEleve.Parameters.AddWithValue("@prenom", prenom);
                    insertionEleve.Parameters.AddWithValue("@login", adresseMail);
                    insertionEleve.Parameters.AddWithValue("@idAuth", idAauth);
                    insertionEleve.ExecuteNonQuery();

                    string sInsertAauthGroups = "Insert into aauth_user_to_group value (@aauthId,4);";
                    MySqlCommand insertionAauthGroups = new MySqlCommand(sInsertAauthGroups, connexion); ;
                    insertionAauthGroups.Parameters.AddWithValue("@aauthId", idAauth);
                    insertionAauthGroups.ExecuteNonQuery();
                }
                //coder l'insertion avec le csv
            }

            connexion.Close();
        }

        public static string GetSha256FromString(string data)
        {
            var message = Encoding.ASCII.GetBytes(data);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
        public void renameAuteur(int id, string nouveauNom, MySqlConnection connexion)
        {
            string sUpdateAuteur= "Update Auteur set nom = @nouveauNom where id=@id;";
            MySqlCommand updateAuteur = new MySqlCommand(sUpdateAuteur, connexion);
            updateAuteur.Parameters.AddWithValue("@id", id);
            updateAuteur.Parameters.AddWithValue("@nouveauNom", nouveauNom);
            updateAuteur.ExecuteNonQuery();
        }
        public void renameAuteurDe(MySqlConnection connexion)
        {
            string sRenameAuteurDe = "select id,nom from auteur where nom like 'de%';";
            MySqlCommand renameAuteurDe = new MySqlCommand(sRenameAuteurDe, connexion);
            MySqlDataReader reader = renameAuteurDe.ExecuteReader();
            string nouveauNom = "";
            while (reader.Read())
            {
                string[] nom = Convert.ToString(reader["nom"]).Split(' ');
                nouveauNom = nom[1];
                this.renameAuteur(Convert.ToInt32(reader["id"]), nouveauNom, connexion);

            }
            reader.Close();
        }
    }
}
