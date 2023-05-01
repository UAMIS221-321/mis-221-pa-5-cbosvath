namespace mis_221_pa_5_cbosvath
{
    public class TrainerUtility
    {
        private Trainer[] trainers;

        public TrainerUtility(Trainer[] trainers){
            this.trainers = trainers;
        }
        //gets all trainers from file
        public void GetAllTrainers(){
            StreamReader inFile = new StreamReader("trainers.txt");

            Trainer.SetCount(0);
            string line=inFile.ReadLine();
            while(line!=null){
                string[] temp = line.Split('#');
                trainers[Trainer.GetCount()] = new Trainer(int.Parse(temp[0]), temp[1],temp[2],temp[3]);
                Trainer.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        //add trainer to file
        public void AddTrainer(){
            System.Console.WriteLine("Please enter the new trainer ID: ");
            Trainer newTrainer = new Trainer();
            newTrainer.SetID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter the name of the new trainer: ");
            newTrainer.SetName(Console.ReadLine());
            System.Console.WriteLine("Please enter the mailing address of the new trainer: ");
            newTrainer.SetAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter the email of the new trainer: ");
            newTrainer.SetEmail(Console.ReadLine());

            trainers[Trainer.GetCount()] = newTrainer;
            Trainer.IncCount();

            Save();
            Console.ReadKey();
        }
        //edit trainer in file
        public void EditTrainer(){
            System.Console.WriteLine("What is the ID of the trainer you would like to edit: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Please enter the new ID of the trainer: ");
                trainers[foundIndex].SetID(int.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the name of the trainer: ");
                trainers[foundIndex].SetName(Console.ReadLine());
                System.Console.WriteLine("Please enter the mailing address of the trainer: ");
                trainers[foundIndex].SetAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the email of the trainer: ");
                trainers[foundIndex].SetEmail(Console.ReadLine());

                Save();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("ID not found.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
        //delete trainer from file
        public void DeleteTrainer(){
            System.Console.WriteLine("Please enter the ID of the trainer you would like to delete: ");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                trainers[foundIndex].DeleteTrainer();
                Save();
            }
            else{
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Write("ID not found.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }
        //save and writes to file with ToFile method for trainer class
        private void Save(){
            StreamWriter outFile = new StreamWriter("test.txt");

            for(int i = 0; i < Trainer.GetCount(); i++){
                outFile.WriteLine(trainers[i].ToFile());
            }
            outFile.Close();
        }

        //find trainer ID for trainer class
        private int Find(int searchVal){
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainers[i].GetID() == searchVal){
                    return i;
                }
            }
            return -1;
        }
    }
}