using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Shop
{
    public class PlaceModel //: INotifyPropertyChanged
    {
        private Guid _Id { get; set; }
        private string _name { get; set; }
        private int _distance { get; set; }


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


        public int distance
        {
            get => _distance;
            set
            {
                _distance = value;
                
            }
        }



        public override string ToString()
        {
            return name;
        }

        //int delivery_time

        public PlaceModel(string name, int distance)
        {
            Id = Guid.NewGuid();
            this.distance = distance;
            this.name = name;
        }

        public PlaceModel()
        {

        }





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
