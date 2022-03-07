using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    public class User
    {
        #region Attribut

        private int _id; //variable de l'identifiant unique du user
        private string _name; //vvaraible de nomination du user
        private string _firstname; //variable du prenom du user
        private string _address; //variable de adresse du user
        private string _codepostale; // code postale du user
        private string _city; // ville du user
        private string _email; // email du user
        private string _password; // mot de passe du user
        private string _phone; // numéro de telephone du user
        private string _pseudo; // psuedo utilisé lors des enchère par le user

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
        /// <param name="name"></param>
        /// <param name="firstname"></param>
        /// <param name="address"></param>
        /// <param name="codepostale"></param>
        /// <param name="city"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="phone"></param>
        /// <param name="pseudo"></param>
        public User(string name, string firstname, string address, string codepostale, string city, string email, string password, string phone, string pseudo)
        {
            _name = name; // associe le paramètre à la variable associé dans la base
            _firstname = firstname; // associe le paramètre à la variable associé dans la base
            _address = address; // associe le paramètre à la variable associé dans la base
            _codepostale = codepostale; // associe le paramètre à la variable associé dans la base
            _city = city; // associe le paramètre à la variable associé dans la base
            _email = email; // associe le paramètre à la variable associé dans la base
            _password = password; // associe le paramètre à la variable associé dans la base
            _phone = phone; // associe le paramètre à la variable associé dans la base
            _pseudo = pseudo; // associe le paramètre à la variable associé dans la base

            _collClass.Add(this);

            //Relation 
            //un utilisateur les encherirs 
              _lesEncherirs = new List<Encherir>();
        }

        #endregion

        #region Getters/Setters 

        public int Id { get => _id; set => _id = value; } // accesseur/mutateur de la variable _id
        public string Name { get => _name; set => _name = value; } // accesseur/mutateur de la variable _name
        public string Firstname { get => _firstname; set => _firstname = value; } // accesseur/mutateur de la variable _firstname
        public string Address { get => _address; set => _address = value; } // accesseur/mutateur de la variable _address
        public string Codepostale { get => _codepostale; set => _codepostale = value; } // accesseur/mutateur de la variable _codepostale
        public string City { get => _city; set => _city = value; } // accesseur/mutateur de la variable _city
        public string Email { get => _email; set => _email = value; } // accesseur/mutateur de la variable _email
        public string Password
        {
            get => _password;
            set => _password = value;
        } // accesseur/mutateur de la variable password
        public string Phone { get => _phone; set => _phone = value; } // accesseur/mutateur de la variable _phone
        public string Pseudo { get => _pseudo; set => _pseudo = value; } // accesseur/mutateur de la variable _pseudo
        public List<Encherir> LesEncherirs { get => _lesEncherirs; set => _lesEncherirs = value; }

        #endregion

        #region Methodes

        public List<User> allUsers()
        {
            List<User> users = new List<User>();
            foreach (User use in _collClass)
                users.Add(use);
            return users;
        }

        #endregion

    }

}
