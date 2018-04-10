using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;
using System.Collections;

// rapide présentation des 3 types de format
// présentation de json et intérêt
// comment paramétrer firefox pour les visualiser
// les tables à mettre à jour
// structure des méthodes attendue
// use case, scénario de déroulement alimentation

// insert à modifier
// nettoyage bd
// 


namespace lectureJson
{
    class Program
    {
        static void Main()
        {
            // On ouvre et on lit le fichier texte qui contient les réponses au format json
            StreamReader sr = new StreamReader("correctionFiches.json");
            string sJson = sr.ReadToEnd();

            // On déserialise le fichier json pour le charger en mémoire :
            // on charge chacune des occurences du fichier json dans
            // un objet de type reponse dont la structure des données membres
            // est au plus proche de la strucuture du json.
            JavaScriptSerializer json = new JavaScriptSerializer();
            List<Reponse> lesReponses = json.Deserialize<List<Reponse>>(sJson);

            // boucle pour afficher sur la console 
            // le contenu de listeReponse
            foreach (Reponse r in lesReponses)
            {
                int i = 0;
                Console.Write("fiche : {0} titre : {1} ", r.IdFiche, r.Titre);
                foreach (object obj in r.BonnesReponses)
                {
                    // si BonnesReponses contient une collection de bonnesReponses (plusieurs
                    // bonnes réponses possibles à une même question.
                    if (obj is ICollection)
                    {
                        foreach(object o in ((ICollection)obj))
                        {
                            Console.Write("{0}:{1} ", i, o.ToString());
                        }
                    }
                    else
                    {
                        Console.Write("{0}:{1} ", i, obj.ToString());
                    }
                    i++;
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
