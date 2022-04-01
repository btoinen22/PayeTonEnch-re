using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PayeTonEnchère.Models
{
    public class Enchere
    {
        #region Attributs
        public static List<Enchere> CollClasse = new List<Enchere>();
        public static ObservableCollection<Enchere> Xxx = new ObservableCollection<Enchere>();
        private int _id;
        private DateTime _datedebut;
        private DateTime _datefin;
        private double _prixReserve;
        //private double prix_enchere;
        //private ObservableCollection<Encherir> lesEncherirs;
        private TypeEnchere _leTypeEnchere;
        private Produit _leProduit;

        #endregion

        #region Constructeurs

        public Enchere(int id, DateTime datedebut, DateTime datefin, double prixReserve, TypeEnchere leTypeEnchere = null, Produit leProduit = null)
        {
            Enchere.CollClasse.Add(this);
            this._id = id;
            this._datedebut = datedebut;
            this._datefin = datefin;
            this._prixReserve = prixReserve;
            //this.prix_enchere = prix_enchere;
            this._leTypeEnchere = leTypeEnchere;
            this._leProduit = leProduit;


            Enchere.Xxx.Add(this);
        }

        #endregion

        #region Getters/Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime Datedebut { get => _datedebut; set => _datedebut = value; }
        public DateTime Datefin { get => _datefin; set => _datefin = value; }
        public double PrixReserve { get => _prixReserve; set => _prixReserve = value; }
        //public double Prix_enchere { get => prix_enchere; set => prix_enchere = value; }
        public TypeEnchere LeTypeEnchere { get => _leTypeEnchere; set => _leTypeEnchere = value; }
        public Produit LeProduit { get => _leProduit; set => _leProduit = value; }
        #endregion

        #region Methodes

        #endregion
    }
}
