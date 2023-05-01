namespace mis_221_pa_5_cbosvath
{
    public class BookingReport
    {
        Booking[] bookings;
    
        public BookingReport(Booking[] bookings){
            this.bookings = bookings;
        }

        //print all bookings in to console for the user
        public void PrintAllBookings(){
            for(int i =0; i < Booking.GetCount(); i++){
                System.Console.WriteLine(bookings[i].ToString());
            }
        }
    }
}