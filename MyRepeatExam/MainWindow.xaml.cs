using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MyRepeatExam.Kennel;

namespace MyRepeatExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KennelData db = new KennelData("OOD_KianReynolds");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //populate kennels listbox
            //lbxKennels.ItemsSource = Enum.GetNames(typeof(Kennel));
           
            //populate kennels info 
            var query = from k in db.Bookings
                        orderby k.Kennels
                        select k.Kennels;

            lbxKennels.ItemsSource = query.ToList();
        }

        private void lbxKennels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string kennel = lbxKennels.SelectedItem as string;

            if (kennel != null)
            {
                var query = from k in db.Bookings
                            where k.Kennels.Equals(kennel)
                            select new OrderSummary
                            {
                                KennelID = k.KennelID,
                                KennelType = k.KennelType,
                                Location = k.Location,
                                BookingsStartDate = k.BookingsStartDate,
                                BookingEndDate = k.BookingEndDate
                            };
               
                tblxKennelInfo.ItemsSource = query.ToList();
            }
        }

        public class OrderSummary: Booking
        {
            public override string ToString()
            {
                return string.Format("{0} {1} {2} {3} {4}", KennelID, KennelType, Location, BookingsStartDate, BookingEndDate);
            }
        }


    }
}
