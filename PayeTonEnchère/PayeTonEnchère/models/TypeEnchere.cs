using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class TypeEnchere
    {
        #region Attribut 
        private int _id; // ne contiendras un maximum de 3 ID pour les différent types d'enchères existantes
        private string _name; // enchère classique / enchère renversée / enchère flash

        //Relation 

        //Les encheres pour un type encheres
        private List<Enchere> _lesEncheres;
        #endregion

        #region Constructeur
        /// <summary>
        /// Constructeur de la classe TypeEnchere
        /// </summary>
        /// <param name="name"></param>
        /// 

        public TypeEnchere(string name)
        {
            _name = name; // associe le paramètre à la variable associé dans la base

            _lesEncheres = new List<Enchere>();
        }

        #endregion

        #region Getters/Setters

        public int Id { get => _id; set => _id = value; } // accesseur/mutateur de la variable _id
        public string Name { get => _name; set => _name = value; } // accesseur/mutateur de la variable _name

        #endregion

        #region Methodes

        #endregion

    }
}
