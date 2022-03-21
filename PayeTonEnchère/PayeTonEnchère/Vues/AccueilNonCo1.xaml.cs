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
    public partial class AcccueilNonCO1 : ContentPage
    {
        /// <summary>
        /// Initialisation d'une nouvelle instance de l'InsciptionVueModele
        /// </summary>
        public AcccueilNonCO1()
        {
            //InitializeComponent();
            BindingContext = new InscriptionVueModele();
        }

    }
}