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
            int[] answer = new int[dietPlans.Length];
            var calorie = new int[protein.Length];
            int low,high;
            for (int i=0;i<protein.Length;i++)
            {
                calorie[i]=(protein[i]+carbs[i])*4+fat[i]*9;
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
                        high = carbs[index[0]];
                        foreach(int k in index)
                            if(high < carbs[k])
                                high = carbs[k];
                        foreach(int k in index)
                            if(high == carbs[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'P')
                    {
                        high = protein[index[0]];
                        foreach(int k in index)
                            if(high < protein[k])
                                high = protein[k];
                        foreach(int k in index)
                            if(high == protein[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'F')
                    {
                        high = fat[index[0]];
                        foreach(int k in index)
                            if(high < fat[k])
                                high = fat[k];
                        foreach(int k in index)
                            if(high == fat[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'T')
                    {
                        high = calorie[index[0]];
                        foreach(int k in index)
                            if(high < calorie[k])
                                high = calorie[k];
                        foreach(int k in index)
                            if(high == calorie[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'c')
                    {
                        low = carbs[index[0]];
                        foreach(int k in index)
                            if(low > carbs[k])
                                low = carbs[k];
                        foreach(int k in index)
                            if(low == carbs[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'p')
                    {
                        low = protein[index[0]];
                        foreach(int k in index)
                            if(low > protein[k])
                                low = protein[k];
                        foreach(int k in index)
                            if(low == protein[k])
                                diet.Add(k);
                    }
                    else if(dietPlans[i][j] == 'f')
                    {
                        low = fat[index[0]];
                        foreach(int k in index)
                            if(low > fat[k])
                                low = fat[k];
                        foreach (int k in index)
                            if (low == fat[k])
                                diet.Add(k);
                    }

                    else if(dietPlans[i][j] == 't')
                    {
                        low = calorie[index[0]];
                        foreach(int k in index)
                            if(low > calorie[k])
                                low = calorie[k];

                        foreach(int k in index)
                            if(low == calorie[k])
                                diet.Add(k);
                    }
                    if(diet.Count == 1)
                        break;
                    index = diet;
                }
                if(dietPlans[i] == "")
                    answer[i] = 0;
                else
                    answer[i] = diet[0];
            }
            return answer;
        }
    }
}
