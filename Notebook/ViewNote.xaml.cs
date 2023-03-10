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
    /// Логика взаимодействия для ViewNote.xaml
    /// </summary>
    public partial class ViewNote : Window
    {
        NbContext db = new NbContext();

        Fiodatum fio = new Fiodatum();
        AddressDatum address = new AddressDatum();
        ContactDatum contact = new ContactDatum();
        RelationshipsDatum rel = new RelationshipsDatum();
        BirthdayDatum birthday = new BirthdayDatum();
        public ViewNote()
        {
            InitializeComponent();




            fio = db.Fiodata.Find(CRUD.id);
            address = db.AddressData.Find(CRUD.id);
            contact = db.ContactData.Find(CRUD.id);
            rel = db.RelationshipsData.Find(CRUD.id);
            birthday = db.BirthdayData.Find(CRUD.id);

            Tname.Text = fio.Name;
            TSurname.Text = fio.Surname;
            TPatronomic.Text = fio.Patronomic;
            gender.Content = fio.Gender;
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


        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            Viewer next_wpf = new Viewer();
            next_wpf.Show();
            Close();
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

        private void BCreate_Click(object sender, RoutedEventArgs e)
        {
            UpdateNote next_wpf = new UpdateNote();
            next_wpf.Show();
            Close();
        }

        private void BDel_Click(object sender, RoutedEventArgs e)
        {
            HappyBirthday next_wpf = new HappyBirthday();
            next_wpf.Show();
            Close();
        }
    }
}
