using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ReproFlipView
{
    public class FakeDataSource : INotifyPropertyChanged
    {
        //  = new List<string> { "Item 1", "Item 2" };
        private Dictionary<string, List<string>> _flipViewItems;

        public Dictionary<string, List<string>> FlipViewItems
        {
            get { return _flipViewItems; }
            set
            {
                _flipViewItems = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public FakeDataSource()
        {
            FlipViewItems = new Dictionary<string, List<string>> {
                { 
                    "Item 1", new List<string>{
                        "Multiple 1",
                        "Multiple 2",
                        "Multiple 3"
                    } 
                },
                {
                    "Item 2", new List<string>{
                        "Multiple 4",
                        "Multiple 5",
                        "Multiple 6"
                    }
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
