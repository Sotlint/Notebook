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
    /// Логика взаимодействия для HappyBirthday.xaml
    /// </summary>
    public partial class HappyBirthday : Window
    {
        NbContext db = new NbContext();
        Fiodatum fio = new Fiodatum();
        BirthdayDatum birthday = new BirthdayDatum();
        public HappyBirthday()
        {
            InitializeComponent();
           
            fio=db.Fiodata.Find(CRUD.id);
            birthday = db.BirthdayData.Find(CRUD.id);
            Lname.Content = fio.Name +" "+ fio.Surname +" "+ fio.Patronomic;
            LDate.Content = Convert.ToString(birthday.Day) + "." + Convert.ToString(birthday.Month) + "." + Convert.ToString(birthday.Year);
        }



        private void Bexit_Click(object sender, RoutedEventArgs e)
        {
            Viewer next_wpf = new Viewer();
            next_wpf.Show();
            Close();
        }

        private void BCreate_Click(object sender, RoutedEventArgs e)
        {
            var c = db.Congratulations.ToList();
            int id = c.Count + 1;
            Congratulation congratulation = new Congratulation();
            congratulation.CId = id;
            congratulation.FioId = fio.FioId;
            congratulation.Year = birthday.Year;
            congratulation.Month = birthday.Month;
            congratulation.Day = birthday.Day;
            if (Ttext.Text == "")
            {
                congratulation.Text = "!!!";
            }
            else
            {
                congratulation.Text = Ttext.Text;
            }
            db.Congratulations.Add(congratulation);
            db.SaveChanges();
            Viewer next_wpf = new Viewer();
            next_wpf.Show();
            Close();
        }
    }
}
