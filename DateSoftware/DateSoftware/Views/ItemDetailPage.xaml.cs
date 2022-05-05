using DateSoftware.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DateSoftware.Views
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