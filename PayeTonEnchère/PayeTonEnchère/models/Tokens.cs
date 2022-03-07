using System;
using System.Collections.Generic;
using System.Text;

namespace PayeTonEnchère.models
{
    class Tokens
    {
        #region Attributs
        private string _token;
        #endregion

        #region Constructeurs
        public Tokens(string token)
        {
            Token = token;
        }
        #endregion

        #region Getters/Setters
        public string Token { get => _token; set => _token = value; }
        #endregion
    }
}
