namespace ConsoleApplication1
{
    using System.IO.Compression;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ConsoleApp2
    {
        internal class Program
        {
            static bool isInternational, advance, inSeason, longTermCust;
            static int age;
            static int discountmax = 30;
            static int discount;

            static int Discount
            {
                get => discount;
                set
                {
                    discount += value;
                    if (age < 2 && isInternational == true)
                    {
                        discount = 70;
                    }
                    else if (age < 2)
                    {
                        discount = 80;
                    }
                    else if (discount > discountmax)
                    {
                        discount = discountmax;
                    }
                }
            }



            static void Main(string[] args)
            {
                Console.WriteLine("age? format: DD-MM-YYYY");
                AgeCalc(Console.ReadLine());

                Console.WriteLine("flight type? format: international/domestic");
                isInternational = FlightType(Console.ReadLine());

                Console.WriteLine("When do you want to fly? format: DD-MM-YYYY");
                advance = Advance(Console.ReadLine());

                Console.WriteLine("Are you a long term customer? Y/N");
                longTermCust = LongTerm(Console.ReadLine());

                Console.Write("Your total discount comes out to: ");
                Console.Write(DiscountCalc());
                Console.ReadKey();

            }
            static double DiscountCalc()
            {
                Discount = 0;


                if (!inSeason && isInternational == true) // in season + international
                {

                    if (2 <= age && 16 >= age) Discount = + +10;
                    if (advance) Discount = +10;
                    if (longTermCust) Discount = +15;

                }
                else if (inSeason)
                {

                    if (isInternational == true) Discount = +15;

                }
                else if (isInternational == false) // Domestic 
                {

                    if (2 <= age && 16 >= age) Discount = +10;
                    if (advance) Discount = +15;
                    if (longTermCust) Discount = +15;
                }
                return Discount;
            }


            static bool Season(DateTime input)
            {
                if (input.Month == 12 && input.Day >= 20 ||
                    (input.Year == DateTime.Today.Year + 1 && input.Month == 1 && input.Day <= 10) ||
                    (input.Month == 3 && input.Day >= 20) && (input.Month == 3 && input.Day >= 20) ||
                    input.Month == 7 ||
                    input.Month == 8)
                {
                    return true;
                }

                return false;
            }




            static bool LongTerm(string yn)
            {
                if (yn.ToLower() == "y") return true;
                return false;
            }



            static bool Advance(string input)
            {

                if ((Time(input).Year - DateTime.Today.Year) >= 1) return true;
                else if ((Time(input).Month - DateTime.Today.Month) >= 5) return true;
                return false;

            }

            static bool FlightType(string type)
            {
                if (type.ToLower() == "international") return true;
                return false;
            }

            static void AgeCalc(string input)
            {
                age = (int)((DateTime.Today - Time(input)).TotalDays / 365);
                if (age == 0) age++;
            }

            static DateTime Time(string input)
            {
                string[] x = input.Split('-');
                DateTime time = new DateTime(Int32.Parse(x[2]),
                                          Int32.Parse(x[1]),
                                          Int32.Parse(x[0]));
                return time;
            }
        }
    }

}
