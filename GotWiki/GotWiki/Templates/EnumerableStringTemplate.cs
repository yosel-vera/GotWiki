using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Xamarin.Forms;

namespace GotWiki.Templates
{
    public class EnumerableStringTemplate : ContentView
    {

        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create("Items", typeof(IEnumerable<string>), typeof(IEnumerable<string>), null);

        public IEnumerable<string> Items
        {
            get { return (IEnumerable<string>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
        public EnumerableStringTemplate()
        {
            Content = CreateContent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == nameof(Items))
                Content = CreateContent();
        }

        private StackLayout CreateContent()
        {
            var stack = new StackLayout();
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    stack.Children.Add(new Label
                    {
                        Text = $"- {item}",
                        Style = (Style)App.Current.Resources["BodyLabel"]
                    });
                }
            }
            return stack;
        }

    }
}