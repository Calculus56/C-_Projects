using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace BooleanFlags
{
    public class ListOfBools
    {
        // GET SOME OOP IN HERE

        // Returns a byte that is supposed to represent random bools.
        static byte RandomByte(){
            byte[] temp = new byte[1];
            var random_bytes = new Random();
            random_bytes.NextBytes(temp);
            return temp[0];
        }
        
        // Creates an array of bool arrays (NOT a 2D array).
        public bool[][] GenerateBoolTable(int length){
            var bool_table = new bool[length][];
            // if(length * 8 > id) return null;
            for (int i = 0; i < length; i++)
            {
                bool_table[i] = RandomBools();
            }
            Console.WriteLine($"Total : {length * 8}");
            // Console.WriteLine("Original");
            // System.Console.WriteLine("----");
            // PrintBoolTable(bool_table);
            // System.Console.WriteLine("----\n");
            return bool_table;
        }
        
        static bool[] RandomBools(){
            bool[] bools = new bool[8];
            var rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                bools[i] = rand.Next(2) == 0 ? true : false;
            }
            return bools;
        }

        public byte[] ConvertTableToByteArr(bool[][] bools){
            byte[] byte_arr = new byte[bools.Length];
            for (int i = 0; i < bools.Length; i++)
            {
                byte dec = 0;
                dec = BoolToByte(bools[i]);
                byte_arr[i] = dec;
            }

            // System.Console.Write("Before: ");
            // PrintBytes(byte_arr);
            // Console.WriteLine();
            // PrintDecimals(byte_arr);
            return byte_arr;
        }
        
        // Converts a list of bools to a single decimal value.
        static byte BoolToByte(bool[] bools){
            byte dec = 0;
            for (int i = 0; i < 8; i++)
            {
                // Console.WriteLine(bools[i] ? (byte)Math.Pow(2, i) : (byte)0);
                dec += bools[i] ? (byte)Math.Pow(2, i) : (byte)0;
            }
            return dec;
        }

        // TODO: Before and After
        static bool[][] ByteArrToBool(byte[] byte_arr){
            var bool_table = new bool[byte_arr.Length][];

            foreach (var (dec, index) in byte_arr.Select((v, i) => (v, i)))
            {
                bool_table[index] = DecimalToBinary(dec);
            }
            return bool_table;
        }

        static bool[] DecimalToBinary(byte bf){
            var binary = ByteToBinary(bf);
            var bool_arr = new bool[8];

            foreach (var (bit, index) in binary.Select((v, i) => (v, i)))
            {
                bool_arr[index] = bit=='1' ? true : false;
            }
            return bool_arr;
        }

        // Getting the decimals in the table and substracting it by where the id point to.
        // Dive and conquer approach?
        public bool[][]? ChangeBool(byte[] byte_arr, int id){
            if(!(id > 0)){
                Console.WriteLine("ID HAS TO BE MORE THAN 0");
                return null;
            }
            int row = ((id - 1) / 8);
            byte index = (byte)((id - 1) % 8);

            // If the value is on then negative if not then 
            // Get bit.
            int sign = ByteToBinary(byte_arr[row])[index] == '0' ? 1 : -1;
            // Subtracts from the decimal values in the byte arr.
            byte_arr[row] += (byte)(Math.Pow(2, Math.Abs(index)) * sign);
            // PrintDecimals(byte_arr);
            // System.Console.Write("After: ");
            // PrintBytes(byte_arr);
            // System.Console.WriteLine();
            return ByteArrToBool(byte_arr);
        }
        // public bool[][]? ChangeBool(byte[] byte_arr, int id){
        //     if(!(id > 0)){
        //         Console.WriteLine("ID HAS TO BE MORE THAN 0");
        //         return null;
        //     }
        //     int row = ((id - 1) / 8);
        //     byte index = (byte)((id - 1) % 8); 

        //     var binary = ByteToBinary(byte_arr[row]);
        //     binary[index] == '0' ?  : ;

        //     return ByteArrToBool(byte_arr);
        // }

        // Converts a byte to a bianry string.
        static string ByteToBinary(byte bf){
            var bool_byte = new StringBuilder();
            // Reading the byte from back to front. Since the bool bit is stored at index 7.
            for (int i = 0; i < 8; i++)
            {
                // Shifts the bit to the right i spaces and checks if it's one.
                // It's just flipping the bit to the other end.
                int bit = (bf >> i) & 1;
                bool_byte.Append(bit);
            }
            return bool_byte.ToString();
        }

        public void PrintBoolTable(bool[][] bools){
            for (int i = 0; i < bools.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"{bools[i][j], -10}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Calls ByteToString which converts the byte(8-bit int) to binary format.
        public void PrintBytes(byte[] bf){
            for (int i = 0; i < bf.Length; i++)
            {
                Console.Write($"{ByteToBinary(bf[i])} ");
            }
            System.Console.WriteLine();
        }

        static void PrintDecimals(byte[] bf){
            for (int i = 0; i < bf.Length; i++)
            {
                Console.Write($"{bf[i]} ");
            }
            System.Console.WriteLine("\n");
        }
    }
}