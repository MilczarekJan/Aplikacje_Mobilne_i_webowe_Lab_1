using System.Windows;
using P05WPF.ViewModels;

namespace P05WPF //To jest tak samo
{
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _viewModel;
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            //accuWeatherService = new AccuWeatherService();
        }
    }
}
