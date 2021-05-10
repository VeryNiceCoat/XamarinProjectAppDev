using System;
using Xamarin.Forms;
using XamarinProject.Views;
using Xamarin.Forms.Xaml;

namespace XamarinProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
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
