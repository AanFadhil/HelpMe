using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyToText
{
    class CurrencyToText
    {
        static void Main(string[] args)
        {
            string val;
            Console.Write("Enter Currency: ");
            val = Console.ReadLine();

            double n;
            bool isNumeric = double.TryParse(val, out n);

            if (isNumeric)
            {
                string a = Terbilang(val);
                Console.WriteLine(a);
            } else
            {
                Console.WriteLine("Input must be a positive valid number");
            }
            Console.ReadLine();
        }

        #region terbilang

        /// cheque writing for dollar currency
        /// input number with string format. seperate by dot (.) between dollar and cent.
        public static string Terbilang(string number)
        {
            string terbilang = "";

            number = number.Replace(",", ".");

            var split = number.Split('.');

            string sebelumkoma = split[0];
            string setelahKoma;

            if (number.Contains("."))
            {
                setelahKoma = split[1];
            }
            else
            {
                setelahKoma = "";
            }
            //convert dollar
            string terbilangSebelumKoma = PreTerbilang(sebelumkoma, 1);

            //convert cent
            string terbilangSetelahKoma = "";
            terbilangSetelahKoma = PreTerbilang(setelahKoma, 2);
            terbilangSetelahKoma = terbilangSetelahKoma.Trim();

            terbilang += terbilangSebelumKoma;

            if (!string.IsNullOrEmpty(terbilangSetelahKoma) || !string.IsNullOrWhiteSpace(terbilangSetelahKoma))
            {
                //if zero dollar, only show cent
                if (terbilang == "Zero Dollars")
                {
                    terbilang = terbilangSetelahKoma;
                }
                else
                {
                    terbilang += " And " + terbilangSetelahKoma;
                }
            }

            return terbilang;


        }

        private static string PreTerbilang(string number, int tipe)
        {
            List<string> sebutan = new List<string>();
            sebutan.Add("");
            sebutan.Add(" Thousand"); //10^3
            sebutan.Add(" Million"); //10^6
            sebutan.Add(" Billion"); //10^9
            sebutan.Add(" Trillion"); //10^12
            sebutan.Add(" Quadrillion"); //10^15
            sebutan.Add(" Quintillion"); //10^18
            sebutan.Add(" Sextillion"); //10^21
            sebutan.Add(" Septillion"); //10^24
            sebutan.Add(" Octillion"); //10^27
            sebutan.Add(" Nonillion"); //10^30
            sebutan.Add(" Decillion"); //10^33

            string terbilang = "";
            number = number.Trim();
            if (number.All(char.IsDigit))
            {

                try
                {

                    int i = number.Length - 1;
                    int counterSebutan = 0;
                    int counter3angka = 0;
                    string toTigaAngka = "";


                    while (i >= 0)
                    {
                        if (counter3angka < 3)
                        {
                            toTigaAngka = toTigaAngka.Insert(0, number[i].ToString());
                            counter3angka++;
                        }

                        if (counter3angka >= 3 || i == 0)
                        {
                            if (toTigaAngka != "000")
                            {
                                //if (i == 0 && counterSebutan != 0)
                                if (i != 0)
                                {
                                    terbilang = terbilang.Insert(0, " And" +BacaTigaAngka(toTigaAngka) + sebutan[counterSebutan]);
                                }
                                else
                                {
                                    terbilang = terbilang.Insert(0, BacaTigaAngka(toTigaAngka) + sebutan[counterSebutan]);
                                }
                            }
                            counter3angka = 0;
                            counterSebutan++;
                            toTigaAngka = "";
                        }
                        i--;
                    }

                    terbilang = terbilang.Replace("  ", " ");
                    if (terbilang != "" && tipe == 1)
                    {
                        if (terbilang == " One")
                        {
                            terbilang += " Dollar";
                        }
                        else
                        {
                            terbilang += " Dollars";
                        }

                    }
                    else if (terbilang != "" && tipe == 2)
                    {
                        if (terbilang == " One")
                        {
                            terbilang += " Cent";
                        }
                        else
                        {
                            terbilang += " Cents";
                        }
                    }

                    return terbilang.Trim();
                }
                catch (Exception)
                {
                    terbilang = "";
                }
            }
            else
            {

                terbilang = "";
            }
            if (terbilang != "" && tipe == 1)
            {
                if (terbilang == " One")
                {
                    terbilang += " Dollar";
                }
                else
                {
                    terbilang += " Dollars";
                }
            }
            else if (terbilang != "" && tipe == 2)
            {
                if (terbilang == " One")
                {
                    terbilang += " Cent";
                }
                else
                {
                    terbilang += " Cents";
                }
            }
            return terbilang.Trim();
        }

        private static string BacaTigaAngka(string number)
        {
            // define number per three digits
            string terbilang = "";
            string fixterbilang = "";
            try
            {

                if (number == "0")
                {
                    terbilang = "Zero";
                }
                else
                {
                    number = Convert.ToInt32(number).ToString();
                    terbilang = " " + BacaSatuAngka(number[number.Length - 1].ToString());
                    if (number != "0")
                    {
                        // length string > 2 And second digit != 0
                        if (number.Length >= 2 && number[number.Length - 2].ToString() != "0")
                        {
                            // get teen number, second digit = 1 And last digit != 0
                            if (number[number.Length - 2].ToString() == "1" && number[number.Length - 1].ToString() != "0")
                            {
                                terbilang = terbilang.Insert(terbilang.Length, "Teen");
                            }
                            else
                            {
                                //get tens number
                                terbilang = terbilang.Insert(0, " " + BacaSatuAngka(number[number.Length - 2].ToString()) + "Ty");
                            }
                        }

                        if (number.Length == 3)
                        {
                            // get hundred numbers
                            terbilang = terbilang.Insert(0, " " + BacaSatuAngka(number[number.Length - 3].ToString()) + " Hundred");
                        }
                    }
                }

                //correction format with replacing 
                fixterbilang = ReplaceTerbilang(terbilang);

            }
            catch (Exception e)
            {
                return "";
            }
            return fixterbilang;

        }

        private static string BacaSatuAngka(string number)
        {
            number = number.Trim();
            string terbilang = "";
            int i = Convert.ToInt32(number);

            switch (i)
            {
                case 0:
                    terbilang = "Zero";
                    break;
                case 1:
                    terbilang = "One";
                    break;
                case 2:
                    terbilang = "Two";
                    break;
                case 3:
                    terbilang = "Three";
                    break;
                case 4:
                    terbilang = "Four";
                    break;
                case 5:
                    terbilang = "Five";
                    break;
                case 6:
                    terbilang = "Six";
                    break;
                case 7:
                    terbilang = "Seven";
                    break;
                case 8:
                    terbilang = "Eight";
                    break;
                case 9:
                    terbilang = "Nine";
                    break;

                default:
                    break;
            }

            return terbilang;
        }

        private static string ReplaceTerbilang(string terbilang)
        {
            //fix teen
            terbilang = terbilang.Replace("OneTy", "Ten");
            terbilang = terbilang.Replace("OneTeen", "Eleven");
            terbilang = terbilang.Replace("TwoTeen", "Twelve");
            terbilang = terbilang.Replace("ThreeTeen", "Thirteen");
            terbilang = terbilang.Replace("FourTeen", "Fourteen");
            terbilang = terbilang.Replace("FiveTeen", "Fifteen");
            terbilang = terbilang.Replace("SixTeen", "Sixteen");
            terbilang = terbilang.Replace("SevenTeen", "Seventeen");
            terbilang = terbilang.Replace("EightTeen", "Eighteen");
            terbilang = terbilang.Replace("NineTeen", "Nineteen");

            //fix tens
            terbilang = terbilang.Replace("TwoTy", "Twenty");
            terbilang = terbilang.Replace("ThreeTy", "Thirty");
            terbilang = terbilang.Replace("FourTy", "Forty");
            terbilang = terbilang.Replace("FiveTy", "Fifty");
            terbilang = terbilang.Replace("SixTy", "Sixty");
            terbilang = terbilang.Replace("SevenTy", "Seventy");
            terbilang = terbilang.Replace("EightTy", "Eighty");
            terbilang = terbilang.Replace("NineTy", "Ninety");

            //special input multiple of 10 and 100
            terbilang = terbilang.Replace("Ten Zero", "Ten");
            terbilang = terbilang.Replace("Twenty Zero", "Twenty");
            terbilang = terbilang.Replace("Thirty Zero", "Thirty");
            terbilang = terbilang.Replace("Forty Zero", "Forty");
            terbilang = terbilang.Replace("Fifty Zero", "Fifty");
            terbilang = terbilang.Replace("Sixty Zero", "Sixty");
            terbilang = terbilang.Replace("Seventy Zero", "Seventy");
            terbilang = terbilang.Replace("Eighty Zero", "Eighty");
            terbilang = terbilang.Replace("Ninety Zero", "Ninety");

            terbilang = terbilang.Replace("One Hundred Zero", "One Hundred");
            terbilang = terbilang.Replace("Two Hundred Zero", "Two Hundred");
            terbilang = terbilang.Replace("Three Hundred Zero", "Three Hundred");
            terbilang = terbilang.Replace("Four Hundred Zero", "Four Hundred");
            terbilang = terbilang.Replace("Five Hundred Zero", "Five Hundred");
            terbilang = terbilang.Replace("Six Hundred Zero", "Six Hundred");
            terbilang = terbilang.Replace("Seven Hundred Zero", "Seven Hundred");
            terbilang = terbilang.Replace("Eight Hundred Zero", "Eight Hundred");
            terbilang = terbilang.Replace("Nine Hundred Zero", "Nine Hundred");


            return terbilang;
        }



        #endregion terbilang
    }
}
