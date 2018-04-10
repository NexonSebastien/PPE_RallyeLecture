 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lectureJson
{
    // structure au plus proche du format json
    // bonne réponse est une collection d'object.
    // object est une classe à laquelle appartient toutes les classes.
    // or dans bonnesReponses peut être soit :
    // une chaine de caractère soit
    // une collection de chaine de caractère.
    // donc on choisit comme type collection d'object qui permet de stocker soit
    // l'un soit l'autre des types.
    class Reponse
    {
        private int idFiche;
        private string titre;
        private List<object> bonnesReponses;

        public int IdFiche
        {
            get { return idFiche; }
            set { idFiche = value; }
        }

        public string Titre
        {
            get { return titre; }
            set { titre = value; }
        }

        public List<object> BonnesReponses
        {
            get { return bonnesReponses; }
            set { bonnesReponses = value; }
        }
    }

}
