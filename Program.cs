using mis_221_pa_5_cbosvath;
//start main
Trainer[] trainers = new Trainer[100];
Listing[] listings = new Listing[100];
Booking[] bookings = new Booking[100];
TrainerUtility utility = new TrainerUtility(trainers);
TrainerReport report = new TrainerReport(trainers);

//Get user main menu choice
int userChoice = GetUserChoice(); //priming read
while(userChoice!=5){
  RouteEm(userChoice);
  userChoice=GetUserChoice();  //update read
}
// end main

//Display main menu choice to user after getting user choice
static int GetUserChoice(){
    DisplayMainMenu();
    string userChoice=Console.ReadLine();
    if(IsValidChoice(userChoice)){
        return int.Parse(userChoice);
    }
    else return 0;
}

//display main menu to user
static void DisplayMainMenu(){
    Console.Clear();
    System.Console.WriteLine("1: Manage Trainer Data\n2: Manage Listing Data\n3: Manage Customer Booking Data\n4: Run Reports\n5: Exit");
}

//check if user choice is valid
static bool IsValidChoice(string userInput){
    if(userInput=="1" || userInput=="2" || userInput=="3" || userInput=="4" || userInput=="5"){
        return true;
    }
    return false;
}

//run manage trianer if user input was 1
static void ManageTrainer(){
    Console.Clear();
    Trainer[] trainers = new Trainer[100];
    TrainerUtility utility = new TrainerUtility(trainers);
    TrainerReport report = new TrainerReport(trainers);

    //determine what user would like to do in trainer section
    System.Console.WriteLine("1: Add Trainer\n2: Edit Existing Trainer\n3: Delete Trainer ");
    int userChoice = int.Parse(Console.ReadLine());
    
    //add trainer to file
    if(userChoice==1){
        Console.Clear();
        System.Console.WriteLine("| ADD TRAINER |\n");
        utility.GetAllTrainers();
        report.PrintAllTrainers();
        utility.AddTrainer();
        report.PrintAllTrainers();
    }
    //edit trainer in file
    else if(userChoice==2){
        Console.Clear();
        System.Console.WriteLine("| EDIT TRAINER |\n");
        utility.GetAllTrainers();
        report.PrintAllTrainers();
        utility.EditTrainer();
        report.PrintAllTrainers();
    }
    //delete trainer in file
    else if(userChoice==3){
        Console.Clear();
        System.Console.WriteLine("| DELETE TRAINER |\n");
        utility.GetAllTrainers();
        report.PrintAllTrainers();
        utility.DeleteTrainer();
        report.PrintAllTrainers();
    }
    else{
        System.Console.WriteLine("Invalid Option!\nPress any key to continue...");
        Console.ReadKey();
    }
}

//enter manage listing if user chose 2
static void ManageListing(){
    Listing[] listings = new Listing[100];
    ListingUtility listUtility = new ListingUtility(listings);
    ListingReport listReport = new ListingReport(listings);

//determine what user would like to do in listing section
    System.Console.WriteLine("1: Add Listing\n2: Edit Listing\n3: Delete Listing\n");
    int userListChoice = int.Parse(Console.ReadLine());

    //add listing to file
    if(userListChoice==1){
        Console.Clear();
        System.Console.WriteLine("| ADD LISTING |\n");
        listUtility.GetAllListings();
        listReport.PrintAllListings();
        listUtility.AddListing();
        listReport.PrintAllListings();
    }
    //edit listing in file
    else if(userListChoice==2){
        Console.Clear();
        System.Console.WriteLine("| EDIT LISTING |\n");
        listUtility.GetAllListings();
        listReport.PrintAllListings();
        listUtility.EditListings();
        listReport.PrintAllListings();
    }
    //delete listing in file
    else if(userListChoice==3){
        Console.Clear();
        System.Console.WriteLine("| DELETE LISTING |\n");
        listUtility.GetAllListings();
        listReport.PrintAllListings();
        listUtility.DeleteListing();
        listReport.PrintAllListings();
    }
    else{
        System.Console.WriteLine("Invalid!\nPress any key to continue...");
        Console.ReadKey();
    }
}

//Display manage customer if user choice was 3
static void ManageCustomer(){
    Booking[] bookings = new Booking[100];
    BookingUtility bookUtility = new BookingUtility(bookings);
    BookingReport bookReport = new BookingReport(bookings);

    //ask user what they would like to do in bookings section
    System.Console.WriteLine("1: Available Sessions\n2: Book a Session\n3: Add Booking to File\n4: Edit Booking in File\n5: Delete Booking in File\n");
    int userBookingChoice = int.Parse(Console.ReadLine());

    //view available sessions
    if(userBookingChoice==1){
        Console.Clear();
        bookUtility.GetAllBookings();
        bookReport.PrintAllBookings();
        System.Console.WriteLine("See List Above of ALL current bookings...");
        System.Console.WriteLine("Press any key to continue...");
        Console.ReadKey();

// book a session
    }else if(userBookingChoice==2){
        Console.Clear();
        System.Console.WriteLine("| BOOK A SESSION |\n");
        bookUtility.GetAllBookings();
        bookReport.PrintAllBookings();
        bookUtility.BookSessions();
        bookReport.PrintAllBookings();

        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write("Session Successfully Booked!\nPress any key to continue...");
        Console.ResetColor();
        Console.ReadKey();


    }
    //Add booking to file
    else if(userBookingChoice==3){
        Console.Clear();
        System.Console.WriteLine("| ADD BOOKING TO FILE |\n");
        bookUtility.GetAllBookings();
        bookReport.PrintAllBookings();
        bookUtility.AddBooking();
        bookReport.PrintAllBookings();
        
        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write("Booking Successfully Added to File!\nPress any key to continue...");
        Console.ResetColor();
        Console.ReadKey();
    }
    //edit booking in file
    else if(userBookingChoice==4){
        Console.Clear();
        System.Console.WriteLine("| EDIT BOOKING IN FILE |\n");
        bookUtility.GetAllBookings();
        bookReport.PrintAllBookings();
        bookUtility.EditBooking();
        bookReport.PrintAllBookings();

        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write("Booking Successfully Edited!\nPress any key to continue...");
        Console.ResetColor();
        Console.ReadKey();
    }
    //delete booking in file
    else if(userBookingChoice==5){
        Console.Clear();
        System.Console.WriteLine("| DELETE BOOKING FROM FILE |\n");
        bookUtility.GetAllBookings();
        bookReport.PrintAllBookings();
        bookUtility.DeleteBooking();
        bookReport.PrintAllBookings();

        Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write("Booking Successfully Deleted!\nPress any key to continue...");
        Console.ResetColor();
        Console.ReadKey();
    }
    else{
        System.Console.WriteLine("Invalid Option!\nPress any key to continue...");
        Console.ReadKey();
    }
}

//run report if user input was 4
static void RunReport(){
    Booking[] bookings = new Booking[100];
    Listing[] listings = new Listing[100];
    ListingUtility utility = new ListingUtility(listings);
    BookingUtility bookUtility = new BookingUtility(bookings);
    BookingReport bookReport = new BookingReport(bookings);
    ReportUtility reportUtility = new ReportUtility(bookings);

    //ask user which report they would like
    System.Console.WriteLine("1: Individual Customer Sessions\n2: Historical Customer Sessions\n3: Historical Revenue Report");
    int userReportChoice = int.Parse(Console.ReadLine());

    //run report on individual customer sessions
    if(userReportChoice==1){
        Console.Clear();
        bookUtility.GetAllBookings();
        reportUtility.IndividualCustomerSessions();
        System.Console.WriteLine("\nAbove is the report from the given customer: \nPress any key to continue...");
        Console.ReadKey();
    }
    //run report on Historical Customer Sessions
    else if(userReportChoice==2){
        Console.Clear();
        bookUtility.GetAllBookings();
        reportUtility.Sort();
        reportUtility.CustomerBySessions();
        System.Console.WriteLine("\nAbove is the Historical Customer Sessions: \nPress any key to continue... ");
        Console.ReadKey();
    }
    //run Month and Year Report 
    else if(userReportChoice==3){
        Console.Clear();
        bookUtility.GetAllBookings();
        utility.GetAllListings();
        reportUtility.MonthYearReport();
    }
    else{
        System.Console.WriteLine("Invalid! \nPress any key to continue...");
        Console.ReadKey();
    }
}

//display invalid to the user if user input was invalid
static void SayInvalid(){
    System.Console.WriteLine("Invalid!");
    PauseAction();
}

//route user to proper method based on menu choice
static void RouteEm(int menuChoice){
    if(menuChoice==1){
        ManageTrainer();
    }
    else if(menuChoice==2){
        ManageListing();
    }
    else if(menuChoice==3){
        ManageCustomer();
    }
    else if(menuChoice==4){
        RunReport();
    }
    else if (menuChoice!=5){
        SayInvalid();
    }
}

//simple pause action method
static void PauseAction(){
    System.Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

