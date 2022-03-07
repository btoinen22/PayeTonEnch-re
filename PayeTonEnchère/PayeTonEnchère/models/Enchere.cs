using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    internal class Enchere
    {
        #region Attribut
        private int id; // identifiant unique d'une enchère lancé
        private DateTime _datestart; // date-heure de début de l'enchère
        private DateTime _dateend; // date-heure de fin de l'enchère
        private double _reserveprice; // prix de réserve sur l'enchère
        private double _finalprice; // prix final atteint par l'enchère

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur de la classe Enchere
        /// </summary>
        /// <param name="datestart"></param>
        /// <param name="dateend"></param>
        /// <param name="reserveprice"></param>
        /// <param name="finalprice"></param>
        public Enchere(DateTime datestart, DateTime dateend, double reserveprice, double finalprice)
        {
            _datestart = datestart; // associe le paramètre à la variable associé dans la base
            _dateend = dateend; // associe le paramètre à la variable associé dans la base
            _reserveprice = reserveprice; // associe le paramètre à la variable associé dans la base
            _finalprice = finalprice; // associe le paramètre à la variable associé dans la base

            _collClass.Add(this);
        }

        #endregion

        #region Getters/setters
        public int Id { get => id; set => id = value; } // accesseur/mutateur de la variable _id
        public DateTime Datestart { get => _datestart; set => _datestart = value; } // accesseur/mutateur de la variable _datestart
        public DateTime Dateend { get => _dateend; set => _dateend = value; } // accesseur/mutateur de la variable _dateend
        public double Reserveprice { get => _reserveprice; set => _reserveprice = value; } // accesseur/mutateur de la variable _reserveprice
        public double Finalprice { get => _finalprice; set => _finalprice = value; } // accesseur/mutateur de la variable _finalprice
    }

         #endregion

        #region Methodes

        #endregion
}
