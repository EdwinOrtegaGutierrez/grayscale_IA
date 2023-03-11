using ModernDesign.Core;

namespace GUI.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {
        // Create command for xaml main 
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand ConvertViewCommand { get; set; }
        public RelayCommand HistogramViewCommand { get; set; }
        public RelayCommand ThresholdViewCommand { get; set; }
        public RelayCommand LBPViewCommand { get; set; }
        public RelayCommand CloseApp { get; set; }

        // Create the diferent views between others
        public HomeViewModel HomeVM { get; set; }
        public ConvertViewModel ConvertVM { get; set; }
        public HistogramViewModel HistogramVM { get; set; }
        public ThresholdViewModel ThresholdVM { get; set; }
        public LBPViewModel LBPVM { get; set; }

        // Logic for change view
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            ConvertVM = new ConvertViewModel();
            HistogramVM = new HistogramViewModel();
            ThresholdVM = new ThresholdViewModel();
            LBPVM = new LBPViewModel();
            CurrentView = HomeVM;

            // Change View in the panel
            HomeViewCommand = new RelayCommand(o => { CurrentView = HomeVM; });

            ConvertViewCommand = new RelayCommand(o => { CurrentView = ConvertVM; });

            HistogramViewCommand = new RelayCommand(o => { CurrentView = HistogramVM; });

            ThresholdViewCommand = new RelayCommand(o => { CurrentView = ThresholdVM; });

            LBPViewCommand = new RelayCommand(o => { CurrentView = LBPVM; });

            // Close app
            CloseApp = new RelayCommand(o => { System.Windows.Application.Current.Shutdown(); });
        }
    }
}
