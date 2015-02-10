using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        { InitializeComponent(); }
        public void OnClicked(object sender, EventArgs e)
        {
            if (BindingContext != null)
            {
                var vm = BindingContext as Page1ViewModel;
                var cell = ((sender as VisualElement).Parent.Parent as ViewCell).BindingContext as ItemViewModel;
                vm.CmdAdd.Execute(cell);
            }
        }
    }
}
