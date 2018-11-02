using System;
using System.Collections.Generic;
using AgendaCelulas.Models;
using Xamarin.Forms;

namespace AgendaCelulas.Pages
{
    public partial class DetalhePage : ContentPage
    {
        public DetalhePage(Celula celula)
        {
            InitializeComponent();

            BindingContext = celula;
        }
    }
}
