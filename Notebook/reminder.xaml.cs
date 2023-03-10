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

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для reminder.xaml
    /// </summary>
    public partial class reminder : Window
    {
        NbContext db = new NbContext();
        Fiodatum fio = new Fiodatum();
        BirthdayDatum birthday = new BirthdayDatum();
        Congratulation congratulation = new Congratulation();
        public reminder()
        {
            InitializeComponent();
           
            congratulation=db.Congratulations.Find(CRUD.c_id);
            fio = db.Fiodata.Find(congratulation.FioId);
            birthday = db.BirthdayData.Find(congratulation.FioId);
            Lname.Content = fio.Name + " " + fio.Surname + " " + fio.Patronomic;
            LDate.Content = Convert.ToString(birthday.Day) + "." + Convert.ToString(birthday.Month) + "." + Convert.ToString(birthday.Year);
            Ttext.Text = congratulation.Text;
        }

        private void Bexit_Click(object sender, RoutedEventArgs e)
        {

            db.Congratulations.Remove(congratulation);
            db.SaveChanges();
            Close();
        }
    }
}
