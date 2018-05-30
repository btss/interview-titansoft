using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ApplicantTestin
{
	/// The DataObject class stored with a key
	class DataObject
	{
		// Populate
	}

	class Program
	{
		static Hashtable Data = new Hashtable();
		static string[] StaticData = new string[] { "X-Ray","Echo","Alpha", "Yankee","Bravo", "Charlie", 
			"Delta",    "Hotel", "India", "Juliet", "Foxtrot","Sierra",
			"Mike","Kilo", "Lima",  "November", "Oscar", "Papa", "Qubec", 
			"Romeo",  "Tango","Golf", "Uniform", "Victor", "Whisky",  
			 "Zulu"};

		static void Main(string[] args)
		{
			for(int i=0;i<StaticData.Length; i++)
				Data.Add(StaticData[i].ToLower(), new DataObject(StaticData[i]) );
			while(true)
			{
				PrintSortedData();
				Console.WriteLine();
				Console.Write("> ");
				string str = Console.ReadLine();
				string[] strs = str.Split(' ');

				if(strs[0]=="q")
					break;
				else if(strs[0]=="printv")
					PrintSortedDataByValue();
				else if(strs[0]=="print")
					PrintSortedData();
				else if(strs[0]=="inc")
					Increase(strs[1]);
				else if(strs[0]=="dec")
					Decrease(strs[1]);
				else if(strs[0] == "swap")
					Swap(strs[1], strs[2]);
				else if (strs[0] == "ref")
					Ref(strs[1], strs[2]);
				else if (strs[0] == "unref")
					UnRef(strs[1]);
			}
		}

		/// <summary>
		/// Create a reference from one data object to another.
		/// </summary>
		/// <param name="key1">The object to create the reference on</param>
		/// <param name="key2">The reference object</param>
		static void Ref(string key1, string key2)
		{
			// Populate
		}

		/// <summary>
		/// Removes an object reference on the object specified.
		/// </summary>
		/// <param name="key">The object to remove the reference from</param>
		static void UnRef(string key)
		{
			// Populate
		}

		/// <summary>
		/// Swap the data objects stored in the keys specified
		/// </summary>
		static void Swap(string key1, string key2)
		{
			// Populate

		}

		/// <summary>
		/// Decrease the Value field by 1 of the 
		/// data object stored with the key specified
		/// </summary>
		static void Decrease(string key)
		{
			// Populate
		}

		/// <summary>
		/// Increase the Value field by 1 of the 
		/// data object stored with the key specified
		/// </summary>
		static void Increase(string key)
		{
			// Populate
		}


		/// <summary>
		/// Prints the information in the Data hashtable to the console.
		/// Output should be sorted by key 
		/// References should be printed between '<' and '>'
		/// The output should look like the following : 
		/// 
		/// 
		/// Alpha...... -3
		/// Bravo...... 2
		/// Charlie.... <Zulu>
		/// Delta...... 1
		/// Echo....... <Alpha>
		/// --etc---
		/// 
		/// </summary>
		static void PrintSortedData()
		{
			// Populate
		}
	

		/// <summary>
		/// Prints the information in the Data hashtable to the console.
		/// Output should be sorted by stored value
		/// References should be printed between '<' and '>'
		/// Sorting order start from max to min, larger value takes priority.
		/// The output should look like the following : 
		/// 
		/// 
		/// Bravo...... 100
		/// Echo...... 99
		/// Zulu...... 98
		/// Charlie.... <Zulu>
		/// Delta...... 34
		/// Echo....... 33
		/// Alpha...... <Echo>
		/// --etc---
		/// 
		/// </summary>
		static void PrintSortedDataByValue()
		{
			// Populate
		}
	}
}
