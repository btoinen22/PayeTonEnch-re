using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    internal class TypeEnchere
    {
        private int _id; // ne contiendras un maximum de 3 ID pour les différent types d'enchères existantes
        private string _name; // enchère classique / enchère renversée / enchère flash

        /// <summary>
        /// Constructeur de la classe TypeEnchere
        /// </summary>
        /// <param name="name"></param>
        public TypeEnchere(string name)
        {
            _name = name; // associe le paramètre à la variable associé dans la base
        }

        public int Id { get => _id; set => _id = value; } // accesseur/mutateur de la variable _id
        public string Name { get => _name; set => _name = value; } // accesseur/mutateur de la variable _name
    }
}
