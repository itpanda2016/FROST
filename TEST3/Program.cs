using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST3 {
    class Program {
        static void Main(string[] args) {
            int[] ii = { 3, 4, 5 };
            Console.WriteLine(sum(ii));
            Console.WriteLine(sum(3,4,50));
            Console.ReadKey();
        }
        public static int sum(params int[] inum) {
            int n = 0;
            for (int i = 0; i < inum.Length; i++) {
                n = n + inum[i];
            }
            return n;
        }
    }
}
