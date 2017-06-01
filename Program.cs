using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_1 {
    class Program {
        static void Main(string[] args) {
            DataLoader dl = new DataLoader();
            KNN knn = new KNN();
            ID3 id3 = new ID3();
            break_sets bs = new break_sets();
            List<Letter> letters =  dl.return_data();
            List<Letter> training = bs.return_training_set(letters);
            List<Letter> test = bs.return_validation_set(letters);
            Console.WriteLine(knn.Accord_Knn(test, training, 55));
            Console.WriteLine(knn.Accord_Knn(test, training, 10));
            Console.WriteLine(knn.Accord_Knn(test, training, 25));
            Console.WriteLine(id3.Accord_ID3(test, training));
            Console.ReadLine();
        }
    }
}
