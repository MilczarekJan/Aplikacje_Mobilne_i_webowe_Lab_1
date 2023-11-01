using System.Windows;

namespace P05Shop.Client
{
    public partial class MainWindow : Window
    {
        public ShoeViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ShoeViewModel();
            DataContext = ViewModel;
        }

        private async void GetShoe_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.GetShoe();
        }

        private async void AddShoe_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            var description = DescriptionTextBox.Text;
            await ViewModel.AddShoe(name, description);
        }

        private async void DeleteShoe_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.DeleteShoe();
        }

        private async void UpdateShoe_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            var description = DescriptionTextBox.Text;
            await ViewModel.UpdateShoe(name, description);
        }
    }
}
