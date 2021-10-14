using System;
using System.IO;
using System.Collections.Generic;
//Read input from a text file which contains (a-z, A-Z, 0-9) calculate occurance of each char in the file
//Write output of the number of occurance in another file.

//given a ip address string (192.168.1.1) check if the input string is valid or not -
// a) each segment should only contain interger
// b) there should be 4 segement only
// c) The value of each segement should be in between 0 to 255.
//Output if the given string is valid or not.

//3)Given a string of even length, break the string into 2 equal parts,
//    and check if they are alike, which means have same number of vowels in both the part(case-insenstive)
//	output true or false -13th oct

namespace CharOccuranceTextFile
{
    class Program
    {
        static void Main(string[] args)
        {
            //Q1();
            //Q2();
            //Q3();
        }
        private static void Q1()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("1. Create file");
                Console.WriteLine("2. Read file");
                Console.WriteLine("3. Write file");
                int input = Int32.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("Input new file name:");
                    string filename = Console.ReadLine();
                    FileStream fs = new FileStream(filename + ".txt", FileMode.Create, FileAccess.Write);
                    StreamWriter streamWriter = new StreamWriter(fs);
                    Console.WriteLine("Enter text:");
                    var str = Console.ReadLine();
                    streamWriter.WriteLine(str);
                    streamWriter.Flush();
                    streamWriter.Close();
                    fs.Close();
                }
                if (input == 2)
                {                    
                    Console.WriteLine("Input file name to read:");
                    string inputNameRead = Console.ReadLine();
                    FileStream fs = new FileStream(inputNameRead + ".txt", FileMode.Open, FileAccess.Read);
                    StreamReader sr = new StreamReader(fs);
                    sr.BaseStream.Seek(0, SeekOrigin.Begin);
                    string str = sr.ReadToEnd();
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (char.IsLetterOrDigit(str[i]) == true)
                        {
                            if (dict.ContainsKey(str[i]))
                            {
                                dict[str[i]]++;
                            }
                            else
                            {
                                dict.Add(str[i], 1);
                            }
                        }
                    }
                    Console.WriteLine("File read done.");
                    sr.Close();
                    fs.Close();
                }
                if (input == 3)
                {
                    Console.WriteLine("Input file name to write:");
                    string inputNameWrite = Console.ReadLine();
                    FileStream fs1 = new FileStream(inputNameWrite + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter streamWriter1 = new StreamWriter(fs1);
                    foreach (KeyValuePair<char, int> keyValuePair in dict)
                    {
                        streamWriter1.WriteLine(keyValuePair);
                        Console.WriteLine(keyValuePair);
                    }
                    Console.WriteLine("File written.");
                    streamWriter1.Flush();
                    streamWriter1.Close();
                    fs1.Close();
                }

            }

        }
        private static void Q2()
        {
            Console.WriteLine("Enter IP address");
            string ipAddress = Console.ReadLine();
            string[] splitIPAddress = ipAddress.Split('.');
            int countChecker = 0;
            foreach (string str in splitIPAddress)
            {
                Console.WriteLine(str);
            }
            for(int i = 0; i < splitIPAddress.Length; i++)
            {
                
                if (int.TryParse(splitIPAddress[i], out int value))
                {
                    if (splitIPAddress.Length == 4 && (value >= 0 && value <= 255))
                    {
                        countChecker++;
                    }
                }
            }
            if(countChecker == 4)
            {
                Console.WriteLine("IP address is valid.");
            }
            else
            {
                Console.WriteLine("IP address is invalid!");
            }
        }
        private static void Q3()
        {
            Console.WriteLine("Enter string");
            string input = Console.ReadLine();

            string str1 = input.Substring(0, input.Length / 2).ToLower();
            string str2 = input.Substring(input.Length / 2).ToLower();

            string vowels = "aeiou";

            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();

            foreach(char charac in str1)
            {
                if (vowels.Contains(charac))
                {
                    if (keyValuePairs.ContainsKey(charac))
                    {
                        keyValuePairs[charac] += 1;
                    }
                    else
                    {
                        keyValuePairs[charac] = 1;
                    }
                }
            }
            foreach(char charac in str2)
            {
                if (vowels.Contains(charac))
                {
                    if (keyValuePairs.ContainsKey(charac))
                    {
                        keyValuePairs[charac] -= 1;
                    }
                    else
                    {
                        keyValuePairs[charac] = -1;
                    }
                }
            }

            bool status = true;
            foreach(KeyValuePair<char, int> keyValuePair in keyValuePairs)
            {
                if(keyValuePair.Value != 0)
                {
                    status = false;
                    break;
                }
            }
            if (status)
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
