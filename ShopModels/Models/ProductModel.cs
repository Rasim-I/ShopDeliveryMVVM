using Shop.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Shop.Models.EnumSet;
using Type = Shop.Models.EnumSet.Type;

namespace Shop
{
    public class ProductModel //: INotifyPropertyChanged
    {
        public override string ToString()
        {
            return _name;
        }

        private string _name { get; set; }
        private Guid _Id { get; set; }


        private Size _size { get; set; }
        private Type _type { get; set; }
        private int _weight { get; set; }
        private int _quantity { get; set; }


        public Guid Id
        {
            get => _Id;
            set
            {
                _Id = value;
                
            }
        }

        public string name
        {
            get => _name;
            set
            {
                _name = value;
               
            }
        }

        public EnumSet.Size size
        {
            get => _size;
            set
            {
                _size = value;

            }
        }

        public EnumSet.Type type
        {
            get => _type;
            set
            {
                _type = value;

            }
        }

        public int Weight
        {
            get => _weight;
            set
            {
                _weight = value;

            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;

            }
        }

        

        

        public ProductModel(string name, Type type, int weight, Size size, int quantity)
        {
            Id = Guid.NewGuid();
            this._quantity = quantity;
            this._name = name;
            this.type = type;
            this._weight = weight;
            this.size = size;
        }


        public ProductModel() { }




        /*
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        */
    }
}
