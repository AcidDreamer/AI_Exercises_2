using Accord.MachineLearning;
using Accord.Math.Distances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_1 {
    class KNN {
        public String Accord_Knn(List<Letter> validation_set, List<Letter> training_set,int k) {
            double succesful_identifications = 0;
            double fail_identifications = 0;

            double[][] inputs = return_integers(training_set);
            int[] outputs = return_letters(training_set);


            var knn = new KNearestNeighbors(k: k);
            knn.NumberOfInputs = 16;
            knn.NumberOfOutputs = 1;

            Console.WriteLine("Learning the algorithm");
            knn.Learn(inputs, outputs);

            // After the algorithm has been created, we can classify a new instance:
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int list_counter = 0; list_counter < validation_set.Count; list_counter++) {
                double[] input = return_single_array(validation_set[list_counter]);
                double answer = knn.Decide(input);
                if (answer == (char.Parse(validation_set[list_counter].letter)) - 65) {
                    succesful_identifications++;
                } else {
                    fail_identifications++;
                }
                if (list_counter % 500 == 0 && list_counter != 0) 
                    Console.WriteLine(list_counter);

            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            double success_percentage = succesful_identifications / validation_set.Count;
            return "Succesfully identified " + succesful_identifications +
                " failed to identify " + fail_identifications + "\n Success rate of " + success_percentage * 100 + "%" + "\n Run time = " + elapsedMs;
        }

        public double[] return_single_array(Letter letter) {
            double[] input = new double[Letter.integers_size];
            for (int i = 0; i < Letter.integers_size; i++) {
                input[i] = (double)letter.integers[i];
            }
            return input;
        }
        public double[][] return_integers(List<Letter> Set) {
            double[][] inputs = new double[Set.Count][];
            for (int list_counter = 0; list_counter < Set.Count; list_counter++) {
                double[] input = new double[16];
                for (int i = 0; i < 16; i++) {
                    input[i] = (double)Set[list_counter].integers[i];
                }
                inputs[list_counter] = input;
            }
            return inputs;
        }
        public int[] return_letters(List<Letter> Set) {
            int[] outputs = new int[Set.Count];
            for (int list_counter = 0; list_counter < Set.Count; list_counter++) {
                outputs[list_counter] = (char.Parse(Set[list_counter].letter)) - 65;
            }
            return outputs;
        }

    }//KNN
}
