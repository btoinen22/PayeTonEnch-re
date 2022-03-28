using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class Enchere
    {
        #region Attribut
        private int _id; // identifiant unique d'une enchère lancé
        private DateTime _datedebut; // date-heure de début de l'enchère
        private DateTime _datefin; // date-heure de fin de l'enchère
        private double _reserveprice; // prix de réserve sur l'enchère
        private double _finalprice; // prix final atteint par l'enchère

        public static List<Enchere> CollClass = new List<Enchere>(); // liste de tout les enchere enregistré
        
        //Relation

        //Object relation entre le Produit et les enchere
        private Produit _leProduit;
         //object un type d'enchere 
        private TypeEnchere _leTypeEnchere;
        // Collection les encherires une enchere
        private List<Encherir> _lesEncherirs;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur de la classe Enchere
        /// </summary>
        /// <param name="datestart"></param>
        /// <param name="dateend"></param>
        /// <param name="reserveprice"></param>
        /// <param name="finalprice"></param>
       /* public Enchere(DateTime datestart, DateTime dateend, double reserveprice, double finalprice, Produit leProduit, TypeEnchere leTypeEnchere)
        {
            _datedebut = datestart; // associe le paramètre à la variable associé dans la base
            _datefin = dateend; // associe le paramètre à la variable associé dans la base
            _reserveprice = reserveprice; // associe le paramètre à la variable associé dans la base
            _finalprice = finalprice; // associe le paramètre à la variable associé dans la base

            _collClass.Add(this);

            //relation
            //language objet le produit
            _leProduit = leProduit;

            //object un type d'enchere 
            _leTypeEnchere= leTypeEnchere;
            //encherire une enchere
            _lesEncherirs= new List<Encherir>();
        }*/

        public Enchere(int id, DateTime datedebut, DateTime datefin, double prixReserve, TypeEnchere leTypeEnchere = null, Produit leProduit = null)
        {
            
            this._id = id;
            this._datedebut = datedebut;
            this._datefin = datefin;
            this.Reserveprice = prixReserve;
            //this.prix_enchere = prix_enchere;
            this.leTypeEnchere = leTypeEnchere;
            this.leProduit = leProduit;
            Enchere.CollClass.Add(this);
        }

        #endregion

        #region Getters/setters
        public int Id { get => _id; set => _id = value; } // accesseur/mutateur de la variable _id
        public DateTime Datedebut { get => _datedebut; set => _datedebut = value; } // accesseur/mutateur de la variable _datestart
        public DateTime Datefin { get => _datefin; set => _datefin = value; } // accesseur/mutateur de la variable _dateend
        public double Reserveprice { get => _reserveprice; set => _reserveprice = value; } // accesseur/mutateur de la variable _reserveprice
        public double Finalprice { get => _finalprice; set => _finalprice = value; } // accesseur/mutateur de la variable _finalprice
        
        public Produit leProduit { get=> _leProduit; set => _leProduit = value; } 
        public TypeEnchere leTypeEnchere { get=> _leTypeEnchere; set => _leTypeEnchere = value; }
    }

         #endregion

        #region Methodes

        #endregion
}
