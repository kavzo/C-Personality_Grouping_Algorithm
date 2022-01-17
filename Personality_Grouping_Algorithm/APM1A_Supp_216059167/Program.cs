using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace APM1A_Supp_216059167
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> artisan = new List<int>();
            List<int> Guardians = new List<int>();
            List<int> Rationals = new List<int>();
            List<int> Idealists = new List<int>();
            List<int> artisan_int = new List<int>();
            List<int> Guardians_int = new List<int>();
            List<int> Rationals_int = new List<int>();
            List<int> Idealists_int = new List<int>();
            int student_total = 0, adder = 1, ans = 0;
            bool dynamic = false, diverse = false, result = false;
            while (result == false)
            {
                try
                {
                    Console.WriteLine("Please enter how many students in the group.");
                    ans = Convert.ToInt32(Console.ReadLine());
                    result = true;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    result = false;
                }
            }
            //POSSILE PERSONALITY TRAITS (based on the MBTI assesment)
            Console.WriteLine("1 = ESTP\t2 = ISTP\t3 = ESFP\t4 = ISFP");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("5 = ESTJ\t6 = ISTJ\t7 = ESFJ\t8 = ISFJ");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("9 = ENTJ\t10 = INTJ\t11 = ENTP\t12 = INTP");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("13 = ENFJ\t14 = INFJ\t15 = ENFP\t16 = INFP\n");
            //Personalitiy traits allocation
            for (int x = 1; x <= ans; x++)
            {
                int trait = 0;
                student_total++;
                try
                {
                    Console.WriteLine("Please enter the numerical value of the personality trait for student " + x + " (based on the MBTI assesment). ");
                    trait = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                if (trait == 1 || trait == 2 || trait == 3 || trait == 4)
                {
                    artisan.Add(trait);
                    artisan_int.Add(adder);
                }
                else if (trait == 5 || trait == 6 || trait == 7 || trait == 8)
                {
                    Guardians.Add(trait);
                    Guardians_int.Add(adder);
                }
                else if (trait == 9 || trait == 10 || trait == 11 || trait == 12)
                {
                    Rationals.Add(trait);
                    Rationals_int.Add(adder);
                }
                else if (trait == 13 || trait == 14 || trait == 15 || trait == 16)
                {
                    Idealists.Add(trait);
                    Idealists_int.Add(adder);
                }
                else
                {
                    Console.WriteLine("Invalid Perosnality trait, Student scratched");
                    student_total--;
                }
            }
            //CALCULATE SUM
            float artisan_sum = artisan_int.Sum(), guard_sum = Guardians_int.Sum(),
                ration_sum = Rationals_int.Sum(), ideal_sum = Idealists_int.Sum();
            
            //CALCULATE AVERAGE
            float artisan_avg = (artisan_sum / student_total) * 100, guard_avg = (guard_sum / student_total) * 100, 
                ration_avg = (ration_sum / student_total) * 100, ideal_avg = (ideal_sum / student_total) * 100;

            Console.WriteLine("\nTotal students = " + student_total);
            Console.WriteLine("Artisan Type Members = " + artisan_avg + "%");
            Console.WriteLine("Guardian Type Members = " + guard_avg + "%");
            Console.WriteLine("Rationals Type Members = " + ration_avg + "%");
            Console.WriteLine("Idealists Type Members = " + ideal_avg + "%");

            //GROUP DYNAMIC
            if (artisan_avg >= 50 || guard_avg >= 50 || ration_avg >= 50 || ideal_avg >= 50)
            {
                Console.WriteLine("\nGroup Dynamic = POSITIVE");
                dynamic = true;
            }
            else { Console.WriteLine("\nGroup Dynamic = NEGATIVE"); }

            //GROUP DIVERSITY
            if (artisan_sum == 1 * student_total || guard_sum == 1 * student_total || ration_sum == 1 * student_total || ideal_sum == 1 * student_total)
            {
                int artisan_total = artisan.Sum(), guard_total = Guardians.Sum(), 
                    ration_total = Rationals.Sum(), ideal_total = Idealists.Sum();

                if ((artisan_total == 1 * student_total || artisan_total == 2 * student_total || artisan_total == 3 * student_total || artisan_total == 4 * student_total)
                    || (guard_total == 5 * student_total || guard_total == 6 * student_total || guard_total == 7 * student_total || guard_total == 8 * student_total) ||
                    (ration_total == 9 * student_total || ration_total == 10 * student_total || ration_total == 11 * student_total || ration_total == 12 * student_total) ||
                    (ideal_total == 13 * student_total || ideal_total == 14 * student_total || ideal_total == 15 * student_total || ideal_total == 16 * student_total))
                {
                    Console.WriteLine("Group Diversity: POOR");
                }
                else {
                    Console.WriteLine("Group Diversity: GOOD");
                    diverse = true;
                }
            }
            else
            { Console.WriteLine("Group Diversity: GOOD");
                diverse = true;
            }
            //FINAL RESULT
            if (dynamic == true && diverse == true)
            {
                Console.WriteLine("\nFinal Group Result = This is an Effective Group");
            }
            else if (dynamic == false || diverse == false)
            {
                Console.WriteLine("\nFinal Group Result: This is an Average Group, group effectiveness is probable");
            }
            else { Console.WriteLine("\nFinal Group Result: This is an Ineffective Group"); }
            Console.ReadLine();
        }
    }
}
