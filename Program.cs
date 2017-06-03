using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_1 {
    class Program {
        static void Main(string[] args) {
            
            break_sets bs = new break_sets();
            DataLoader dl = new DataLoader();
            //get an instance of both algorithms
            KNN knn = new KNN();
            ID3 id3 = new ID3();
            //load the complete data set
            List<Letter> letters =  dl.return_data();
            //get the training set
            List<Letter> training = bs.return_training_set(letters);
            //get the validation set
            List<Letter> test = bs.return_validation_set(letters);
            //Run KNN , 5 closest neighbors
            Console.WriteLine(knn.Accord_Knn(test, training, 5));
            //Run KNN , 10 closest neighbors
            Console.WriteLine(knn.Accord_Knn(test, training, 10));
            //Run KNN , 25 closest neighbors
            Console.WriteLine(knn.Accord_Knn(test, training, 25));
            //Run ID3
            Console.WriteLine(id3.Accord_ID3(test, training));
            //Pause to read the data
            Console.ReadLine();
        }
    }
}
