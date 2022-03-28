using PayeTonEnchère.models;
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
    public partial class AcceuilVisiteurPage : ContentPage
    {
        public AcceuilVisiteurPage()
        {

            InitializeComponent();
            BindingContext = new EnchereVueModele();
        }
       


    }
}