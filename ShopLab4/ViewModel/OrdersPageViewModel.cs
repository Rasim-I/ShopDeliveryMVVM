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
    class OrdersPageViewModel : ViewModelBase
    {

        static DeliveryContext context = new DeliveryContext();
        IUnitOfWork unitOfWork = new UnitOfWork(context);

        //IData _shopData = new ShopData();

        //public OrdersPageViewModel(IData shopData)
        //{
        //    this._shopData = shopData;
        //}


        public ObservableCollection<Order> Orders { get; }        



        public OrdersPageViewModel()
        {
            Orders = new ObservableCollection<Order>(unitOfWork.Orders.OrdersWithReferences());
          
        }


    }
}
