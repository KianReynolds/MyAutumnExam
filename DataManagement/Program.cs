using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyRepeatExam;

namespace DataManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KennelData db = new KennelData("OODExam_KianReynolds");

            using (db)
            {
                Kennel k1 = new Kennel() { Location = "outdoor" };
                Kennel k2 = new Kennel() { Location = "indoors" };
                Kennel k3 = new Kennel() { Location = "house" };

                Booking b1= new Booking();
                b1.Kennels.Add(k1);
                b1.Kennels.Add(k2);
                b1.Kennels.Add(k3);

                db.Bookings.Add(b1);

                db.SaveChanges();
            }
        }
    }
}
