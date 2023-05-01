namespace mis_221_pa_5_cbosvath
{
    public class Listing
    {
        private int listID;
        private string name;
        private string date;
        private string time;
        private double cost;
        private bool available;
        private bool deleted=false;
        static private int count;
        //no arg constructor
        public Listing(){
            
        }
        
        //arg constructor
        public Listing(int listID, string name, string date, string time, double cost, bool available){
            this.listID = listID;
            this.name = name;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.available = available;
            this.deleted = deleted;
        }
        //getters and setters for listing
        public int GetListID(){
            return listID;
        }
        public void SetListID(int listID){
            this.listID = listID;
        }
        public string GetListingName(){
            return name;
        }
        public void SetListingName(string name){
            this.name = name;
        }
        public string GetDate(){
            return date;
        }
        public void SetDate(string date){
            this.date = date;
        }
        public string GetTime(){
            return time;
        }
        public void SetTime(string time){
            this.time = time;
        }
        public bool GetAvailable(){
            return available;
        }
        public void SetAvailable(bool available){
            this.available = available;
        }
        public double GetCost(){
            return cost;
        }
        public void SetCost(double cost){
            this.cost = cost;
        }
        public void IsAvailable(){
            available = false;
        }
        public bool GetDeleted(){
            return deleted;
        }
        public void SetDeleted(bool deleted){
            this.deleted = deleted;
        }
        static public void IncCount(){
            Listing.count++;
        }
        static public int GetCount(){
            return Listing.count;
        }
        static public void SetCount(int count){
            Listing.count = count;
        }
        //to string method for listing class
        public override string ToString()
        {
            if(deleted==false){
                return $"{listID}. {name} | {date} | {time} | {cost} | {available}";
            }
            else{
                return "";
            }
        }

        //sets deleted equal to true from false in listing class
        public void DeleteListing(){
            deleted = true;
        }
        //write to file for listing class
        public string ToFile(){
            if(deleted==false){
                return $"{listID}#{name}#{date}#{time}#{cost}#{available}";
            }
            else{
                return "";
            }
        }
    }
}