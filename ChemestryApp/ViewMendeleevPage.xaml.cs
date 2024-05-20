using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace ChemestryApp
{
    public partial class ViewMendeleevPage : Page
    {
        public ViewMendeleevPage()
        {
            InitializeComponent();
            UpdateSource();
        }
        private void UpdateSource()
        {
            var source2 = MendeleevEntities.GetContext();
            var source3 = source2.MendelevDB;
            var source = source3.ToList();
            if (!String.IsNullOrWhiteSpace(SearchBar.Text)) 
            {
                source = source.Where(x => x.Element.ToLower().Contains(SearchBar.Text.ToLower())).ToList();
            }
            ViewElementsLV.ItemsSource = source;
        }
        

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSource();
        }

        private void GoToTable_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new TablePage());
        }
    }
}
