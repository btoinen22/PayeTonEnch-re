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

		// Relation 
		// encherir les encheres
		public Enchere _lEncher;
		//un utilisateur enrechit
		public User _leUser;
		#endregion

		#region Constructeur
		public Encherir(double prixenchere, DateTime dateenchere /*, Enchere lEncher, User leUser*/)
        {
			Dateenchere= dateenchere;
			Prixenchere= prixenchere;

			//Relation
			/*_lEncher= lEncher;
			_leUser = leUser;*/
        }

		#endregion

		#region Getters/Setters

		public int Id { get => _id; set => _id = value; }
		public double Prixenchere { get => _prixenchere; set => _prixenchere = value; }
		public DateTime Dateenchere { get => _dateenchere; set => _dateenchere = value; }
		//internal Enchere LEncher { get => _lEncher; set => _lEncher = value; }
		//internal User LeUser { get => _leUser; set => _leUser = value; }

		#endregion

		#region Methodes
		#endregion

	}
}
