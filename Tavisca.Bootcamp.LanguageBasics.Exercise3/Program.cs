using System;
using System.Collections.Generic;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise3
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 },
                new[] { 2, 8 },
                new[] { 5, 2 },
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" },
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 },
                new[] { 2, 8, 5, 1 },
                new[] { 5, 2, 4, 4 },
                new[] { "tFc", "tF", "Ftc" },
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 },
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 },
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 },
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" },
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }
        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            int[] Answer = new int[dietPlans.Length];
            var Calorie = new int[protein.Length];
            int Low,High;
            for (int i=0;i<protein.Length;i++)
            {
                Calorie[i]=(protein[i]+carbs[i])*4+fat[i]*9;
            }
            for (int i=0;i<dietPlans.Length;i++)
            {
                List<int> diet=new List<int>();
                var index=Enumerable.Range(0, protein.Length).ToList();
                for(int j=0;j<dietPlans[i].Length;j++)
                {
                    diet=new List<int>();
                    if (dietPlans[i][j] == 'C')
                    {
                        High = carbs[index[0]];
                        foreach(int k in index)
                            if(High < carbs[k])
                                High = carbs[k];
                        foreach(int k in index)
                            if(High == carbs[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'P')
                    {
                        High = protein[index[0]];
                        foreach(int k in index)
                            if(High < protein[k])
                                High = protein[k];
                        foreach(int k in index)
                            if(High == protein[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'F')
                    {
                        High = fat[index[0]];
                        foreach(int k in index)
                            if(High < fat[k])
                                High = fat[k];
                        foreach(int k in index)
                            if(High == fat[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'T')
                    {
                        High = Calorie[index[0]];
                        foreach(int k in index)
                            if(High < Calorie[k])
                                High = Calorie[k];
                        foreach(int k in index)
                            if(High == Calorie[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'c')
                    {
                        Low = carbs[index[0]];
                        foreach(int k in index)
                            if(Low > carbs[k])
                                Low = carbs[k];
                        foreach(int k in index)
                            if(Low == carbs[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'p')
                    {
                        Low = protein[index[0]];
                        foreach(int k in index)
                            if(Low > protein[k])
                                Low = protein[k];
                        foreach(int k in index)
                            if(Low == protein[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'f')
                    {
                        Low = fat[index[0]];
                        foreach(int k in index)
                            if(Low > fat[k])
                                Low = fat[k];
                        foreach(int k in index)
                            if(Low == fat[k])
                                diet.Add(k);
                    }

                    else if(dietPlans[i][j] == 't')
                    {
                        Low = Calorie[index[0]];
                        foreach(int k in index)
                            if(Low > Calorie[k])
                                Low = Calorie[k];
                        foreach(int k in index)
                            if(Low == Calorie[k])
                                diet.Add(k);
                    }
                    if(diet.Count == 1)
                        break;
                    index = diet;
                }
                if(dietPlans[i] == "")
                    Answer[i] = 0;
                else
                    Answer[i] = diet[0];
            }
            return Answer;
        }
    }
}
