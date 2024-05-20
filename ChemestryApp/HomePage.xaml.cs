using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace ChemestryApp
{
    public partial class HomePage : Page
    {
        private Dictionary<string, string> _topics;

        public HomePage()
        {
            InitializeComponent();

            _topics = new Dictionary<string, string>
            {
                { "Тела и вещества", "pdf\\02.pdf" },
                { "Физические и химические процессы", "pdf\\03.pdf" },
                { "Химические элементы", "pdf\\04.pdf" }
            };

            foreach (var topic in _topics.Keys)
            {
                TopicsListBox.Items.Add(topic);
            }
        }

        private void GoToMendeleev_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.MainFrame.Navigate(new ViewMendeleevPage());
        }

        private void TopicsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TopicsListBox.SelectedItem == null)
            {
                return;
            }

            string pdfPath = _topics[TopicsListBox.SelectedItem.ToString()];

            if (File.Exists(pdfPath))
            {
                Process.Start(pdfPath);
            }
            else
            {
                MessageBox.Show($"File '{pdfPath}' not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            TopicsListBox.SelectedItem = null;
        }

        private void as_Click(object sender, RoutedEventArgs e)
        {
            string topic = TopicTextBox.Text.Trim();
            string pdfPath = PdfPathTextBox.Text.Trim();

            if (string.IsNullOrEmpty(topic) || string.IsNullOrEmpty(pdfPath) || !File.Exists(pdfPath))
            {
                MessageBox.Show("Invalid input. Please enter a non-empty topic and a valid PDF path.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_topics.ContainsKey(topic))
            {
                MessageBox.Show("A topic with this name already exists. Please choose a different name.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _topics.Add(topic, pdfPath);
            TopicsListBox.Items.Add(topic);

            TopicTextBox.Clear();
            PdfPathTextBox.Clear();
        }
    }
}
    


    

