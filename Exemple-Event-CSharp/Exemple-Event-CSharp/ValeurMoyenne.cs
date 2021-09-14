using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple_Event_CSharp
{
    // Conserve la valeur moyenne de la liste
    class ValeurMoyenne : IndicateurAbstrait
    {
        public float Moyenne { get; private set; }

        public ValeurMoyenne(ListeDonnees liste) : base(liste)
        {
            Moyenne = 0.0f;
        }

        // Formule permettant de mettre à jour la moyenne sans boucler sur les données
        protected override void CalculerAvecNouvelleDonnee(int donnee)
        {
            int nombreDonnees = listeDonnees.Donnees.Count;
            Moyenne = (Moyenne * (nombreDonnees - 1) + donnee) / nombreDonnees;
        }

        // Formule permettant de mettre à jour la moyenne sans boucler sur les données
        protected override void CalculerAvecDonneeSupprimer(int donnee)
        {
            int nombreDonnees = listeDonnees.Donnees.Count;
            Moyenne = (Moyenne * (nombreDonnees + 1) - donnee) / nombreDonnees;
        }

        public override string ToString()
        {
            return "Valeur moyenne : " + Moyenne;
        }
    }
}
