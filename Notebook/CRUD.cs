using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Notebook
{
    internal static class CRUD
    {

        public static long? c_id;
        public static long? id;
        public static int SearchMark = 0;
        public static int SortMark = 0;
        public static int SortSettingMark = 0;


        public static bool CreateNote(Fiodatum fio, AddressDatum address, ContactDatum contact, RelationshipsDatum rel, BirthdayDatum birthday)
        {
            bool check = true;
            using (NbContext db = new NbContext())
            {
                var c = db.ContactData.ToList();
                foreach (ContactDatum i in c)
                {
                    if (i.Telephone == contact.Telephone)
                    {
                        MessageBox.Show("Такой номер телефона уже используется!", "HeadEater");
                        check = false;
                        break;

                    }
                    if (i.Mail == contact.Mail)
                    {
                        MessageBox.Show("Такой почтовый адрес уже используется!", "HeadEater");
                        check = false;
                        break;
                    }
                }

                if (check == true)
                {
                    db.Add(fio);
                    db.SaveChanges();
                    db.Add(address);
                    db.Add(contact);
                    db.Add(rel);
                    db.Add(birthday);
                    db.SaveChanges();
                }

            }
            return check;
        }

        public static bool UpdateNote(Fiodatum fio, AddressDatum address, ContactDatum contact, RelationshipsDatum rel, BirthdayDatum birthday)
        {
            bool check = true;
            using (NbContext db = new NbContext())
            {


                var c = db.ContactData.ToList();
                foreach (ContactDatum i in c)
                {
                    if (i.FioId != contact.FioId)
                    {
                        if (i.Telephone == contact.Telephone)
                        {
                            MessageBox.Show("Такой номер телефона уже используется!", "HeadEater");
                            check = false;
                            break;

                        }
                        if (i.Mail == contact.Mail)
                        {
                            MessageBox.Show("Такой почтовый адрес уже используется!", "HeadEater");
                            check = false;
                            break;
                        }
                    }
                }
                using (NbContext db1 = new NbContext())
                {
                    if (check == true)
                    {

                        db1.Fiodata.Update(fio);
                        db1.AddressData.Update(address);
                        db1.ContactData.Update(contact);
                        db1.RelationshipsData.Update(rel);
                        db1.BirthdayData.Update(birthday);
                        db1.SaveChanges();


                    }
                }

            }
            return check;
        }
        public static void DelNote(Fiodatum fio)
        {
            using (NbContext db = new NbContext())
            {
                db.Fiodata.Remove(fio);
                db.SaveChanges();
            }
        }

    }
}
