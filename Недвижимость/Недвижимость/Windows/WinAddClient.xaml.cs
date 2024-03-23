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
    /// Логика взаимодействия для WinAddClient.xaml
    /// </summary>
    public partial class WinAddClient : Window
    {
        public WinAddClient()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Добавление клиента
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
                    DB.client client = new DB.client
                    {
                        FirstName = tbfname.Text,
                        MiddleName = tbname.Text,
                        LastName = tbsname.Text,
                    };
                    if (tbphone.Text == "")
                    {
                        client.Phone = null;
                        if(tbemail.Text == "")
                            client.Email = null;
                        else
                            client.Email = tbemail.Text;
                    }
                    else
                    {
                        client.Phone = tbphone.Text;
                    }
                    if (tbphone.Text == "" & tbemail.Text == "")
                        MessageBox.Show("Необходимо обязательно " +
                            "заполнить либо почту, либо телефон");
                    else
                    {
                        App.entities.clients.Add(client);
                        App.entities.SaveChanges();
                        MessageBox.Show("Данные о клиента успешно добавлены");
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
