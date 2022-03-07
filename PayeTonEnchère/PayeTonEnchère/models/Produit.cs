using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class Produit
    {
        #region Attribut
        private int _id; // variable _id est l'dentifiant unique d'un produit

        private string _name; // dénomination du produit
        
       
        /// <summary>
        /// faire attention au type d'utilisation potentiellement a modifié 
        /// pour la prise en charge dans le code c# et dans la bdd
        /// </summary>
        private string _photo; // image correspondant au produit enregistré

        private double _realprice; // indiquation du prix réel du produit enregistré

        public static List<Produit> _collClass = new List<Produit>(); // liste de tout les produit enregistré ( pas necessairement utile )

         //Relation

        // relation les encheres du produit
        private List<Enchere> _lesEncheres;

        // relation les magasins du produit
        private List<Magasin> _lesMagasins;
        
        #endregion

        #region constructeur
        /// <summary>
        /// constructeur de la classe Produit
        /// </summary>
        /// <param name="name"></param>
        /// <param name="photo"></param>
        /// <param name="realprice"></param>
        public Produit(string name, string photo, double realprice)
        {
            _name = name; // associe le paramètre à la variable associé dans la base
            _photo = photo; // associe le paramètre à la variable associé dans la base
            _realprice = realprice; // associe le paramètre à la variable associé dans la base

            _lesMagasins = new List<Magasin>(); // permet d'associer des magasins à un produits

            _lesEncheres = new List<Enchere>(); //permet d'associer les encheres a un produit

            _collClass.Add(this); // ajoute l'instance créer automatiquement dans la liste _collClass
        }
        #endregion

        #region Getters/setters

        public int Id { get => _id; set => _id = value; } // accesseur/mutateur de la variable _id

        public string Name { get => _name; set => _name = value; } // accesseur/mutateur de la variable _name

        public string Photo { get => _photo; set => _photo = value; } // accesseur/mutateur de la variable _photo ( type sera potentiellement a changé )
        
        public double Realprice { get => _realprice; set => _realprice = value; } // accesseur/mutateur de la variable _realprice
        
        #endregion

        #region Methodes

        #endregion
    }
}
