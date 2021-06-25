using System;
using System.Windows;

namespace Eighth
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        private readonly ITimer _timer;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = _timer = new Timer2();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            _timer.Pause();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            _timer.Reset();
        }

        public void Dispose()
        {
            _timer?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
