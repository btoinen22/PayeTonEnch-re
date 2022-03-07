using PayeTonEnchère.VueModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PayeTonEnchère.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthentificationPage : ContentView
    {
        public AuthentificationPage()
        {
            InitializeComponent();
            BindingContext = new AuthentificationVueModele();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }
    }
}