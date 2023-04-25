using AppExamenSv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamenSv.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodaslaspreguntasPage : ContentPage
    {
        askvm askvm;

         
        public TodaslaspreguntasPage()
        {
            InitializeComponent();
            BindingContext = askvm = new askvm();
            LoadAsks();

        }

        private async void LoadAsks()
        {
            pckask.ItemsSource = await askvm.Getask();
        }

    }
}