using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class User
    {
        #region Attribut

        private int _id; //variable de l'identifiant unique du user
        private string _email; // email du user
        private string _password; // mot de passe du user
        private string _pseudo; // psuedo utilisé lors des enchère par le user
        private string _photo; // photo utilisé par l'utilisateur

        public static List<User> _collClass = new List<User>();

        //Relation 
        //un utilisateur les encherires
         private List<Encherir> _lesEncherirs;

        #endregion

        #region Constructeur

        /// <summary>
        /// Constructeur de la classe User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="pseudo"></param>
        public User(string email, string password, string photo, string pseudo)
        {
            _email = email; // associe le paramètre à la variable associé dans la base
            _password = password; // associe le paramètre à la variable associé dans la base
            Photo = photo; // associe le paramètre à la variable associé dans la base
            _pseudo = pseudo; // associe le paramètre à la variable associé dans la base

            _collClass.Add(this);

            //Relation 
            //un utilisateur les encherirs 
              _lesEncherirs = new List<Encherir>();
        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        #endregion

        #region Getters/Setters 

        public int Id { get => _id; set => _id = value; } // accesseur/mutateur de la variable _id
        public string Email { get => _email; set => _email = value; } // accesseur/mutateur de la variable _email
        public string Password
        {
            get => _password;
            set => _password = value;
        } // accesseur/mutateur de la variable password
        public string Pseudo { get => _pseudo; set => _pseudo = value; } // accesseur/mutateur de la variable _pseudo
        public List<Encherir> LesEncherirs { get => _lesEncherirs; set => _lesEncherirs = value; }
        public string Photo { get => _photo; set => _photo = value; }

        #endregion

        #region Methodes

        public List<User> AllUsers()
        {
            List<User> users = new List<User>();
            foreach (User use in _collClass)
                users.Add(use);
            return users;
        }

        #endregion

    }

}
