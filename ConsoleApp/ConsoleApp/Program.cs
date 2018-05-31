using System;

namespace ConsoleApp
{
    class Program
    {
        static void sort(int[] data)
        {
            bool[] index = new bool[5000];
            for(int i = 0; i < 5000; ++i)
            {
                index[i] = false;
            }

            foreach(int n in data)
            {
                index[n - 1] = true;
            }

            int di = 0;
            for(int i = 0; i < 5000; ++i)
            {
                if(index[i])
                {
                    data[di++] = i + 1;
                }
            }
        }

        static byte[] mask = { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };
        static void sort2(int[] data)
        {
            // System.Console.WriteLine(sizeof(byte)); -> 1 byte = 8 bit
            byte[] index = new byte[5000/8+1];

            foreach(int n in data)
            {
                // n-1: map [1,5000] to [0,4999]
                int i = (n - 1) / 8;
                int b = ((n - 1) % 8);
                index[i] = (byte)(index[i] | (1 << b));
            }

            int di = 0;
            for(int i = 0; i < index.Length; ++i)
            {
                for(int b = 0; b < mask.Length; ++b)
                {
                    if((index[i] & mask[b]) > 0)
                    {
                        int n = (8 * i) + b + 1; // map [0,4999] back to [1,5000]
                        if (n > 5000) continue;
                        data[di++] = n;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int[] data = {128, 129, 5000, 123, 121, 124};

            //sort(data);
            sort2(data);

            bool hasMore = false;
            foreach(int n in data)
            {
                if (hasMore) System.Console.Write(",");
                System.Console.Write(n);
                hasMore = true;
            }
            System.Console.WriteLine();
        }
    }
}
