﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncionarioPage : ContentPage
	{
		public FuncionarioPage ()
		{
			InitializeComponent ();
            this.BindingContext = new ViewModel.FuncionarioViewModel();
        }
	}
}