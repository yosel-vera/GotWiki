﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GotWiki.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterItemTemplate : ContentView
    {
        public CharacterItemTemplate()
        {
            InitializeComponent();
        }
    }
}