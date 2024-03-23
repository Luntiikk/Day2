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
    /// Логика взаимодействия для WinAddAgents.xaml
    /// </summary>
    public partial class WinAddAgents : Window
    {
        public WinAddAgents()
        {
            InitializeComponent();
        }
        // <summary>
        /// Добавление агента
        /// Проверка на заполнение доли в сделке
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
                    DB.agent agent = new DB.agent
                    {
                        FirstName = tbfname.Text,
                        MiddleName = tbname.Text,
                        LastName = tbsname.Text,
                    };
                    if (tbdol.Text == "")
                    {
                        agent.DealShare = Convert.ToInt32(null);
                    }
                    else
                    {
                        agent.DealShare = Convert.ToInt32(tbdol.Text);
                    }
                    App.entities.agents.Add(agent);
                    App.entities.SaveChanges();
                    MessageBox.Show("Данные о риэлторе успешно добавлены");
                    this.Close();
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
