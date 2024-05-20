using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooleanFlags
{
    public class ListOfBools
    {
        // Manual
        public bool[] bools = new bool[]{
            true,
            true,
            false,
            false,
            false,
            false,
            false,
            false,
        };

        // Automatic
        public bool[] RandomBools(){
            bool[] bools = new bool[8];
            var rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                bools[i] = rand.Next(2) == 0 ? true : false;
            }
            return bools;
        }

        // Returns a byte that is supposed to represent random bools.
        static byte RandomByte(){
            byte[] temp = new byte[1];
            var random_bytes = new Random();
            random_bytes.NextBytes(temp);
            return temp[0];
        }
    }
}