using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static Shop.Models.EnumSet;

namespace Shop
{
    public class TransportModel //: INotifyPropertyChanged
    {
        private Guid _Id { get; set; }
        private string _name { get; set; }

        private Capacity _capacity;

        private Speed _speed;

        private State _state;

        private TimeSpan _TimeUntilFree;


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

        public Capacity capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;

            }
        }

        public Speed speed
        {
            get => _speed;
            set
            {
                _speed = value;

            }
        }

        public State state
        {
            get => _state;
            set
            {
                _state = value;

            }
        }

        public TimeSpan TimeUntilFree
        {
            get => _TimeUntilFree;
            set
            {
                _TimeUntilFree = value;
                if(state == State.free)
                {
                    state = State.transit;
                }

            }
        }

        


        public TransportModel(string name)
        {
            this.name = name;
            this.speed = speed;
            this.capacity = capacity;
            //this.name = name;
            state = State.free;
        }
        public TransportModel() { }

        public virtual bool isCompatible(ProductModel product)
        {
                return true;
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
