using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_1 {
    class DataLoader {
        //returns a list of all the letters after loading it from the file
        public List<Letter> return_data() {
            //Each line has the attributes of 1 letter
            string[] attributes;
            
            List<Letter> letters = new List<Letter>() ;
            //Comma is our seperator
            string[] separator = { "," };
            //Load the file and place each line in an array
            string[] file = System.IO.File.ReadAllLines(@"f:\\AI_Exercises\\Exercise_2_1\\Exercise_2_1\\letter-recognition.data");
            
            foreach (string line in file) {
                //get the attributes splitting the line with comma
                attributes = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                //Load the integers for each letter
                int[] integers = { int.Parse(attributes[1]), int.Parse(attributes[2]), int.Parse(attributes[3]), int.Parse(attributes[4]), int.Parse(attributes[5]),
                    int.Parse(attributes[6]), int.Parse(attributes[7]), int.Parse(attributes[8]), int.Parse(attributes[9]), int.Parse(attributes[10]),
                    int.Parse(attributes[11]), int.Parse(attributes[12]), int.Parse(attributes[13]), int.Parse(attributes[14]), int.Parse(attributes[15]), int.Parse(attributes[16]) };
                //Create a new letter
                Letter letter = new Letter(attributes[0], integers);
                //Add it to the list
                letters.Add(letter);
            }
            return letters;
        }
    }
}
