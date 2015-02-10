using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public class App : Application
    {
        public App()
        {
            var vm = new Page1ViewModel()
            {
                OneData  = new      ItemViewModel() { intBase = 100, intResult = 100 },
                ListData = new List<ItemViewModel>() 
                {
                           new      ItemViewModel() { intBase = 200, intResult = 200 },
                           new      ItemViewModel() { intBase = 201, intResult = 201 },
                }
            };
            MainPage = new Page1() { BindingContext = vm };
        }
    }
    public class Page1ViewModel : ViewModelBase
    {
        private      ItemViewModel  _OneData { get; set; }
        public       ItemViewModel   OneData { get { return _OneData; } set { _OneData = value; OnPropertyChanged(); } }

        private List<ItemViewModel> _ListData { get; set; }
        public  List<ItemViewModel>  ListData { get { return _ListData; } set { _ListData = value; OnPropertyChanged(); } }

        public ICommand  CmdAdd { get { return _CmdAdd; } }
        private Command _CmdAdd = new Command<ItemViewModel>((instance) =>
        {
            instance.intResult = instance.intBase + 1;
        });
    }
    public class ItemViewModel : ViewModelBase
    {
        private int _intBase { get; set; }
        public  int  intBase { get { return _intBase; } set { _intBase = value; OnPropertyChanged(); } }

        private int _intResult { get; set; }
        public  int  intResult { get { return _intResult; } set { _intResult = value; OnPropertyChanged(); } }
    }

    #region ViewModelBase
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            { handler(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
    #endregion
}
