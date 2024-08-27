using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MyRepeatExam
{
    public class Booking
    {
        public int BookingID { get; set; }
        public DateTime BookingsStartDate { get; set; }
        public DateTime BookingEndDate { get; set; }

        //foreign key
        public int KennelID { get; set; }
        //navigation between the 2 classes
        public virtual Kennel Kennel { get; set; }

        public Booking()
        {
            Kennel = new Kennel();
        }

    }

    public class Kennel
    {
        public int KennelID { get; set; }
        //public Enum KennelType {"Basic", "StandardCommands", "Premium"}
        public string Location { get; set; }

        public virtual List<Booking> Bookings { get; set; }

    }

    public class KennelData : DbContext
    {
        public KennelData(string databaseName) : base(databaseName) { }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Kennel> Kennels { get; set; }
    }
}
