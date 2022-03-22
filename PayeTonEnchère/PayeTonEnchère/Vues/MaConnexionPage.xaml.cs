using PayeTonEnchère.VueModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PayeTonEnchère.Vues
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaConnexionPage : ContentPage
    {
        public MaConnexionPage()
        {
            InitializeComponent();
            BindingContext = new AuthentificationVueModele(this);
        }
    }
}