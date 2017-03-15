using OxyPlotDemo.ViewModels;
using System.Windows;

namespace GraphWpfApplication
{
    public partial class MainWindow : Window
    {
        private MainWindowModel viewModel;

        public MainWindow()
        {
            viewModel = new MainWindowModel();
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
