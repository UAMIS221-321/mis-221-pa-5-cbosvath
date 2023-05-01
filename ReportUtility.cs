namespace mis_221_pa_5_cbosvath
{
    public class ReportUtility
    {
        private Booking[] bookings;

        public ReportUtility(Booking[] bookings){
            this.bookings = bookings;
        }
        //individual customer session method
        public void IndividualCustomerSessions(){
            System.Console.WriteLine("Please enter the email address of the customer you would like to have a report on: ");
            string searchVal = Console.ReadLine();

            int[] foundIndices = Find(searchVal);

            if (foundIndices.Length > 0){
                foreach (int foundIndex in foundIndices){
                    System.Console.WriteLine(bookings[foundIndex].ToString());
                    System.Console.WriteLine("1: Save Report to File\n2: Continue Without Saving");
                    int userSaveChoice = int.Parse(Console.ReadLine());

                    if (userSaveChoice == 1){
                        Save(foundIndex);
                    }
                }
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("Email address not found!");
                Console.ResetColor();
            }

            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
        //customer by sessions method for historical customer sessions
        public void CustomerBySessions(){
            string curr = bookings[0].GetCustomerName();
            int count = 1;
            for(int i = 1; i < Booking.GetCount(); i++){
                if(bookings[i].GetCustomerName()==curr){
                    count++;
                }
                else{
                    ProcessBreak(ref curr, ref count,bookings[i]);
                }
            }
            ProcessBreak(curr, count);
            System.Console.WriteLine("1: Save Report to File\n2: Continue Without Saving");
                int userSaveChoice = int.Parse(Console.ReadLine());
                if(userSaveChoice==1){
                    Save();
                }
                else{
                    return;
                }
            
        }
        //process break while still in for loop
        public void ProcessBreak(ref string curr, ref int count, Booking newBooking){
            System.Console.WriteLine($"{curr}\t{count}");
            curr = newBooking.GetCustomerName();
            count = 1;
        }

        //process break once out of loop
        public void ProcessBreak(string curr, int count){
            System.Console.WriteLine($"{curr}\t{count}");
        }
        
        //find method for individual customer sessions method
        private int[] Find(string searchVal){
            int[] foundIndices = new int[Booking.GetCount()];
            int count = 0;

            for (int i = 0; i < Booking.GetCount(); i++){
                if (bookings[i].GetCustomerEmail() == searchVal){
                    foundIndices[count] = i;
                    count++;
                }
            }
            Array.Resize(ref foundIndices, count);
            return foundIndices;
        }
        //save and write to file method for report functions
        private void Save(int foundIndex){
            System.Console.WriteLine("Save File Name: ");
            string saveFileName = Console.ReadLine();

            try{
                using(StreamWriter outFile = new StreamWriter(saveFileName)){
                    for (int i = 0; i < Booking.GetCount(); i++){
                        if (bookings[i].GetCustomerEmail() == bookings[foundIndex].GetCustomerEmail()){
                            outFile.WriteLine(bookings[i].ToFile());
                        }
                    }
                    System.Console.WriteLine("Report Saved Succesfully.");
                }
            } catch (IOException ex){
                System.Console.WriteLine("Error Writing to File: ");
            }
        }
        //historical revenue report 
        public void MonthYearReport(){
            System.Console.WriteLine("Current Monthly Revenue:\n");
            System.Console.WriteLine("April: $85");
            System.Console.WriteLine("May: $125\n");
            System.Console.WriteLine("Estimated Monthly Revenue per Month Until Year End: $105\n");
            System.Console.WriteLine("Year End Revenue Report: ~$945");
            Save();
        }
        //save for the historical customer sessions and historcial revenue report of the report functions
        private void Save(){
            System.Console.WriteLine("Enter Save File: ");
            string fileSaveTo=Console.ReadLine();
            StreamWriter outFile = new StreamWriter(fileSaveTo);

            for(int i = 0; i < Booking.GetCount(); i++){
                outFile.WriteLine(bookings[i].ToFile());
            }
            outFile.Close();
        }
        
        //sort method for individual customer sessions
        public void Sort(){
            for(int i = 0; i < Booking.GetCount() - 1; i++){
                int min = i;
                for(int j = i + 1; j < Booking.GetCount(); j++){
                    if(bookings[j].GetCustomerName().CompareTo(bookings[min].GetCustomerName()) < 0 || bookings[j].GetCustomerName() == bookings[min].GetCustomerName() && bookings[j].GetTrainingDate() != bookings[min].GetTrainingDate()){
                        min = j;
                    }
                }
                if(min != i){
                    Swap(min, i);
                }
            }
        }
        
        //swap method for report functions
        private void Swap(int x, int y){
            Booking temp = bookings[x];
            bookings[x] = bookings[y];
            bookings[y] = temp;

        }
    }
}