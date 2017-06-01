using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.Math.Optimization.Losses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_1 {
    class ID3 {

        public String Accord_ID3(List<Letter> validation_set, List<Letter> training_set) {
            double succesful_identifications = 0;
            double fail_identifications = 0;

            int[][] inputs = return_integers(training_set);
            int[] outputs = return_letters(training_set);
            int[][] validation_inputs = new int[validation_set.Count][];
            // Create an ID3 learning algorithm
            ID3Learning teacher = new ID3Learning();

            // Learn a decision tree for the XOR problem
            var tree = teacher.Learn(inputs, outputs);

            // Compute the error in the learning
            double error = new ZeroOneLoss(outputs).Loss(tree.Decide(inputs));

            Console.WriteLine("Learning the algorithm");

            // After the algorithm has been created, we can classify a new instance:
            var watch = System.Diagnostics.Stopwatch.StartNew();
            for (int list_counter = 0; list_counter < validation_set.Count; list_counter++) {
                int[] input = validation_set[list_counter].integers;
                tree.NumberOfInputs = 16;
                tree.NumberOfOutputs = 1; 
                try {
                    int answer = tree.Decide(input);
                    if (answer == (char.Parse(validation_set[list_counter].letter)) - 65) {
                        succesful_identifications++;
                    } else {
                        fail_identifications++;
                    }
                }catch(System.InvalidOperationException) {
                    fail_identifications++;
                    Console.WriteLine("Caught an invalid operation exception on  " + list_counter);
                }
                if (list_counter % 500 == 0 && list_counter != 0) 
                    Console.WriteLine(list_counter);
            }
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            double success_percentage = succesful_identifications / validation_set.Count;
            return "Succesfully identified " + succesful_identifications +
                " failed to identify " + fail_identifications + "\n Success rate of " + success_percentage*100 + "%" + "\n Run time = " + elapsedMs;
        }

        public int[][] return_integers(List<Letter> Set) {
            int[][] inputs = new int[Set.Count][];
            for (int list_counter = 0; list_counter < Set.Count; list_counter++) {
                int[] input = Set[list_counter].integers;
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
    }
}
