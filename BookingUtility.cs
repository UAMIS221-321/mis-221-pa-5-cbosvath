namespace mis_221_pa_5_cbosvath
{
    public class BookingUtility
    {
        private Booking[] bookings;

        public BookingUtility(Booking[] bookings){
            this.bookings = bookings;
        }
        //get all bookings from file
        public void GetAllBookings(){
            StreamReader inFile = new StreamReader("transactions.txt");

            Booking.SetCount(0);
            string line=inFile.ReadLine();
            while(line!=null){
                string[] temp = line.Split('#');
                bookings[Booking.GetCount()] = new Booking(int.Parse(temp[0]), temp[1],temp[2],temp[3], int.Parse(temp[4]), temp[5], temp[6],bool.Parse(temp[7]));
                Booking.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }

        //add booking to file
        public void AddBooking(){
            System.Console.WriteLine("Please enter the session ID: ");
            Booking newBooking = new Booking();
            newBooking.SetSessionID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the name of the customer: ");
            newBooking.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the email of the customer: ");
            newBooking.SetCustomerEmail(Console.ReadLine());
            System.Console.WriteLine("Please enter the training date (month/day/year): ");
            newBooking.SetTrainingDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the trainer ID: ");
            newBooking.SetTrainerID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the trainer name: ");
            newBooking.SetBookTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter the status of the booking (available/booked):");

            bookings[Booking.GetCount()] = newBooking;
            Booking.IncCount();

            Save();
            Console.ReadKey();
        }

        //edit booking in file
        public void EditBooking(){
            System.Console.WriteLine("What is the ID of the booking you would like to edit: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Please enter the session ID: ");
                bookings[foundIndex].SetSessionID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the customer name for the session: ");
                bookings[foundIndex].SetCustomerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the customer email: ");
                bookings[foundIndex].SetCustomerEmail(Console.ReadLine());
                System.Console.WriteLine("Please enter the training date: ");
                bookings[foundIndex].SetTrainingDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the trainer id: ");
                bookings[foundIndex].SetTrainerID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the trainer name: ");
                bookings[foundIndex].SetBookTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the current status of the appointment (booked / completed / cancelled): ");

                Save();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("ID not found.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        //book an available session
        public void BookSessions(){
            System.Console.WriteLine("Please enter the ID of the session you would like to book: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Please enter the new status (booked / completed / cancelled): ");
                bookings[foundIndex].SetStatus(Console.ReadLine());
                Save();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("ID not found.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        //Delete booking from transactions file
        public void DeleteBooking(){
            System.Console.WriteLine("Please enter the ID of the booking you would like to delete: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                bookings[foundIndex].DeleteBooking();
                Save();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("ID not found.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        //save to file method for booking utility class
        private void Save(){
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Booking.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            outFile.Close();
        }

        //find method for booking class
        private int Find(int searchVal){
            for(int i = 0; i < Booking.GetCount(); i++){
                if(bookings[i].GetSessionID() == searchVal){
                    return i;
                }
            }
            return -1;
        }
    }
}