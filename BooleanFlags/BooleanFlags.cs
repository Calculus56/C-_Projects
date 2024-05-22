using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.Runtime.InteropServices;
using Globals;

namespace BooleanFlags
{
    public class Driver
    {
        public static void Main(string[] args){
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
            // Console.WriteLine("Random bools");
            // var dec2 = BoolToByte(list_bools.RandomBools());
            // PrintByte(dec2);
            var obj = new object[]{};
            Timing.RunMethodAndStopWatch(new Driver(), obj, "RunBooleanFlag");
        }

        public void RunBooleanFlag(){
            var list_bools = new ListOfBools();
            
            Console.WriteLine("Changing bools");
            // Total is column * 8
            const int columns = 8;
            int id = new Random().Next(1, columns * 8);
            var tb_bools = list_bools.GenerateBoolTable(columns);
            System.Console.WriteLine(sizeof(bool) * tb_bools.Length * 8);
            list_bools.PrintBoolTable(tb_bools);
            var arr_bools = list_bools.ConvertTableToByteArr(tb_bools);
            System.Console.WriteLine(sizeof(byte) * arr_bools.Length);
            list_bools.PrintBytes(arr_bools);
            
            list_bools.ChangeBool(arr_bools, id);
            // for (int id = 1; id < columns * 8; id++)
            // {
            //     var arr_bools = list_bools.ConvertTableToByteArr(tb_bools);
            //     tb_bools = list_bools.ChangeBool(arr_bools, id);
            //     // list_bools.PrintBoolTable(tb_bools);
            // }
        }
    }
}