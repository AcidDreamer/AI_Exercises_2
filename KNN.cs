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
            //counters
            double succesful_identifications = 0;
            double fail_identifications = 0;
            //firstly take the integers , then the letters from the training set
            double[][] inputs = return_integers(training_set);
            int[] outputs = return_letters(training_set);
            //Create a ne KNN learner,using the k closest neighbors.
            var knn = new KNearestNeighbors(k: k);
            //define inputs & outputs
            knn.NumberOfInputs = 16;
            knn.NumberOfOutputs = 1;

            Console.WriteLine("Learning the algorithm --> Running KNN");
            //Teach the algorithm
            knn.Learn(inputs, outputs);

            //start a watch
            var watch = System.Diagnostics.Stopwatch.StartNew();
            //traverse the validation set, for each letter
            for (int list_counter = 0; list_counter < validation_set.Count; list_counter++) {
                //add the letter's integers as double , to an array
                double[] input = return_single_array(validation_set[list_counter]);
                //get the answer
                double answer = knn.Decide(input);
                //compare the double we got to the double value of the letter             
                if (answer == (char.Parse(validation_set[list_counter].letter)) - 65) {
                    succesful_identifications++;
                } else {
                    fail_identifications++;
                }
                //keep track of our progress
                if (list_counter % 500 == 0 && list_counter != 0) 
                    Console.WriteLine(list_counter);

            }
            //stop the watch
            watch.Stop();
            //get the miliseconds elapsed since we started the clock
            var elapsedMs = watch.ElapsedMilliseconds;
            //get our success rate
            return "Succesfully identified " + succesful_identifications +
                " failed to identify " + fail_identifications + "\n Success rate of " + success_percentage * 100 + "%" + "\n Run time = " + elapsedMs;
        }
        
        //get a letter, returns an array with the double values that describe the letter
        public double[] return_single_array(Letter letter) {
            double[] input = new double[Letter.integers_size];
            for (int i = 0; i < Letter.integers_size; i++) {
                input[i] = (double)letter.integers[i];
            }
            return input;
        }
        //get a list of letters , return an array of arrays , 
        //where each array contains the double values of the given letter
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
        //get a list of letters , return an array of the integer values of the letters character
        public int[] return_letters(List<Letter> Set) {
            int[] outputs = new int[Set.Count];
            for (int list_counter = 0; list_counter < Set.Count; list_counter++) {
                outputs[list_counter] = (char.Parse(Set[list_counter].letter)) - 65;
            }
            return outputs;
        }

    }//KNN
}
