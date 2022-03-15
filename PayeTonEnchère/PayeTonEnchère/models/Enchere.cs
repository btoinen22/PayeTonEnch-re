using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class Enchere
    {
        #region Attribut
        private int id; // identifiant unique d'une enchère lancé
        private DateTime _datestart; // date-heure de début de l'enchère
        private DateTime _dateend; // date-heure de fin de l'enchère
        private double _reserveprice; // prix de réserve sur l'enchère
        private double _finalprice; // prix final atteint par l'enchère

        public static List<Enchere> _collClass = new List<Enchere>(); // liste de tout les enchere enregistré

        //Relation

        //Object relation entre le Produit et les enchere
        private Produit _leProduit;
         //object un type d'enchere 
        private TypeEnchere _leTypeEnchere;
        // Collection les encherires une enchere
        private List<Encherir> _lesEncherirs;

        public static List<Enchere> _collClass = new List<Enchere>();

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur de la classe Enchere
        /// </summary>
        /// <param name="datestart"></param>
        /// <param name="dateend"></param>
        /// <param name="reserveprice"></param>
        /// <param name="finalprice"></param>
        public Enchere(DateTime datestart, DateTime dateend, double reserveprice, double finalprice, Produit leProduit, TypeEnchere leTypeEnchere)
        {
            _datestart = datestart; // associe le paramètre à la variable associé dans la base
            _dateend = dateend; // associe le paramètre à la variable associé dans la base
            _reserveprice = reserveprice; // associe le paramètre à la variable associé dans la base
            _finalprice = finalprice; // associe le paramètre à la variable associé dans la base

            _collClass.Add(this);

            //relation
            //language objet le produit
            _leProduit = leProduit;

            //object un type d'enchere 
            _leTypeEnchere= leTypeEnchere
            //encherire une enchere
            _lesEncherirs= new List<Encherir>();
        }

        public Enchere(DateTime now1, DateTime now2, int v1, int v2)
        {
        }

        #endregion

        #region Getters/setters
        public int Id { get => id; set => id = value; } // accesseur/mutateur de la variable _id
        public DateTime Datestart { get => _datestart; set => _datestart = value; } // accesseur/mutateur de la variable _datestart
        public DateTime Dateend { get => _dateend; set => _dateend = value; } // accesseur/mutateur de la variable _dateend
        public double Reserveprice { get => _reserveprice; set => _reserveprice = value; } // accesseur/mutateur de la variable _reserveprice
        public double Finalprice { get => _finalprice; set => _finalprice = value; } // accesseur/mutateur de la variable _finalprice
        
        public Produit leProduit { get=> _leProduit; set => _leProduit = value; } 
        public Enchere leTypeEnchere { get=> _leTypeEnchere; set => _leTypeEnchere = value; }
    }

         #endregion

        #region Methodes

        #endregion
}
