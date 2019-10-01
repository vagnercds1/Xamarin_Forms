using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class LoginViewModel
    {
        private readonly Infra.INavigatioService _navigatioService;

        public ICommand LogarCommand
        {
            get;
            set;
        }

        public LoginViewModel()
        {
            this.LogarCommand = new Command(this.Logar);
            this._navigatioService = DependencyService.Get<Infra.INavigatioService>();
        }

        private void Logar()
        {
            _navigatioService.NavigateToFuncionario();
        }
    }
}
