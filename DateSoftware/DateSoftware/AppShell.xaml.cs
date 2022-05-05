using DateSoftware.ViewModels;
using DateSoftware.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DateSoftware
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
