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

namespace Недвижимость
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void agents_Click(object sender, RoutedEventArgs e)
        {
            gridAgent.Visibility = Visibility.Visible;
            gridClient.Visibility = Visibility.Hidden;
            dgAgents.ItemsSource = App.entities.agents.ToList();
        }

        private void clients_Click(object sender, RoutedEventArgs e)
        {
            gridClient.Visibility = Visibility.Visible;
            gridAgent.Visibility = Visibility.Hidden;
            dgClients.ItemsSource = App.entities.clients.ToList();
        }

        private void btAddClients_Click(object sender, RoutedEventArgs e)//добавление клиента
        {
            Windows.WinAddClient winAddClient = new Windows.WinAddClient();
            winAddClient.ShowDialog();
            dgClients.ItemsSource = App.entities.clients.ToList();
        }

        private void btAddAgents_Click(object sender, RoutedEventArgs e)//добавление агента
        {
            Windows.WinAddAgents winAddAgents = new Windows.WinAddAgents();
            winAddAgents.ShowDialog();
            dgAgents.ItemsSource = App.entities.agents.ToList();
        }

        private void btEditAgents_Click(object sender, RoutedEventArgs e)//редактирование агента
        {
            var editAgent = dgAgents.SelectedItem as DB.agent;
            if(editAgent != null)
            {
                Windows.WinEditAgent winEditAgent = 
                    new Windows.WinEditAgent(editAgent);
                winEditAgent.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для редактирования");
            }
        }

        private void btDeleteAgents_Click(object sender, RoutedEventArgs e)//удаление агента
        {
            var deleteAgent  = dgAgents.SelectedItem as DB.agent;
            if(deleteAgent != null)
            {
                MessageBoxResult result = MessageBox.Show
                    ("Вы уверены, что хотите удалить данные об агенте", 
                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    App.entities.agents.Remove(deleteAgent);
                    App.entities.SaveChanges();
                    dgAgents.ItemsSource = App.entities.agents.ToList();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для удаления");
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)//поиск по ФИО
        {
            if(gridAgent.Visibility == Visibility.Visible)
            {
                var searchAgent = App.entities.agents.Where(c=>c.FirstName.
                Contains(tbSearch.Text)| c.MiddleName.Contains(tbSearch.Text)
                | c.LastName.Contains(tbSearch.Text)).ToList();
                dgAgents.ItemsSource = searchAgent;
            }
            else
            {
                MessageBox.Show("Ничего не найдено");
            }
            if(dgClients.Visibility == Visibility.Visible)
            {
                var searchClient = App.entities.clients.Where(c=>c.FirstName.
                Contains(tbSearch.Text) | c.MiddleName.Contains (tbSearch.Text)|
                c.LastName.Contains(tbSearch.Text)).ToList();
                dgClients.ItemsSource = searchClient;
            }
            else
            {
                MessageBox.Show("Ничего не найдено");
            }
        }

        private void btEditClients_Click(object sender, RoutedEventArgs e)//редактирование клиента
        {
            var editClient = dgClients.SelectedItem as DB.client;
            if(editClient != null)
            {
                Windows.WinEditClient winEditClient =
                    new Windows.WinEditClient(editClient);
                winEditClient.ShowDialog();
                dgClients.ItemsSource = App.entities.clients.ToList();
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для редактирования");
            }
        }

        private void btDeleteCliens_Click(object sender, RoutedEventArgs e)//удаление клиента
        {
            var deleteClient = dgClients.SelectedItem as DB.client;
            if (deleteClient != null)
            {
                MessageBoxResult result = MessageBox.Show
                    ("Вы уверены, что хотите удалить данные об агенте",
                    "Подтверждение удаления", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    App.entities.clients.Remove(deleteClient);
                    App.entities.SaveChanges();
                    dgClients.ItemsSource = App.entities.clients.ToList();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали строку для удаления");
            }
        }
    }
}
