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
using Недвижимость.DB;

namespace Недвижимость.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinEditAgent.xaml
    /// </summary>
    public partial class WinEditAgent : Window
    {
        int idAgent;
        public WinEditAgent(DB.agent agent)
        {
            InitializeComponent();
            this.DataContext = agent;
            idAgent = agent.Id;
        }
        // <summary>
        /// Редактирование агента
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
                    var editAgents = App.entities.agents.FirstOrDefault(c => c.Id == idAgent);
                    editAgents.FirstName = tbfname.Text;
                    editAgents.MiddleName = tbname.Text;
                    editAgents.LastName = tbsname.Text;
                    if (tbdol.Text == "")
                    {
                        editAgents.DealShare = Convert.ToInt32(null);
                    }
                    else
                    {
                        editAgents.DealShare = Convert.ToInt32(tbdol.Text);
                    }   
                    App.entities.SaveChanges();
                    MessageBox.Show("Данные успешно обновлены");
                    this.Close();
                }
            }
           catch { }
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
