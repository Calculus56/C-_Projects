using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace BooleanFlags
{
    public class Driver
    {
        public static void Main(string[] args){
            var list_bools = new ListOfBools();
            int id = 50;
            // Converting a bool to byte.
            // bool f = true;
            // byte bf = Convert.ToByte(f);
            // Console.WriteLine("Regular bool");
            // PrintByte(bf);

            // Manual Booleans
            // Console.WriteLine("Manual bools");
            // var dec1 = BoolToByte(list_bools.bools);
            // PrintByte(dec1);

            // Random Booleans
            Console.WriteLine("Random bools");
            var dec2 = BoolToByte(list_bools.RandomBools());
            PrintByte(dec2);
        }

        static void PrintByte(byte bf){
            Console.WriteLine($"{ByteToString(bf)}");
        }

        static string ByteToString(byte bf){
            var bool_byte = new StringBuilder();
            // Reading the byte from back to front. Since the bool is stored at index 7.
            for (int i = 7; i >= 0; i--)
            {
                int bit = (bf >> i) & 1;
                bool_byte.Append(bit);
                // Console.WriteLine($"Bit {i}: {bit}");
            }
            return bool_byte.ToString();
        }

        static byte BoolToByte(bool[] bools){
            byte dec = 0;
            for (int i = 0; i < 8; i++)
            {
                // Console.WriteLine(bools[i] ? (byte)Math.Pow(2, i) : (byte)0);
                dec += bools[i] ? (byte)Math.Pow(2, i) : (byte)0;
            }
            return dec;
        }
    }
}