using AppExamenSv.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppExamenSv.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}