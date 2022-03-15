using PayeTonEnchère.VueModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PayeTonEnchère.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthentificationPage : ContentPage
    {
        public AuthentificationPage()
        {
            BindingContext = new AuthentificationVueModele();
        }
    }
}