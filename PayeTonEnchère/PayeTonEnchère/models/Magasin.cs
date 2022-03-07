using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class Magasin
    {
         #region Attriubut
       

        private int _id; // identifiant unique pour un magasin
        private string _name; // nom du magasin
        private string _address; // adresse du magasin
        private string _city; // ville du magasin
        private int _codepostale; // code postale de la ville du magasin
        private int _phonenumber; // numéro de telephone du magasin - 02...

        
        /// <summary>
        /// les deux variable double correspondent au cardinalité
        /// afin de placer et localisé un magasin
        /// </summary>
        private double _x; // longitude ( emplacement du magasin )
        private double _y; // latitude ( emplacement du magasin )

        
        private List<Magasin> _collClass = new List<Magasin>(); // liste de tout les magasins instancier

        // Relation 
        //associations avec la classe produit pour associer des produits pour un magasin
        private List<Produit> _lesProduits; 
          #endregion

        #region constructeur

        /// <summary>
        /// constructeur de la classe magasin
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="codepostale"></param>
        /// <param name="phonenumber"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Magasin(string name, string address, string city, int codepostale, int phonenumber, double x, double y)
        {
            _name = name; // associe le paramètre à la variable associé dans la base
           
            _address = address; // associe le paramètre à la variable associé dans la base
            
            _city = city; // associe le paramètre à la variable associé dans la base
           
            _codepostale = codepostale; // associe le paramètre à la variable associé dans la base
            
            _phonenumber = phonenumber; // associe le paramètre à la variable associé dans la base
            
            _x = x; // associe le paramètre à la variable associé dans la base
            
            _y = y; // associe le paramètre à la variable associé dans la base

           

            _collClass.Add(this); // ajoute automatiquement l'instance créer dans la liste _collClass
            
            // Création de l'instance de la Relation 

             // permet de créer une liste des produits pour le magasin
            _lesProduits = new List<Produit>();
        }
        #endregion

        #region Getters/setters
        public int Id { get => _id; set => _id = value; } // accesseur/mutateur de la variable _id
        
        public string Name { get => _name; set => _name = value; } // accesseur/mutateur de la variable _name
        
        public string Address { get => _address; set => _address = value; } // accesseur/mutateur de la variable _address
        
        public string City { get => _city; set => _city = value; } // accesseur/mutateur de la variable _city
        
        public int Codepostale { get => _codepostale; set => _codepostale = value; } // accesseur/mutateur de la variable _codepostale
        
        public int Phonenumber { get => _phonenumber; set => _phonenumber = value; } // accesseur/mutateur de la variable _phonenumber
       
        public double X { get => _x; set => _x = value; } // accesseur/mutateur de la variable _x
        
        public double Y { get => _y; set => _y = value; } // accesseur/mutateur de la variable _y
       
        public List<Produit> LesProduits { get => _lesProduits; set => _lesProduits = value; } // accesseur/mutateur de la liste de produit
       
        #endregion

        #region Methodes

        #endregion
    }
}
