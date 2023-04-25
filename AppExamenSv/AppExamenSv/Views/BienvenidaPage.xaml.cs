using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppExamenSv.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamenSv.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BienvenidaPage : ContentPage
    {
        UserViewModel viewModel;
        public BienvenidaPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new UserViewModel();
        }

        private async void login_Clicked(object sender, EventArgs e)
        {
            bool R = false;
            if (txtUserName.Text != null && !string.IsNullOrEmpty(txtUserName.Text.Trim()) &&
                txtPassword.Text != null && !string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                try
                {
                    UserDialogs.Instance.ShowLoading("Cheking User Access..");
                    await Task.Delay(2000);

                    string UserName = txtUserName.Text.Trim();
                    string Password = txtPassword.Text.Trim();  

                    R = await viewModel.UserAccessValidation(UserName, Password);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    UserDialogs.Instance.HideLoading();
                }

            }
            else
            {
                await DisplayAlert("Validacion error", "Usuario y contraseña son requeridas", "ok");
                return;
            }
            if (R)
            {
                GlobalObjects.localuser = await viewModel.GetUserData(txtUserName.Text.Trim());
                await Navigation.PushAsync(new PreguntaPage());

                return;
            }
            else
            {
                await DisplayAlert("Validacion failed", "acceso restringido", "ok");
                return;
            }





        }



        private async void ps_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodaslaspreguntasPage());
        }
    }
}

            
                
            