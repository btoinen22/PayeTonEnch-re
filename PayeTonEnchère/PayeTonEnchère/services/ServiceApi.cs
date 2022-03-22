using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PayeTonEnchère.services
{
    public class ServiceApi
    {
        public static string
            ErrorTitle = "Error",
            ErrorDescriptionConnexion = "Email ou mot de passe Incorrect",
            ErrorDescriptionInscription = "un des champs entrées est incorrect ou vide",
            ErrorOk = "Ok",
            ErrorCancel = "Retour",
            ApiPostUser = "PostUser",
            ApigetGagnant = "getGagnant",
            ApiGetUserByMailAndPass = "GetUserByMailAndPass",
            ApiEncheresEnCours = "GetEncheresEnCours";

    }
}