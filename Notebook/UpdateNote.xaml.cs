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
    /// Логика взаимодействия для UpdateNote.xaml
    /// </summary>
    public partial class UpdateNote : Window
    {

        NbContext db = new NbContext();
        string gender = "";
        public UpdateNote()
        {
            InitializeComponent();
            Fiodatum fio = new Fiodatum();
            AddressDatum address = new AddressDatum();
            ContactDatum contact = new ContactDatum();
            RelationshipsDatum rel = new RelationshipsDatum();
            BirthdayDatum birthday = new BirthdayDatum();

         
            fio = db.Fiodata.Find(CRUD.id);
            address = db.AddressData.Find(CRUD.id);
            contact = db.ContactData.Find(CRUD.id);
            rel = db.RelationshipsData.Find(CRUD.id);
            birthday = db.BirthdayData.Find(CRUD.id);

            Tname.Text = fio.Name;
            TSurname.Text = fio.Surname;
            TPatronomic.Text = fio.Patronomic;
            TStreet.Text = address.Street;
            TCity.Text = address.City;
            TApNumber.Text = address.ApartNumber;
            TFloor.Text = address.ApartNumber;
            TRel.Text = rel.Role;
            TBio.Text = rel.Description;
            TDay.Text = Convert.ToString(birthday.Day);
            TMonth.Text = Convert.ToString(birthday.Month);
            TYear.Text = Convert.ToString(birthday.Year);
            TTelephone.Text = contact.Telephone;
            Tmail.Text = contact.Mail;

            if(fio.Gender=="Male")
            {
                gender = "Male";
                CMale.IsChecked = true;
                CFemale.IsChecked = false;
            }
            if(fio.Gender=="Female")
            {
                gender = "Women";
                CMale.IsChecked = false;
                CFemale.IsChecked = true;
            }
        }

        private void TDay_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            ViewNote next_wpf = new ViewNote();
            next_wpf.Show();
            Close();
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

        private void BUpdate_Click(object sender, RoutedEventArgs e)
        {

            Fiodatum fio = new Fiodatum();
            AddressDatum address = new AddressDatum();
            ContactDatum contact = new ContactDatum();
            RelationshipsDatum rel = new RelationshipsDatum();
            BirthdayDatum birthday = new BirthdayDatum();

            fio = db.Fiodata.Find(CRUD.id);
            address = db.AddressData.Find(CRUD.id);
            contact = db.ContactData.Find(CRUD.id);
            rel = db.RelationshipsData.Find(CRUD.id);
            birthday = db.BirthdayData.Find(CRUD.id);


            fio.Name = Tname.Text;
            fio.Surname = TSurname.Text;
            fio.Patronomic = TPatronomic.Text;
            fio.Gender = gender;

         
            address.Street = TStreet.Text;
            address.City = TCity.Text;

            address.ApartNumber = TApNumber.Text;
            address.Floor = TFloor.Text;

         
       
            rel.Role = TRel.Text;
            rel.Description = TBio.Text;


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
                check = CRUD.UpdateNote(fio, address, contact, rel, birthday);
                if (check == true)
                {
                    MessageBox.Show("Успешно!", "Notebook");
                    Viewer next_wpf = new Viewer();
                    next_wpf.Show();
                    Close();
                }

            }

        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            Fiodatum fio = new Fiodatum();
            fio = db.Fiodata.Find(CRUD.id);
            CRUD.DelNote(fio);
            Viewer next_wpf = new Viewer();
            next_wpf.Show();
            Close();
        }
    }
}
