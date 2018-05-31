using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace ApplicantTestin
{
	/// The DataObject class stored with a key
	class DataObject
	{
        public string Name { get; set; }
        public int Value { get; set; }
        public DataObject Ref { get; set; }

        public DataObject(string name)
        {
            this.Name = name;
            this.Value = 0;
            this.Value = rand.Next(-10, 10);
            this.Ref = null;
        }

        public int GetFinalValue()
        {
            int v = this.Value;

            DataObject r = this.Ref;
            while (r != null && r != this)
            {
                v = r.Value;
                r = r.Ref;
            }

            return v;
        }

        public DataObject GetFinalRef()
        {
            DataObject r = this;
            while (r.Ref != null && r.Ref != this)
            {
                r = r.Ref;
            }

            return r;
        }

        public string GetRefPath()
        {
            StringBuilder sbPath = new StringBuilder();

            DataObject r = this;
            sbPath.Append(r.Name).Append(".");
            while (r.Ref != null && r.Ref != this)
            {
                r = r.Ref;
                sbPath.Append(r.Name).Append(".");
            }

            return sbPath.ToString();
        }

        public bool isRefPathContain(DataObject dataObj)
        {
            DataObject r = this;
            while (r.Ref != null && r.Ref != this)
            {
                if (r == dataObj) return true;
                r = r.Ref;
            }

            return false;
        }

        private static readonly Random rand = new Random((int)DateTime.Now.Ticks);
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
            DataObject dataObj1 = GetDataObject(key1);
            if (dataObj1 == null)
            {
                System.Console.WriteLine("key1 {0} not exist!", key1);
                return;
            }

            DataObject dataObj2 = GetDataObject(key2);
            if (dataObj2 == null)
            {
                System.Console.WriteLine("key2 {0} not exist!", key2);
                return;
            }


            dataObj1.Ref = dataObj2;
        }

		/// <summary>
		/// Removes an object reference on the object specified.
		/// </summary>
		/// <param name="key">The object to remove the reference from</param>
		static void UnRef(string key)
		{
            DataObject dataObj = GetDataObject(key);
            if (dataObj == null)
            {
                System.Console.WriteLine("key {0} not exist!", key);
                return;
            }

            
            dataObj.Ref = null;
        }

		/// <summary>
		/// Swap the data objects stored in the keys specified
		/// </summary>
		static void Swap(string key1, string key2)
		{
            DataObject dataObj1 = GetDataObject(key1);
            if (dataObj1 == null)
            {
                System.Console.WriteLine("key1 {0} not exist!", key1);
                return;
            }

            DataObject dataObj2 = GetDataObject(key2);
            if (dataObj2 == null)
            {
                System.Console.WriteLine("key2 {0} not exist!", key2);
                return;
            }

            // exchange DataObject.Name
            string name = dataObj1.Name;
            dataObj1.Name = dataObj2.Name;
            dataObj2.Name = name;

            // exchange DataObject
            Data[key1.ToLower()] = dataObj2;
            Data[key2.ToLower()] = dataObj1;
        }

        /// <summary>
        /// Decrease the Value field by 1 of the 
        /// data object stored with the key specified
        /// </summary>
        static void Decrease(string key)
		{
            DataObject dataObj = GetDataObject(key);
            if (dataObj == null)
            {
                System.Console.WriteLine("key {0} not exist!", key);
                return;
            }

            dataObj.Value -= 1;
        }

		/// <summary>
		/// Increase the Value field by 1 of the 
		/// data object stored with the key specified
		/// </summary>
		static void Increase(string key)
		{
            DataObject dataObj = GetDataObject(key);
            if (dataObj == null)
            {
                System.Console.WriteLine("key {0} not exist!", key);
                return;
            }

            dataObj.Value += 1;
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
            SortedList list = new SortedList(Data);

            PrintSortedList(list);
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
            SortedList list = new SortedList(new DataObjectComparerByValue());

            foreach(Object o in Data.Values)
            {
                list.Add(o, o);
            }

            PrintSortedList(list);
        }

        private static DataObject GetDataObject(string key)
        {
            if(key == null || key == string.Empty)
            {
                return null;
            }

            if(!Data.Contains(key.ToLower()))
            {
                return null;
            }

            return (DataObject)Data[key.ToLower()];
        }

        private static void PrintSortedList(SortedList list)
        {
            foreach (Object o in list.Values)
            {
                DataObject dataObject = (DataObject)o;

                StringBuilder sbName = new StringBuilder(dataObject.Name);
                for (int i = 0; i < (11 - dataObject.Name.Length); ++i)
                {
                    sbName.Append('.');
                }


                System.Console.WriteLine("{0} {1}"
                    , sbName.ToString()
                    , (dataObject.Ref == null) ? dataObject.Value.ToString() : '<' + dataObject.Ref.Name + '>'
                    );
            }

            System.Console.WriteLine();
        }

        private class DataObjectComparerByValue : IComparer
        {
            public int Compare(object x, object y)
            {
                DataObject xDataObject = (DataObject)x;
                DataObject yDataObject = (DataObject)y;

                DataObject xFianlRef = xDataObject.GetFinalRef();
                DataObject yFianlRef = yDataObject.GetFinalRef();

                // compare final value
                if (yFianlRef.Value < xFianlRef.Value) return -1;
                if (yFianlRef.Value > xFianlRef.Value) return 1;

                // compare final ref's name
                if (xFianlRef != yFianlRef) return xFianlRef.Name.CompareTo(yFianlRef.Name);

                //
                if (yDataObject.isRefPathContain(xDataObject)) return -1;
                if (xDataObject.isRefPathContain(yDataObject)) return 1;

                // compare ref
                //if (xDataObject.Ref == null && yDataObject.Ref == null) return xDataObject.Name.CompareTo(yDataObject.Name);


                // comapre ref path
                //string xRefPath = xDataObject.GetRefPath();
                //string yRefPath = yDataObject.GetRefPath();
                //if (yRefPath.IndexOf(xRefPath) != -1) return -1;
                //if (xRefPath.IndexOf(yRefPath) != -1) return 1;

                // compare name
                return xDataObject.Name.CompareTo(yDataObject.Name);
            }
        }
    }
}
