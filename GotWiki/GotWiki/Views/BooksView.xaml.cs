using GotWiki.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GotWiki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksView : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public BooksView(BooksViewModel viewModel = null)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

    }
}
