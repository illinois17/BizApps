using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NaSkorost_
{
    class Program
    {
        static void Main(string[] args)
        {
            string text="";
            List<string> words = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader("TextFile.txt"))
                {
                    text = sr.ReadToEnd();
                    //text.ToCharArray();
                    Console.WriteLine(text);
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }
            
            words = SplitText(text);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            
            Console.WriteLine("Содержит слов с цифрами: "+ContainingDigits(words));
            Console.ReadLine();

        }
        public static List<string> SplitText(string text)
        {
            string[] separator = { ",", "-", " ", ".", ";"};
            List<string> words = new List<string>();
            bool wordFlag = false;
            int wordBegin = 0;
            for (int index = 0; index < text.Length; index++)
            {
                string symbol = text.Substring(0, index);
                for (int separatorIndex = 0; separatorIndex < separator.Length; separatorIndex++)
                {
                    if (text[index].ToString() == separator[separatorIndex].ToString())
                    {
                        wordFlag = true;
                        break;
                    }
                }
                if (wordFlag == true)
                {
                    if (text.Substring(wordBegin, index - wordBegin) != String.Empty)
                        words.Add(text.Substring(wordBegin, index - wordBegin));
                    wordFlag = false;
                    wordBegin = index+1;
                }
                
            }
            if(text.Substring(wordBegin,text.Length-wordBegin) != String.Empty)
            {
                words.Add(text.Substring(wordBegin, text.Length - wordBegin));
            }
            return words;
        }

        public static int ContainingDigits(List<string> words)
        {
            int containDigits = 0;
            for(int index = 0; index<words.Count;index++)
            {
                for(int charIndex=0;charIndex<words[index].Length;charIndex++)
                {
                    if(Char.IsDigit(words[index],charIndex))
                    {
                        containDigits++;
                        break;
                    }
                }
            }
            return containDigits;
        }
        static bool qweqweIsDigitsOnly(string words)
        {
            foreach (char letter in words)
            {
                if (letter < '0' || letter > '9')
                    return false;
            }

            return true;
        }

        static private void test()
        {
            for (int i = 0; i <= 0xffff; ++i)
            {
                char c = (char)i;

                if (Char.IsDigit(c) != Char.IsNumber(c))
                {
                    Console.WriteLine("Char value {0:x} IsDigit() = {1}, IsNumber() = {2}", i, Char.IsDigit(c), Char.IsNumber(c));
                }
            }
        }
    }
}
