using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_1 {
    class break_sets {
        //gets a list of letters , returns the first 15000 as training set
        public List<Letter> return_training_set(List<Letter> letters) {
            List<Letter> training_letters = new List<Letter>();
            for(int i = 0; i < 15000; i++) {
                training_letters.Add(letters[i]);
            }
            return training_letters;
        }
        
        //gets a list of letters , returns the last 5000 as validation set
        public List<Letter> return_validation_set(List<Letter> letters) {
            List<Letter> validation_letters = new List<Letter>();
            for (int i = 15000; i < 20000; i++) {
                validation_letters.Add(letters[i]);
            }
            return validation_letters;
        }
    }
}
