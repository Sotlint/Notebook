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
using Microsoft.EntityFrameworkCore;

namespace Notebook
{
    /// <summary>
    /// Логика взаимодействия для CreateNote.xaml
    /// </summary>

    public partial class CreateNote : Window
    {
        NbContext db = new NbContext();
        string gender="";
        public CreateNote()
        {
            InitializeComponent();
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            Viewer next_wpf = new Viewer();
            next_wpf.Show();
            Close();
        }

        private void BCreate_Click(object sender, RoutedEventArgs e)
        {
            
            var people = db.Fiodata.ToList();
            int id = people.Count + 1;

            Fiodatum fio = new Fiodatum();
            AddressDatum address = new AddressDatum();
            ContactDatum contact = new ContactDatum();
            RelationshipsDatum rel = new RelationshipsDatum();
            BirthdayDatum birthday = new BirthdayDatum();   

            fio.FioId = id;
            fio.Name = Tname.Text;
            fio.Surname = TSurname.Text;
            fio.Patronomic = TPatronomic.Text;
            fio.Gender = gender;

            address.AdId = id;
            address.Street = TStreet.Text;
            address.City = TCity.Text;
            address.FioId = id;
            address.ApartNumber = TApNumber.Text;
            address.Floor = TFloor.Text;

            rel.RdId = id;
            rel.FioId = id;
            rel.Role = TRel.Text;
            rel.Description = TBio.Text;

            birthday.BdId = id;
            birthday.FioId = id;

            try
            {
                birthday.Day = Convert.ToInt32(TDay.Text);
                birthday.Month = Convert.ToInt32(TMonth.Text);
                birthday.Year = Convert.ToInt32(TYear.Text);
            }
            catch
            {
                MessageBox.Show("Заполните все поля!", "Notebook");
            }
         
            contact.FioId = id;
            contact.CdId = id;
            contact.Telephone = TTelephone.Text;
            contact.Mail = Tmail.Text;

            if
                (
                Tname.Text == "" && 
                TSurname.Text == "" && 
                TPatronomic.Text == "" && 
                gender == "" && 
                TStreet.Text == "" && 
                TCity.Text == "" && 
                TApNumber.Text == "" && 
                TFloor.Text == "" && 
                TRel.Text == "" &&
                TBio.Text == "" &&
                TDay.Text == "" &&
                TMonth.Text == "" &&
                TYear.Text == "" &&
                TTelephone.Text == "" &&
                Tmail.Text == ""
                )
            {
                MessageBox.Show("Заполните все поля!", "Notebook");
            }
            else
            {
                bool check;
                check = CRUD.CreateNote(fio, address, contact, rel, birthday);
                if(check==true)
                {
                    MessageBox.Show("Успешно!", "Notebook");
                    Viewer next_wpf = new Viewer();
                    next_wpf.Show();
                    Close();
                }

            }
            
        }

        private void CMale_Click(object sender, RoutedEventArgs e)
        {
            gender = "Male";
            CMale.IsChecked = true;
            CFemale.IsChecked = false;
        }

        private void CFemale_Click(object sender, RoutedEventArgs e)
        {
            gender = "Women";
            CMale.IsChecked = false;
            CFemale.IsChecked = true;
        }

        private void TDay_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TMonth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TYear_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
