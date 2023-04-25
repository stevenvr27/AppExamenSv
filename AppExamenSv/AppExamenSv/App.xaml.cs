using AppExamenSv.Models;
using AppExamenSv.Services;
using AppExamenSv.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamenSv
{
    public partial class App : Application
    {
         
        public App()
        {
            InitializeComponent();
             
            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new BienvenidaPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
