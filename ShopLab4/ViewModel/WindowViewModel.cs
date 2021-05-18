using Shop;
using Shop.Data;
using ShopLab4.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopLab4.ViewModel
{
    internal class WindowViewModel : ViewModelBase
    {

        #region Title

        private string _Title = "Product ordering";

        public string Title
        {
            get { return _Title; }
            set
            {
                if (Equals(_Title, value)) return;
                _Title = value;
                OnPropertyChanged();
                //Set(ref _Title, value);
            }
        }

        #endregion

        #region command

        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommand(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        #endregion


        public WindowViewModel()
        {
            
            CloseApplicationCommand = new ActionCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommand);

        }


    }
}



