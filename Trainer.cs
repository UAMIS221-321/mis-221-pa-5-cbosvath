namespace mis_221_pa_5_cbosvath
{
    public class Trainer
    {
        private int id;
        private string name;
        private string address;
        private string email;
        private bool deleted=false;
        static private int count;


        // no arg constructor
        public Trainer(){

        }
        //arg constructor
        public Trainer(int id, string name, string address, string email){
            this.id = id;
            this.name = name;
            this.address = address;
            this.email = email;
            this.deleted = deleted;
        }
        //getters and setters
        public int GetID(){
            return id;
        }
        public void SetID(int id){
            this.id = id;
        }
        public string GetName(){
            return name;
        }
        public void SetName(string name){
            this.name = name;
        }
        public string GetAddress(){
            return address;
        }
        public void SetAddress(string address){
            this.address = address;
        }
        public string GetEmail(){
            return email;
        }
        public void SetEmail(string email){
            this.email = email;
        }
        public bool GetDeleted(){
            return deleted;
        }
        public void SetDeleted(bool deleted){
            this.deleted = deleted;
        }
        static public void IncCount(){
            Trainer.count++;
        }
        static public int GetCount(){
            return Trainer.count;
        }
        static public void SetCount(int count){
            Trainer.count = count;
        }
        //to string for trainer class
        public override string ToString()
        {
            if(deleted==false){
                return $"{id}. {name} | {address} | {email}";
            }
            else{
                return "";
            }
        }
        //sets deleted to true from false
        public void DeleteTrainer(){
            deleted = true;
        }
        //writes to file for the trainer class
        public string ToFile(){
            if(deleted==false){
                return $"{id}#{name}#{address}#{email}";
            }
            else{
                return "";
            }
        }
    }
}