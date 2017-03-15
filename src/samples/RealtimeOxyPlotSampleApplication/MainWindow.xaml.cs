using OxyPlotDemo.ViewModels;
using System.Windows;

namespace GraphWpfApplication
{
    public partial class MainWindow : Window
    {
        private MainWindowModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowModel(Plot1);
            DataContext = viewModel;
        }
    }
}
