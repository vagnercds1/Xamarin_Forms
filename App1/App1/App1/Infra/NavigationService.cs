using System.Threading.Tasks;

namespace App1.Infra
{
    public class NavigationService : Infra.INavigatioService
    {
        public async Task NavigateToFuncionario()
        { 
            await App.Current.MainPage.Navigation.PushAsync(new View.FuncionarioPage());
        }

        public async Task NavigateToLogin()
        {
            await App.Current.MainPage.Navigation.PushAsync(new View.LoginPage());
        }
    }
}
