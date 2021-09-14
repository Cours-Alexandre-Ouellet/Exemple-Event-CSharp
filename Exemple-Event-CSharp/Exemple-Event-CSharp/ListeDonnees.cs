using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exemple_Event_CSharp
{
    // Conteneur de données entière
    public class ListeDonnees
    {
        public List<int> Donnees { get; private set; }

        // Notifie qu'une donnée est ajoutée
        public Action<int> OnDonneeAjoutee;

        // Notifie qu'une donnée est supprimée
        public Action<int> OnDonneeSupprimee;

        public ListeDonnees()
        {
            Donnees = new List<int>();
        }

        // Ajoute une donnée au conteneur
        public void Ajouter(int valeur)
        {
            Donnees.Add(valeur);
            OnDonneeAjoutee?.Invoke(valeur);
        }

        // Supprime une donnée du conteneur si elle y existe
        public void Supprimer(int valeur)
        {
            if (Donnees.Remove(valeur))
            {
                OnDonneeSupprimee?.Invoke(valeur);
            }
        }

    }
}
