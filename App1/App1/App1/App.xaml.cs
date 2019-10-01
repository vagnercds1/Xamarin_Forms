using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using App1.Infra;
using App1.Model;
using System.Collections.Generic;
using System.Linq;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DataBaseService.DataBaseServiceStart("MUDAR");

            DependencyService.Register<App1.Infra.INavigatioService, App1.Infra.NavigationService>(); 

            MainPage = new NavigationPage(new View.LoginPage()); 
        }

         

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
