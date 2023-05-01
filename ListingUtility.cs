namespace mis_221_pa_5_cbosvath
{
    public class ListingUtility
    {
        private Listing[] listings;

        public ListingUtility(Listing[] listings){
            this.listings = listings;
        }
        //gets all listings from file "listings" 
        public void GetAllListings(){
            StreamReader inFile = new StreamReader("listings.txt");

            Listing.SetCount(0);
            string line=inFile.ReadLine();
            while(line!=null){
                string[] temp = line.Split('#');
                listings[Listing.GetCount()] = new Listing(int.Parse(temp[0]), temp[1],temp[2],temp[3], double.Parse(temp[4]), bool.Parse(temp[5]));
                Listing.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }

        //adds listing to file 
        public void AddListing(){
            System.Console.WriteLine("Please enter the new listing ID: ");
            Listing newListing = new Listing();
            newListing.SetListID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the name of the trainer for the new listing: ");
            newListing.SetListingName(Console.ReadLine());
            System.Console.WriteLine("Please enter the date of the session (ex. month/day/year): ");
            newListing.SetDate(Console.ReadLine());
            System.Console.WriteLine("Please enter the time of the session (ex. 00:00): ");
            newListing.SetTime(Console.ReadLine());
            System.Console.WriteLine("Please enter the cost of the session: ");
            newListing.SetCost(double.Parse(Console.ReadLine()));
            System.Console.WriteLine("If the session is available enter true, if it is not enter false");
            newListing.SetAvailable(bool.Parse(Console.ReadLine()));

            listings[Listing.GetCount()] = newListing;
            Listing.IncCount();

            Save();
            Console.ReadKey();
        }

        //edits listing in file
        public void EditListings(){
            System.Console.WriteLine("What is the ID of the session you would like to edit: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Please enter the new ID of the session: ");
                listings[foundIndex].SetListID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the name of the trainer: ");
                listings[foundIndex].SetListingName(Console.ReadLine());
                System.Console.WriteLine("Please enter date of the session (month/day/year): ");
                listings[foundIndex].SetDate(Console.ReadLine());
                System.Console.WriteLine("Please enter the time of the session (00:00): ");
                listings[foundIndex].SetTime(Console.ReadLine());
                System.Console.WriteLine("Please enter the cost of the sessions: ");
                listings[foundIndex].SetCost(double.Parse(Console.ReadLine()));
                System.Console.WriteLine("If the session is available enter true, if it is not enter false: ");
                listings[foundIndex].SetAvailable(bool.Parse(Console.ReadLine()));

                Save();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("ID not found.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        //deletes listing in file
        public void DeleteListing(){
            System.Console.WriteLine("Please enter the ID of the session you would like to delete: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                listings[foundIndex].DeleteListing();
                Save();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("ID not found.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        //saves listing information back to file
        private void Save(){
            StreamWriter outFile = new StreamWriter("listings.txt");

            for(int i = 0; i < Listing.GetCount(); i++){
                outFile.WriteLine(listings[i].ToFile());
            }
            outFile.Close();
        }

        //find method for listings
        private int Find(int searchVal){
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listings[i].GetListID() == searchVal){
                    return i;
                }
            }
            return -1;
        }
    }
}
