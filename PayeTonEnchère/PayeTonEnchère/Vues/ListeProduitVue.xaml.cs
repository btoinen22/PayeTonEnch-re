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
    public partial class ListeProduitVue : ContentView
    {
        public ListeProduitVue()
        {
            InitializeComponent();
            BindingContext = new ListeProduitVueModele();
        }
    }
}