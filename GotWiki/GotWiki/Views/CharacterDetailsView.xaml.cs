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
    public partial class CharacterDetailsView : ContentPage
    {
        public CharacterDetailsView(CharacterDetailsViewModel viewModel = null)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}