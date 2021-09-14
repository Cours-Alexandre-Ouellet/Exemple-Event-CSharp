using System.Linq;

namespace Exemple_Event_CSharp
{
    // Conserve la valeur maximale de la liste
    class ValeurMax : IndicateurAbstrait
    {
        public int Maximum { get; private set; }

        public ValeurMax(ListeDonnees liste) : base (liste)
        {
            Maximum = int.MinValue;
        }

        protected override void CalculerAvecNouvelleDonnee(int donnee)
        {
            // On évite de boucler toutes les données
            if(donnee > Maximum)
            {
                Maximum = donnee;
            }
        }

        protected override void CalculerAvecDonneeSupprimer(int donnee)
        {
            if (listeDonnees.Donnees.Count > 0)
            {
                Maximum = listeDonnees.Donnees.Max();
            }
            else
            {
                Maximum = int.MinValue;
            }
        }

        public override string ToString()
        {
            return "Valeur maximale : " + Maximum;
        }
    }
}
