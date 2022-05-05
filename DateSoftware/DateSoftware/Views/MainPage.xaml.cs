﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DateSoftware.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {

        public MainPage()
        {
            InitializeComponent();
            this.Master = new MasterPage();
            this.Detail = new NavigationPage(new DetailPage());
            App.MasterDet = this;
        }
    }
}