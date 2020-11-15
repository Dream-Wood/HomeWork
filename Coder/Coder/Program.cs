using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Coder
{
    internal class Program
    {
        private static string morseEncryptPath = "../../morse-encrypt-code.json";
        private static string morseDecryptPath = "../../morse-decrypt-code.json";
        private static Dictionary<char, string> _morseEncryptCode;
        private static Dictionary<string, string> _morseDecryptCode;
        private static char insertOne;
        private static char insertTwo;
        private static char[] morseEncryptMessage;
        private static string morseDecryptMessage;
        private static int shiftMessage;

        public static void Main(string[] args)
        {
            if (File.Exists(morseEncryptPath))
            {
                Console.WriteLine($"Morse code on path {morseEncryptPath}, loaded successfully");
                string EnJson = File.ReadAllText(morseEncryptPath);
                _morseEncryptCode = JsonConvert.DeserializeObject<Dictionary<char, string>>(EnJson);

                string DeJson = File.ReadAllText(morseDecryptPath);
                _morseDecryptCode = JsonConvert.DeserializeObject<Dictionary<string, string>>(DeJson);
            }
            else
            {
                Console.WriteLine($"Morse code file is missing from path {morseEncryptPath}");
            }

            Console.WriteLine("encrypt = 1, decrypt = 2");
            insertOne = Console.ReadLine().ToCharArray()[0];
            if (insertOne == '1')
            {
                Console.WriteLine("Choose an encryption method (1 = Morse, 2 = Caesar, 3 = Permutation)");
                insertTwo = Console.ReadLine().ToCharArray()[0];
                if (insertTwo == '1')
                {
                    Console.WriteLine("Please enter your message");
                    morseEncryptMessage = Console.ReadLine().ToLower().ToCharArray();
                    Console.WriteLine(MorseEncrypt(morseEncryptMessage));
                }

                if (insertTwo == '2')
                {
                    Console.WriteLine("Please enter shift");
                    shiftMessage = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter your message");
                    Console.WriteLine(CaesarEncrypt(Console.ReadLine().ToLower().ToCharArray()));
                }

                if (insertTwo == '3')
                {
                    Console.WriteLine("Please enter your message");
                    Console.WriteLine(PermutationEncrypt(Console.ReadLine().ToList()));
                }
            }
            else
            {
                Console.WriteLine("Choose an decryption method (1 = Morse, 2 = Caesar, 3 = Permutation)");
                insertTwo = Console.ReadLine().ToCharArray()[0];
                if (insertTwo == '1')
                {
                    Console.WriteLine("Please enter your message");
                    morseDecryptMessage = Console.ReadLine();
                    Console.WriteLine(MorseDecrypt(morseDecryptMessage));
                }

                if (insertTwo == '2')
                {
                    Console.WriteLine("Please enter shift");
                    shiftMessage = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Please enter your message");
                    Console.WriteLine(CaesarDecrypt(Console.ReadLine().ToLower().ToCharArray()));
                }
                
                if (insertTwo == '3')
                {
                    Console.WriteLine("Please enter your message");
                    Console.WriteLine(PermutationDecrypt(Console.ReadLine().ToList()));
                }
            }
        }

        public static string MorseEncrypt(char[] _text)
        {
            string message = "";
            foreach (char i in _text)
            {
                message += _morseEncryptCode[i] + " ";
            }

            return message;
        }

        public static string MorseDecrypt(string _text)
        {
            string message = "";
            _text += " ";
            while (_text.Contains(" "))
            {
                message += _morseDecryptCode[_text.Substring(0, _text.IndexOf(" "))];
                _text = _text.Remove(0, _text.IndexOf(" ") + 1);
            }

            return message;
        }

        public static string CaesarEncrypt(char[] _text)
        {
            string message = "";
            int temp = ' ';
            foreach (char i in _text)
            {
                temp = (int) i + shiftMessage;
                if (temp > 122) temp -= 25;
                message += (char) temp;
            }

            return message;
        }

        public static string CaesarDecrypt(char[] _text)
        {
            string message = "";
            int temp = ' ';
            foreach (char i in _text)
            {
                temp = (int) i - shiftMessage;
                if (temp < 97) temp += 25;
                message += (char) temp;
            }

            return message;
        }

        public static string PermutationEncrypt(List<char> _text)
        {
            string message = "";
            _text.Insert(0, ' ');
            int temp = ' ';
            for (int i = 0; i < _text.Count; i++)
            {
                if (i > 0)
                {
                    Math.DivRem(i, 2, out int x);
                    if (x == 0)
                    {
                        message += _text[i];
                        message += _text[i - 1];
                    }
                }
            }
            return message;
        }
        
        public static string PermutationDecrypt(List<char> _text)
        {
            string message = "";
            _text.Insert(0, ' ');
            int temp = ' ';
            for (int i = 0; i < _text.Count; i++)
            {
                if (i > 0)
                {
                    Math.DivRem(i, 2, out int x);
                    if (x == 0)
                    {
                        message += _text[i];
                        message += _text[i - 1];
                    }
                }
            }
            return message;
        }
    }
}