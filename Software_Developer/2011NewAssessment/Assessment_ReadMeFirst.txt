Name   Jerry Chang                     Date 2018/05/31

1a.  Multiple by 8 without using multiplication or addition. 
Hint: Pseudo code or any language with which you are familiar are acceptable

n = n << 3;




1b. Now do the same with 7.

n = (n << 3) - n;




2a. Suppose you have an array of 1000 integers. The integers are in random order, but you know each of the integers is between 1 and 5000 (inclusive). In addition, each number appears only once in the array. Assume that you can access each element of the array only once. Describe an algorithm to sort it. 
Hint: Pseudo code or any language with which you are familiar are acceptable


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






2b. If you used auxiliary storage in your algorithm, can you find an algorithm that remains O(n) space complexity?


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





3. [C# Program] Please complete the attached file, /programming-test/c-sharp/c-sharp-test.cs. It must be executable with the requirement specified inside the code.




















4. [HTML and JavaScript] Please complete and refine the attached /programming-test/html-javascript/your-implementation.html, instruction and hints are given in the /programming-test/html-javascript/index.html 










