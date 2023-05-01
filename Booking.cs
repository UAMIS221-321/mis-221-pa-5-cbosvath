namespace mis_221_pa_5_cbosvath
{
    public class Booking
    {
        private int sessionID;
        private string customerName;
        private string customerEmail;
        private string trainingDate;
        private int trainerID;
        private string bookTrainerName;
        private string status;
        private bool deleted = false;
        static private int count;

        //no arg constructor
        public Booking(){

        }
        //arg constructor 
        public Booking(int sessionID, string customerName, string customerEmail,string trainingDate,int trainerID,string bookTrainerName, string status,bool deleted){
            this.sessionID = sessionID;
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.trainingDate = trainingDate;
            this.trainerID = trainerID;
            this.bookTrainerName = bookTrainerName;
            this.status = status;
            this.deleted = deleted;
        }
        //getters and setters
        public int GetSessionID(){
            return sessionID;
        }
        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }
        public string GetCustomerName(){
            return customerName;
        }
        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }
        public string GetCustomerEmail(){
            return customerEmail;
        }
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }
        public string GetTrainingDate(){
            return trainingDate;
        }
        public void SetTrainingDate(string trainingDate){
            this.trainingDate = trainingDate;
        }
        public int GetTrainerID(){
            return trainerID;
        }
        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }
        public string GetBookTrainerName(){
            return bookTrainerName;
        }
        public void SetBookTrainerName(string bookTrainerName){
            this.bookTrainerName = bookTrainerName;
        }
        public string GetStatus(){
            return status;
        }
        public void SetStatus(string status){
            this.status = status;
        }
        public bool GetDeleted(){
            return deleted;
        }
        public void SetDeleted(bool deleted){
            this.deleted = deleted;
        }
        static public void IncCount(){
            Booking.count++;
        }
        static public int GetCount(){
            return Booking.count;
        }
        static public void SetCount(int count){
            Booking.count = count;
        }
        //ToString method for booking class
        public override string ToString()
        {
            if(deleted==false){
                return $"{sessionID}. {customerName} | {customerEmail} | {trainingDate} | {trainerID} | {bookTrainerName} | {status}";
            }
            else{
                return "";
            }
        }
        //set deleted to true from false
        public void DeleteBooking(){
            deleted = true;
        }
        //to file for booking class
        public string ToFile(){
            if(deleted==false){
                return $"{sessionID}#{customerName}#{customerEmail}#{trainingDate}#{trainerID}#{bookTrainerName}#{status}";
            }
            else{
                return "";
            }
        }
    }
}