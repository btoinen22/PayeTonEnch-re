using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class Encherir
    {
	
		#region Attribut

		private int _id;
		private double _prixenchere;
		private DateTime _dateenchere;

        private static List<Encherir> collClass = new List<Encherir>(); // liste de tout les encherissemnt 


        // Relation 

        // encherir les encheres
        private Enchere _lEnchere;

		//un utilisateur enrechit
		private User _leUser;


        #endregion

        #region Constructeur
        public Encherir(double prixenchere, DateTime dateenchere, Enchere lEnchere, User leUser)
        {
            _prixenchere = prixenchere;
            _dateenchere = dateenchere;
            CollClass.Add(this);
            _lEnchere = lEnchere;
            _leUser = leUser;
        }
        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
		public double Prixenchere { get => _prixenchere; set => _prixenchere = value; }
		public DateTime Dateenchere { get => _dateenchere; set => _dateenchere = value; }
		public static List<Encherir> CollClass { get => collClass; set => collClass = value; }
		internal Enchere LEnchere { get => _lEnchere; set => _lEnchere = value; }
		internal User LeUser { get => _leUser; set => _leUser = value; }


		#endregion

		#region Methodes
		#endregion

	}
}
