using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class Encherir
    {
	
		#region Attribut

		private int _id;
		private Enchere _laenchere_id;
		private User _leuser_id;
		private double _prixenchere;
		private DateTime _dateenchere;

		// Relation 
		// encherir les encheres
		private Enchere _lEncherir;
		//un utilisateur enrechit
		private User _leUser;
		#endregion

		#region Constructeur
		public Encherir(int id,double prixenchere,DateTime dateenchere,Enchere laenchere_id, User leuser_id, Enchere lEncherir,User leUser)
        {
			_id= id;
			_laenchere_id= laenchere_id;
			_dateenchere= dateenchere;
			_prixenchere= prixenchere;
			this._leuser_id= leuser_id;

			//Relation
			_lEncherir= lEncherir;
			_leUser=leUser
        }
		#endregion

		#region Getters/Setters
		#endregion

		#region Methodes
		#endregion

    }
}
