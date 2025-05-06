using System;
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
    /// Логика взаимодействия для AddEditRequestPage.xaml
    /// </summary>
    public partial class AddEditRequestPage : Page
    {
        private Request _currentRequest = new Request();
        public AddEditRequestPage(Request request)
        {
            InitializeComponent();
            if (request != null)
            {
                _currentRequest = request;
            }
            ownerCb.ItemsSource = Entities.GetContext().Owners.ToList();
            workerCb.ItemsSource = Entities.GetContext().Workers.ToList();
            addressCb.ItemsSource = Entities.GetContext().Address.ToList();
            statusCb.ItemsSource = Entities.GetContext().StatusType.ToList();
            DataContext = _currentRequest;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (ownerCb.SelectedValue == null)
            {
                sb.AppendLine("Выберите владельца!");
            }
            if (workerCb.SelectedValue == null)
            {
                sb.AppendLine("Выберите сотрудника!");
            }
            if(statusCb.SelectedValue == null)
            {
                sb.AppendLine("Выберите сотрудника!");
            }
            if (addressCb.SelectedValue == null)
            {
                sb.AppendLine("Выберите адресс");
            }
            try
            {
                int idAddres = (int) addressCb.SelectedValue;
                int flat_id = Entities.GetContext().Flat.Where(p => p.address_id == idAddres).FirstOrDefault(c => c.flat_number == flatTb.Text).id;
                _currentRequest.flat_id = flat_id;
            }
            catch (Exception)
            {
                sb.AppendLine("Ошибка поиска квартиры!");
            }
            if (sb.Length == 0)
            {
                if (_currentRequest.id == 0)
                {
                    Entities.GetContext().Request.Add(_currentRequest);
                }

                try
                {
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Данные успешно сохранены!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка сохранения!\n" + ex.Message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
            } else
            {
                MessageBox.Show(sb.ToString(), "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }
    }
}
