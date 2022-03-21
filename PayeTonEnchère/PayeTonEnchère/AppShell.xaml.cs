using PayeTonEnchère.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PayeTonEnchère
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MaConnexionPage), typeof(MaConnexionPage));
            Routing.RegisterRoute(nameof(MonInscriptionPage), typeof(MonInscriptionPage));
            Routing.RegisterRoute(nameof(AcceuilPage), typeof(AcceuilPage));
            Routing.RegisterRoute(nameof(AcceuilVisiteurPage), typeof(AcceuilVisiteurPage));
        }

    }
}