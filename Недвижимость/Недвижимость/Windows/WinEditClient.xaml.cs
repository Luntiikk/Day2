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
using System.Windows.Shapes;

namespace Недвижимость.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinEditClient.xaml
    /// </summary>
    public partial class WinEditClient : Window
    {
        int idClient;
        public WinEditClient(DB.client client)
        {
            InitializeComponent();
            this.DataContext = client;
            idClient = client.Id;
        }
        // <summary>
        /// Редактирование клиента
        /// Проверка на заполнение почты или номера
        /// </summary>
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbfname.Text == null | tbname.Text == null | tbsname.Text == "")
                {
                    MessageBox.Show("Заполните поля");
                }
                else
                {
                    var editClient = App.entities.clients.
                        FirstOrDefault(c => c.Id == idClient);
                    editClient.FirstName = tbfname.Text;
                    editClient.MiddleName = tbname.Text;
                    editClient.LastName = tbsname.Text;
                    if (tbphone.Text == "")
                    {
                        editClient.Phone = null;
                        if (tbemail.Text == "")
                            editClient.Email = null;
                        else
                            editClient.Email = tbemail.Text;
                    }
                    else
                    {
                        editClient.Phone = tbphone.Text;
                    }
                    if (tbphone.Text == "" & tbemail.Text == "")
                        MessageBox.Show("Необходимо обязательно заполнить либо почту, либо телефон");
                    else
                    {
                        App.entities.SaveChanges();
                        MessageBox.Show("Данные о клиента успешно обновлены");
                        this.Close();
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show("Возможно, неверны данные");
            }
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
