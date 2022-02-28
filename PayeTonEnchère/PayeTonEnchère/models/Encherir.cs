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


		#endregion

		#region Constructeur
		public Encherir(int id,double prixenchere,DateTime dateenchere,Enchere laenchere_id, User leuser_id)
        {
			_id= id;
			_laenchere_id= laenchere_id;
			_dateenchere= dateenchere;
			_prixenchere= prixenchere;
			this._leuser_id= leuser_id;
        }
		#endregion

		#region Getters/Setters
		#endregion

		#region Methodes
		#endregion

    }
}
