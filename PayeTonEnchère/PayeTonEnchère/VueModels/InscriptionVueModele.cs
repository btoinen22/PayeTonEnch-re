using PayeTonEnchère.Vues;
using Xamarin.Forms;

namespace PayeTonEnchère.VueModels
{
    internal class InscriptionVueModele : BaseVueModele
    {
        #region Attributs

        #endregion

        #region Constructeurs

        public InscriptionVueModele()
        {
            new Command(() => Gotoco());
        }


        #endregion

        #region Getters/Setters

        #endregion

        #region Methodes
        public async void Gotoco()
        {
            var route = $"{nameof(MaConnexionPage)}";
            await Shell.Current.GoToAsync(route);
        }
        
        #endregion


    }
}
