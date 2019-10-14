using GotWiki.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GotWiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HouseDetailsView : ContentPage
    {
        public HouseDetailsView(HouseDetailsViewModel viewModel = null)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}