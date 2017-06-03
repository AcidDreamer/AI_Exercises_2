using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_2_1 {
    class Letter {
        public static int integers_size = 16;
        public String letter { get; set; }
        public int[] integers { get; set; }
        //constructor
        public Letter(string letter,int[] integers) {
            this.letter = letter;
            this.integers = integers;
        }
        //create a flexible toString method
        public override string ToString() {
            PropertyDescriptorCollection coll = TypeDescriptor.GetProperties(this);
            StringBuilder builder = new StringBuilder();
            foreach (PropertyDescriptor pd in coll) {
                builder.Append(string.Format("[ {0} : {1} ]", pd.Name, pd.GetValue(this).ToString()));
            }
            return builder.ToString();
        }

    }
}
