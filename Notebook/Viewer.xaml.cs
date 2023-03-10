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
    /// Логика взаимодействия для Viewer.xaml
    /// </summary>
    /// 
   
    public partial class Viewer : Window
    {

        NbContext db = new NbContext();
        public Viewer()
        {
            InitializeComponent();
         
       
                var fio = db.Fiodata.ToList();
            var birthday = db.BirthdayData.ToList();
            foreach (Fiodatum i in fio)
            {
                var p = new ListModel();
                p.FioId = i.FioId;
                p.Name = i.Name;
                p.Surname = i.Surname;
                p.Patronomic = i.Patronomic;
                foreach (BirthdayDatum j in birthday)
                {
                    if (i.FioId == j.FioId)
                    {
                        p.Day = j.Day;
                        p.Month = j.Month;
                        p.Year = j.Year;
                        List.Items.Add(p);
                        break;
                    }
                }
            }
        }

        private void BExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CB_Name_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SearchMark = 1;
            CB_Name.IsChecked = true;
            CB_Surname.IsChecked = false;
            CB_Patronomic.IsChecked = false;
            CB_Year.IsChecked = false;
            CB_Month.IsChecked = false;
            CB_Day.IsChecked = false;
        }

        private void CB_Surname_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SearchMark = 2;
            CB_Name.IsChecked = false;
            CB_Surname.IsChecked = true;
            CB_Patronomic.IsChecked = false;
            CB_Year.IsChecked = false;
            CB_Month.IsChecked = false;
            CB_Day.IsChecked = false;
        }

        private void CB_Patronomic_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SearchMark = 3;
            CB_Name.IsChecked = false;
            CB_Surname.IsChecked = false;
            CB_Patronomic.IsChecked = true;
            CB_Year.IsChecked = false;
            CB_Month.IsChecked = false;
            CB_Day.IsChecked = false;
        }

        private void CB_Day_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SearchMark = 4;
            CB_Name.IsChecked = false;
            CB_Surname.IsChecked = false;
            CB_Patronomic.IsChecked = false;
            CB_Year.IsChecked = false;
            CB_Month.IsChecked = false;
            CB_Day.IsChecked = true;
        }

        private void CB_Month_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SearchMark = 5;
            CB_Name.IsChecked = false;
            CB_Surname.IsChecked = false;
            CB_Patronomic.IsChecked = false;
            CB_Year.IsChecked = false;
            CB_Month.IsChecked = true;
            CB_Day.IsChecked = false;
        }

        private void CB_Year_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SearchMark = 6;
            CB_Name.IsChecked = false;
            CB_Surname.IsChecked = false;
            CB_Patronomic.IsChecked = false;
            CB_Year.IsChecked = true;
            CB_Month.IsChecked = false;
            CB_Day.IsChecked = false;
        }

        private void CBS_Name_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SortMark = 1;
            CBS_Name.IsChecked = true;
            CBS_Surname.IsChecked = false;
            CBS_Patronomic.IsChecked = false;
            CBS_Year.IsChecked = false;
            CBS_Month.IsChecked = false;
            CBS_Day.IsChecked = false;
        }

        private void CBS_Surname_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SortMark = 2;
            CBS_Name.IsChecked = false;
            CBS_Surname.IsChecked = true;
            CBS_Patronomic.IsChecked = false;
            CBS_Year.IsChecked = false;
            CBS_Month.IsChecked = false;
            CBS_Day.IsChecked = false;
        }

        private void CBS_Patronomic_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SortMark = 3;
            CBS_Name.IsChecked = false;
            CBS_Surname.IsChecked = false;
            CBS_Patronomic.IsChecked = true;
            CBS_Year.IsChecked = false;
            CBS_Month.IsChecked = false;
            CBS_Day.IsChecked = false;
        }

        private void CBS_Day_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SortMark = 4;
            CBS_Name.IsChecked = false;
            CBS_Surname.IsChecked = false;
            CBS_Patronomic.IsChecked = false;
            CBS_Year.IsChecked = false;
            CBS_Month.IsChecked = false;
            CBS_Day.IsChecked = true;
        }

        private void CBS_Month_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SortMark = 5;
            CBS_Name.IsChecked = false;
            CBS_Surname.IsChecked = false;
            CBS_Patronomic.IsChecked = false;
            CBS_Year.IsChecked = false;
            CBS_Month.IsChecked = true;
            CBS_Day.IsChecked = false;
        }

        private void CBS_Year_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SortMark = 6;
            CBS_Name.IsChecked = false;
            CBS_Surname.IsChecked = false;
            CBS_Patronomic.IsChecked = false;
            CBS_Year.IsChecked = true;
            CBS_Month.IsChecked = false;
            CBS_Day.IsChecked = false;
        }

        private void BSearch_Click(object sender, RoutedEventArgs e)
        {
            bool check = false;
            if (CRUD.SearchMark == 0)
            {
                MessageBox.Show("Необходимо выбрать параметры поиска!", "HeadEater");
            }
            if (TSearch.Text == "")
            {
                MessageBox.Show("Поле поиска пустое!", "HeadEater");
            }
            else
            {
                var birthday = db.BirthdayData.ToList();
                var fio = db.Fiodata.ToList();
                List.Items.Clear();
                using (NbContext db = new NbContext())
                {
                    if (CRUD.SearchMark == 1)
                    {
                        foreach (Fiodatum i in fio)
                        {
                            if (i.Name == TSearch.Text)
                            {
                                check = true;
                                var p = new ListModel();
                                p.FioId = i.FioId;
                                p.Name = i.Name;
                                p.Surname = i.Surname;
                                p.Patronomic = i.Patronomic;
                                foreach (BirthdayDatum j in birthday)
                                {
                                    if (i.FioId == j.FioId)
                                    {
                                        p.Day = j.Day;
                                        p.Month = j.Month;
                                        p.Year = j.Year;
                                        List.Items.Add(p);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (CRUD.SearchMark == 2)
                    {

                        foreach (Fiodatum i in fio)
                        {
                            if (i.Surname == TSearch.Text)
                            {
                                check = true;
                                var p = new ListModel();
                                p.FioId = i.FioId;
                                p.Name = i.Name;
                                p.Surname = i.Surname;
                                p.Patronomic = i.Patronomic;
                                foreach (BirthdayDatum j in birthday)
                                {
                                    if (i.FioId == j.FioId)
                                    {
                                        p.Day = j.Day;
                                        p.Month = j.Month;
                                        p.Year = j.Year;
                                        List.Items.Add(p);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (CRUD.SearchMark == 3)
                    {

                        foreach (Fiodatum i in fio)
                        {
                            if (i.Patronomic == TSearch.Text)
                            {
                                check = true;
                                var p = new ListModel();
                                p.FioId = i.FioId;
                                p.Name = i.Name;
                                p.Surname = i.Surname;
                                p.Patronomic = i.Patronomic;
                                foreach (BirthdayDatum j in birthday)
                                {
                                    if (i.FioId == j.FioId)
                                    {
                                        p.Day = j.Day;
                                        p.Month = j.Month;
                                        p.Year = j.Year;
                                        List.Items.Add(p);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (CRUD.SearchMark == 4)
                    {
                        foreach (BirthdayDatum i in birthday)
                        {
                            if (Convert.ToString(i.Day) == TSearch.Text)
                            {
                                var p = new ListModel();
                                p.Day = i.Day;
                                p.Month = i.Month;
                                p.Year = i.Year;
                                check = true;
                              
                               
                                foreach (Fiodatum j in fio)
                                {
                                    if (i.FioId == j.FioId)
                                    {
                                        p.FioId = j.FioId;
                                        p.Name = j.Name;
                                        p.Surname = j.Surname;
                                        p.Patronomic = j.Patronomic;
                                        List.Items.Add(p);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (CRUD.SearchMark == 5)
                    {
                        foreach (BirthdayDatum i in birthday)
                        {
                            if (Convert.ToString(i.Month) == TSearch.Text)
                            {
                                var p = new ListModel();
                                p.Day = i.Day;
                                p.Month = i.Month;
                                p.Year = i.Year;
                                check = true;


                                foreach (Fiodatum j in fio)
                                {
                                    if (i.FioId == j.FioId)
                                    {
                                        p.FioId = j.FioId;
                                        p.Name = j.Name;
                                        p.Surname = j.Surname;
                                        p.Patronomic = j.Patronomic;
                                        List.Items.Add(p);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (CRUD.SearchMark == 6)
                    {
                        foreach (BirthdayDatum i in birthday)
                        {
                            if (Convert.ToString(i.Year) == TSearch.Text)
                            {
                                var p = new ListModel();
                                p.Day = i.Day;
                                p.Month = i.Month;
                                p.Year = i.Year;
                                check = true;


                                foreach (Fiodatum j in fio)
                                {
                                    if (i.FioId == j.FioId)
                                    {
                                        p.FioId = j.FioId;
                                        p.Name = j.Name;
                                        p.Surname = j.Surname;
                                        p.Patronomic = j.Patronomic;
                                        List.Items.Add(p);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(check==false)
            {
                List.Items.Clear();
                var fio = db.Fiodata.ToList();
                var birthday = db.BirthdayData.ToList();
                foreach (Fiodatum i in fio)
                {
                    var p = new ListModel();
                    p.FioId = i.FioId;
                    p.Name = i.Name;
                    p.Surname = i.Surname;
                    p.Patronomic = i.Patronomic;
                    foreach (BirthdayDatum j in birthday)
                    {
                        if (i.FioId == j.FioId)
                        {
                            p.Day = j.Day;
                            p.Month = j.Month;
                            p.Year = j.Year;
                            List.Items.Add(p);
                            break;
                        }
                    }
                }
                MessageBox.Show("Записей соответствующих критериям поиска не найдено!", "HeadEater");
            }
            TSearch.Text = "";
        }

        private void BNameSort_Click(object sender, RoutedEventArgs e)
        {
            if(CRUD.SortMark == 0 || CRUD.SortSettingMark==0)
            {
                MessageBox.Show("Нужно выбрать параметры сортировки!", "HeadEater");
            }
            else
            {
            
                List.Items.Clear();
                using (NbContext db = new NbContext())
                {
                    if (CRUD.SortMark == 1 && CRUD.SortSettingMark == 1)
                    {
                        var fio = db.Fiodata.FromSqlRaw("SELECT * FROM FIOData ORDER BY Name").ToList();
                        var birthday = db.BirthdayData.ToList();
                        foreach (Fiodatum i in fio)
                        {
                            var p = new ListModel();
                            p.FioId = i.FioId;
                            p.Name = i.Name;
                            p.Surname = i.Surname;
                            p.Patronomic = i.Patronomic;
                            foreach (BirthdayDatum j in birthday)
                            {
                                if (i.FioId == j.FioId)
                                {
                                    p.Day = j.Day;
                                    p.Month = j.Month;
                                    p.Year = j.Year;
                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 2 && CRUD.SortSettingMark == 1)
                    {
                        var fio = db.Fiodata.FromSqlRaw("SELECT * FROM FIOData ORDER BY Surname").ToList();
                        var birthday = db.BirthdayData.ToList();
                        foreach (Fiodatum i in fio)
                        {
                            var p = new ListModel();
                            p.FioId = i.FioId;
                            p.Name = i.Name;
                            p.Surname = i.Surname;
                            p.Patronomic = i.Patronomic;
                            foreach (BirthdayDatum j in birthday)
                            {
                                if (i.FioId == j.FioId)
                                {
                                    p.Day = j.Day;
                                    p.Month = j.Month;
                                    p.Year = j.Year;
                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 3 && CRUD.SortSettingMark == 1)
                    {
                        var fio = db.Fiodata.FromSqlRaw("SELECT * FROM FIOData ORDER BY Patronomic").ToList();
                        var birthday = db.BirthdayData.ToList();
                        foreach (BirthdayDatum j in birthday)

                        {
                            var p = new ListModel();

                            foreach (Fiodatum i in fio)
                            {
                                p.Day = j.Day;
                                p.Month = j.Month;
                                p.Year = j.Year;
                                if (i.FioId == j.FioId)
                                {
                                    p.FioId = i.FioId;
                                    p.Name = i.Name;
                                    p.Surname = i.Surname;
                                    p.Patronomic = i.Patronomic;

                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 4 && CRUD.SortSettingMark == 1)
                    {
                        var fio = db.Fiodata.ToList();
                        var birthday = db.BirthdayData.FromSqlRaw("SELECT * FROM BirthdayData ORDER BY Day").ToList();
                        foreach (BirthdayDatum j in birthday)

                        {
                            var p = new ListModel();

                            foreach (Fiodatum i in fio)
                            {
                                p.Day = j.Day;
                                p.Month = j.Month;
                                p.Year = j.Year;
                                if (i.FioId == j.FioId)
                                {
                                    p.FioId = i.FioId;
                                    p.Name = i.Name;
                                    p.Surname = i.Surname;
                                    p.Patronomic = i.Patronomic;

                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 5 && CRUD.SortSettingMark == 1)
                    {
                        var fio = db.Fiodata.ToList();
                        var birthday = db.BirthdayData.FromSqlRaw("SELECT * FROM BirthdayData ORDER BY Month").ToList();
                        foreach (BirthdayDatum j in birthday)
                           
                        {
                            var p = new ListModel();
                           
                            foreach (Fiodatum i in fio)
                            {
                                p.Day = j.Day;
                                p.Month = j.Month;
                                p.Year = j.Year;
                                if (i.FioId == j.FioId)
                                {
                                    p.FioId = i.FioId;
                                    p.Name = i.Name;
                                    p.Surname = i.Surname;
                                    p.Patronomic = i.Patronomic;
                                   
                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 6 && CRUD.SortSettingMark == 1)
                    {
                        var fio = db.Fiodata.ToList();
                        var birthday = db.BirthdayData.FromSqlRaw("SELECT * FROM BirthdayData ORDER BY Year").ToList();
                        foreach (BirthdayDatum j in birthday)
                           
                        {
                            var p = new ListModel();
                           
                            foreach (Fiodatum i in fio)
                            {
                                p.Day = j.Day;
                                p.Month = j.Month;
                                p.Year = j.Year;
                                if (i.FioId == j.FioId)
                                {
                                    p.FioId = i.FioId;
                                    p.Name = i.Name;
                                    p.Surname = i.Surname;
                                    p.Patronomic = i.Patronomic;
                                   
                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 1 && CRUD.SortSettingMark == 2)
                    {
                        var fio = db.Fiodata.FromSqlRaw("SELECT * FROM FIOData ORDER BY Name DESC").ToList();
                        var birthday = db.BirthdayData.ToList();
                        foreach (Fiodatum i in fio)
                        {
                            var p = new ListModel();
                            p.FioId = i.FioId;
                            p.Name = i.Name;
                            p.Surname = i.Surname;
                            p.Patronomic = i.Patronomic;
                            foreach (BirthdayDatum j in birthday)
                            {
                                if (i.FioId == j.FioId)
                                {
                                    p.Day = j.Day;
                                    p.Month = j.Month;
                                    p.Year = j.Year;
                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 2 && CRUD.SortSettingMark == 2)
                    {
                        var fio = db.Fiodata.FromSqlRaw("SELECT * FROM FIOData ORDER BY Surname DESC").ToList();
                        var birthday = db.BirthdayData.ToList();
                        foreach (Fiodatum i in fio)
                        {
                            var p = new ListModel();
                            p.FioId = i.FioId;
                            p.Name = i.Name;
                            p.Surname = i.Surname;
                            p.Patronomic = i.Patronomic;
                            foreach (BirthdayDatum j in birthday)
                            {
                                if (i.FioId == j.FioId)
                                {
                                    p.Day = j.Day;
                                    p.Month = j.Month;
                                    p.Year = j.Year;
                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 3 && CRUD.SortSettingMark == 2)
                    {
                        var fio = db.Fiodata.FromSqlRaw("SELECT * FROM FIOData ORDER BY Patronomic DESC").ToList();
                        var birthday = db.BirthdayData.ToList();
                        foreach (Fiodatum i in fio)
                        {
                            var p = new ListModel();
                            p.FioId = i.FioId;
                            p.Name = i.Name;
                            p.Surname = i.Surname;
                            p.Patronomic = i.Patronomic;
                            foreach (BirthdayDatum j in birthday)
                            {
                                if (i.FioId == j.FioId)
                                {
                                    p.Day = j.Day;
                                    p.Month = j.Month;
                                    p.Year = j.Year;
                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 4 && CRUD.SortSettingMark == 2)
                    {
                        var fio = db.Fiodata.ToList();
                        var birthday = db.BirthdayData.FromSqlRaw("SELECT * FROM BirthdayData ORDER BY Day DESC").ToList();
                        foreach (BirthdayDatum j in birthday)

                        {
                            var p = new ListModel();

                            foreach (Fiodatum i in fio)
                            {
                                p.Day = j.Day;
                                p.Month = j.Month;
                                p.Year = j.Year;
                                if (i.FioId == j.FioId)
                                {
                                    p.FioId = i.FioId;
                                    p.Name = i.Name;
                                    p.Surname = i.Surname;
                                    p.Patronomic = i.Patronomic;

                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 5 && CRUD.SortSettingMark == 2)
                    {
                        var fio = db.Fiodata.ToList();
                        var birthday = db.BirthdayData.FromSqlRaw("SELECT * FROM BirthdayData ORDER BY Month DESC").ToList();
                        foreach (BirthdayDatum j in birthday)

                        {
                            var p = new ListModel();

                            foreach (Fiodatum i in fio)
                            {
                                p.Day = j.Day;
                                p.Month = j.Month;
                                p.Year = j.Year;
                                if (i.FioId == j.FioId)
                                {
                                    p.FioId = i.FioId;
                                    p.Name = i.Name;
                                    p.Surname = i.Surname;
                                    p.Patronomic = i.Patronomic;

                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                    if (CRUD.SortMark == 6 && CRUD.SortSettingMark == 2)
                    {
                        var fio = db.Fiodata.ToList();

                        var birthday = db.BirthdayData.FromSqlRaw("SELECT * FROM BirthdayData ORDER BY Year DESC").ToList();
                        foreach (BirthdayDatum j in birthday)

                        {
                            var p = new ListModel();

                            foreach (Fiodatum i in fio)
                            {
                                p.Day = j.Day;
                                p.Month = j.Month;
                                p.Year = j.Year;
                                if (i.FioId == j.FioId)
                                {
                                    p.FioId = i.FioId;
                                    p.Name = i.Name;
                                    p.Surname = i.Surname;
                                    p.Patronomic = i.Patronomic;

                                    List.Items.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void BCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateNote next_wpf = new CreateNote();
            next_wpf.Show();
            Close();
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListModel p = List.SelectedItem as ListModel;
            if (p != null)
            {
                CRUD.id = p.FioId;

            }
        }

        private void BSelect_Click(object sender, RoutedEventArgs e)
        {
            ViewNote next_wpf = new ViewNote();
            next_wpf.Show();
            Close();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            System.DateTime date = new System.DateTime();
            date = DateTime.Now;
            int day = date.Day;
            int month = date.Month;
            var c = db.Congratulations.ToList();
            foreach (Congratulation i in c)
            {
                if (i.Day == day && i.Month == month)
                {
                    CRUD.c_id = i.CId;
                    reminder next_wpf = new reminder();
                    next_wpf.Show();
                }
            }

        }

        private void CBS_Plus_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SortSettingMark = 1;
            CBS_Plus.IsChecked = true;
            CBS_Minus.IsChecked = false;


        }

        private void CBS_Minus_Click(object sender, RoutedEventArgs e)
        {
            CRUD.SortSettingMark = 2;
            CBS_Plus.IsChecked = false;
            CBS_Minus.IsChecked = true;
        }

        private void BClear_Click(object sender, RoutedEventArgs e)
        {
            List.Items.Clear();
            var fio = db.Fiodata.ToList();
            var birthday = db.BirthdayData.ToList();
            foreach (Fiodatum i in fio)
            {
                var p = new ListModel();
                p.FioId = i.FioId;
                p.Name = i.Name;
                p.Surname = i.Surname;
                p.Patronomic = i.Patronomic;
                foreach (BirthdayDatum j in birthday)
                {
                    if (i.FioId == j.FioId)
                    {
                        p.Day = j.Day;
                        p.Month = j.Month;
                        p.Year = j.Year;
                        List.Items.Add(p);
                        break;
                    }
                }
            }
        }
    }
}
