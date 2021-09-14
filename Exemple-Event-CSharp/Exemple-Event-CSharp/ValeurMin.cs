using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple_Event_CSharp
{
    // Conserve la valeur minimale de la liste
    class ValeurMin : IndicateurAbstrait
    {
        public int Minimum { get; private set; }

        public ValeurMin(ListeDonnees liste) : base(liste) 
        {
            Minimum = Int32.MaxValue;
        }
        protected override void CalculerAvecNouvelleDonnee(int donnee)
        {
            // On évite de boucler sur toutes les données
            if(donnee < Minimum)
            {
                Minimum = donnee;
            }
        }

        protected override void CalculerAvecDonneeSupprimer(int donnee)
        {
            if (listeDonnees.Donnees.Count > 0)
            {
                Minimum = listeDonnees.Donnees.Min();
            }
            else
            {
                Minimum = int.MaxValue;
            }
        }

        public override string ToString()
        {
            return "Valeur minimale : " + Minimum; 
        }
    }
}
