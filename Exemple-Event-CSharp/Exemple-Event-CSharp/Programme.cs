using System;

namespace Exemple_Event_CSharp
{
    // Permet d'entrer et retirer des valeurs
    class Programme
    {
        // Conteneur de données
        private ListeDonnees listeDonnees;

        // Indicateurs sur la liste de données
        private IndicateurAbstrait[] indicateurs;

        public Programme()
        {
            listeDonnees = new ListeDonnees();
            indicateurs = new IndicateurAbstrait[3]
            {
                new ValeurMin(listeDonnees),
                new ValeurMax(listeDonnees),
                new ValeurMoyenne(listeDonnees)
            };
        }

        // Exécute la boucle principale du programme
        public void Executer()
        {
            // État d'exécution
            bool executer = true;

            while (executer)
            {
                // Afficher les indicateurs
                foreach (IndicateurAbstrait indicateur in indicateurs)
                {
                    Console.WriteLine(indicateur);
                }

                Console.WriteLine("Souhaitez-vous ajouter (A) ou retirer (R) une valeur ? (0 pour quitter)");
                string caractere = Console.ReadLine();

                switch (caractere)
                {
                    case "A":       // Ajout
                    case "a":
                        Console.WriteLine("Entrer l'entier à ajouter : ");
                        if (SaisirEntier(out int valeurAjoutee))
                        {
                            listeDonnees.Ajouter(valeurAjoutee);
                        }
                        else
                        {
                            Console.WriteLine("La valeur saisie n'est pas valide.");
                        }
                        break;  
                    case "R":       // Suppression
                    case "r":
                        Console.WriteLine("Entrer l'entier à retirer : ");
                        if (SaisirEntier(out int valeurRetiree))
                        {
                            listeDonnees.Supprimer(valeurRetiree);
                        }
                        else
                        {
                            Console.WriteLine("La valeur saisie n'est pas valide.");
                        }
                        break;
                    case "0":       // Quitter l'application
                        Console.WriteLine("Fermeture de l'application.");
                        executer = false;
                        break;
                    default:
                        Console.WriteLine("Entrée invalide.");
                        break;
                }
            }
        }

        // Permet de saisir un entier de façon sécuritaire
        private bool SaisirEntier(out int valeur)
        {
            string saisie = Console.ReadLine();
            return int.TryParse(saisie, out valeur);
        }

        static void Main(string[] args)
        {
            new Programme().Executer();
        }
    }
}
