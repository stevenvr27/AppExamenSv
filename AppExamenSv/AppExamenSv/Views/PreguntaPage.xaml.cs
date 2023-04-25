using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppExamenSv.ViewModels;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AppExamenSv.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreguntaPage : ContentPage
    {
         
        askvm viemodel1;
         
         
        public PreguntaPage()
        {
            InitializeComponent();
            
            BindingContext = viemodel1 = new askvm();
           
        }
        


        

        private async void push_Clicked(object sender, EventArgs e)
        {
            bool R = await viemodel1.Addask(Txtpregunta.Text.Trim() 


                );
            if (R)
            {
                await DisplayAlert(":)", "Pregunta agregada", "OK");
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert(":(", "algo esta mal", "OK");
            }

        }
    }
}