﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagmentCompany.Pages
{
    /// <summary>
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        public RequestPage()
        {
            InitializeComponent();
            requestListView.ItemsSource = Entities.GetContext().Request.ToList();
        }

        private void requestListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var reqeust = requestListView.SelectedItem as Request;
            if (requestListView.SelectedValue != null)
            {
                NavigationService.Navigate(new AddEditRequestPage(reqeust));
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditRequestPage(null));
        }
    }
}
