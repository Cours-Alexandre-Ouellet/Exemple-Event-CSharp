using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple_Event_CSharp
{
    // Permet d'indiquer une quantité sur une donnée
    public abstract class IndicateurAbstrait
    {
        protected ListeDonnees listeDonnees;

        public IndicateurAbstrait(ListeDonnees liste)
        {
            listeDonnees = liste;
            liste.OnDonneeAjoutee += CalculerAvecNouvelleDonnee;
            liste.OnDonneeSupprimee += CalculerAvecDonneeSupprimer;
        }

        // On se désincrit les abonnés
        ~IndicateurAbstrait()
        {
            listeDonnees.OnDonneeAjoutee -= CalculerAvecNouvelleDonnee;
            listeDonnees.OnDonneeSupprimee -= CalculerAvecDonneeSupprimer;
        }

        // Met à jour la valeur avec la nouvelle donnée
        protected abstract void CalculerAvecNouvelleDonnee(int donnee);

        // Met à jour la valeur sans la donnée supprimée
        protected abstract void CalculerAvecDonneeSupprimer(int donnee);
    }
}
