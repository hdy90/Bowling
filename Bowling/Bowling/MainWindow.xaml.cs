using Bowling.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Bowling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new BowlingViewModel();
        }

        private void dgFrames_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void btnExpandCollapseClick(object sender, RoutedEventArgs e)
        {
            try
            {
                Button expandCollapseButton = (Button)sender;
                if (expandCollapseButton == null)
                    return;

                DataGridRow dataGridRow = DataGridRow.GetRowContainingElement(expandCollapseButton);
                if (dataGridRow == null)
                    return;

                if (expandCollapseButton.Content.ToString() == "+")
                {
                    dataGridRow.DetailsVisibility = Visibility.Visible;
                    expandCollapseButton.Content = "-";
                }
                else
                {
                    dataGridRow.DetailsVisibility = Visibility.Collapsed;
                    expandCollapseButton.Content = "+";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
