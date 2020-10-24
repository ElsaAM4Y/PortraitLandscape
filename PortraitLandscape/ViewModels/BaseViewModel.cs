using PortraitLandscape.ContentViews;
using PortraitLandscape.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PortraitLandscape.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private DisplayOrientation currentOrientation;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _myContentView;
        public string MyContentView
        {
            get
            {
                return _myContentView;
            }
            set
            {
                if (_myContentView != value)
                {
                    _myContentView = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public BaseViewModel()
        {
            currentOrientation = DeviceDisplay.MainDisplayInfo.Orientation;

            // Subscribe to changes of screen metrics
            DeviceDisplay.MainDisplayInfoChanged += OnMainDisplayInfoChanged;

            AdjustForOrientation(MyContentView);
        }

        void OnMainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
        {
            // Process changes
            if (e.DisplayInfo.Orientation != currentOrientation)
            {
                currentOrientation = e.DisplayInfo.Orientation;
                AdjustForOrientation(MyContentView);
            }
        }

        public static string AdjustForOrientation(string MyContentView)
        {
            if (DeviceDisplay.MainDisplayInfo.Orientation == DisplayOrientation.Landscape)
            {
                 MyContentView = "LandscapePage1";
            }
            else
            {
                MyContentView = "Portrait";
            }
            return MyContentView;

        }
    }
}
