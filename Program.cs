using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2_CT_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int[] l1 = new int[] { 5, 6, 6, 9, 9, 12 };
            int target = 9;
            int[] r = TargetRange(l1, target);
            // Write your code to print range r here
            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs);
            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum);
            Console.WriteLine("Question 4");
            string s2 = "Dell";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString);
            Console.WriteLine("Question 5-Part 1");
            int[] nums1 = { 1, 2, 2, 1 };
            int[] nums2 = { 2, 2 };
            int[] intersect1 = Intersect1(nums1, nums2);
            Console.WriteLine("Part 1- Intersection of two arrays is: ");
            DisplayArray(intersect1);
            Console.WriteLine("\n");
            Console.WriteLine("Question 5-Part 2");
            int[] intersect2 = Intersect2(nums1, nums2);
            Console.WriteLine("Part 2- Intersection of two arrays is: ");
            DisplayArray(intersect2);
            Console.WriteLine("\n");
            Console.WriteLine("Question 6");
            char[] arr = new char[] { 'a', 'g', 'h', 'a' };
            int k = 3;
            Console.WriteLine(ContainsDuplicate(arr, k));
            Console.WriteLine("Question 7");
            int rodLength = 4;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct);
            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "hhllo";
          
        Console.WriteLine(DictSearch(userDict, keyword));
//Console.WriteLine("Question 8");
            SolvePuzzle();
        }
        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }
        public static int[] TargetRange(int[] l1, int t)
        {
            try
            {
                int[] arr1 = { -1, -1 };
                //initialize an Arraylist
                ArrayList al = new ArrayList();
                //traverse along the given array l1
                for (int i = 0; i < l1.Length; i++)
                {
                    //if the element at the index equals the target,the index is added to arraylist
                    if (l1[i] == t)
                    {
                        al.Add(i);
                    }
                }

                //initializing integer n and storing last index of arraylist
                int n = al.Count - 1;
                //if the arraylist is empty,print the [-1,-1]

                //convert n to string
                string b = n.ToString();
                //Print the first and last elements of arraylist
                if (al != null)
                {
                    Console.WriteLine("Array is [" + al[0] + "," + al[n] + "]");
                }
                else
                    return arr1;
                   
                

            }
            catch (Exception)
            {
                throw;
            }
            return new int[] { };
        }
        public static string StringReverse(string s)
        {
            try
            {
                string str = "";
                string final = "";
                char[] letters = s.ToCharArray();
                int len = letters.Length;
                for (int i = len - 1; i >= 0; i--)
                {
                    if (letters[i].ToString().Equals(" "))
                    {
                        final = " " + str + final;
                        str = "";
                    }

                    else
                    {
                        str = str + letters[i];
                    }

                }
                str += final;

                return str;
            }
            catch (Exception)
            {
                throw;
            }
            return null;
        }
        public static int MinimumSum(int[] l2)
        {
            try
            {
                int sum = 0;

                for (int i = 0; i < (l2.Length - 1); i++)
                {
                    if (l2[i] == l2[i + 1])
                    {
                        l2[i + 1] = l2[i + 1] + 1;
                    }
                    sum = sum + l2[i];
                }

                sum = sum + l2[l2.Length - 1];
                return sum;
            }
            catch (Exception)
            {
                throw;
            }
            return 0;
        }
        public static string FreqSort(string s2)
    
{
try
{
                char[] letters2 = s2.ToCharArray();
                string sortedString = "";
                Dictionary<string, int> dict = new Dictionary<string, int>();

                for (int i = 0; i < letters2.Length; i++)
                {
                    if (dict.ContainsKey(letters2[i].ToString()))
                    {
                        dict[letters2[i].ToString()] = dict[letters2[i].ToString()] + 1;
                    }
                    else
                    {
                        dict.Add(letters2[i].ToString(), 1);
                    }
                }
                foreach (KeyValuePair<string, int> item in dict.OrderBy(key => key.Value))
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        sortedString = item.Key + sortedString;
                       
                    }
                }

               
                return sortedString;

            }
            catch (Exception)
{
throw;
}
return null;
}
public static int[] Intersect1(int[] nums1, int[] nums2)
{
    try
    {
                int n = nums1.Length;
                int m = nums2.Length;
                int i = 0;
                int j = 0;
                while (i < n && j < m)
                {
                    if (nums1[i] > nums2[j])
                    {
                        j++;
                    }
                    else if (nums2[j] > nums1[i])
                    {
                        i++;
                    }
                    else
                    {
                        Console.Write(nums1[i] + " ");
                        i++;
                        j++;
                    }
                }
            }
    catch
    {
        throw;
    }
    return new int[] { };
}
public static int[] Intersect2(int[] nums1, int[] nums2)
{
    try
    {
                var map1 = nums1.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());
                return nums2.Where(n => map1.ContainsKey(n) && map1[n]-- > 0).ToArray();
            }
    catch
    {
        throw;
    }
    return new int[] { };
}
public static bool ContainsDuplicate(char[] arr, int k)
{
            try
            {
                var numsSet = new Dictionary<int, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    var num = arr[i];
                    if (!numsSet.ContainsKey(num))
                    {
                        numsSet.Add(num, i);
                    }
                    else
                    {
                        if (i - numsSet[num] <= k) return true;
                        else numsSet[num] = i;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
    return default;
}
public static int GoldRod(int rodLength)
{
    try
    {
                int max_price = 0;
                for (int i = 1; i < rodLength; i++)

                {
                    max_price = Math.Max(max_price, Math.Max(i * (rodLength - i), i * GoldRod(rodLength - i)));
                }
                return max_price;

            }
    catch (Exception)
    {
        throw;
    }
    return 0;
}
public static bool DictSearch(string[] userDict, string keyword)
{
    try
    {
                for (int i = 0; i < userDict.Length; i++)
                {

                    string word = userDict[i];

                    if (word.Length != keyword.Length)
                    {
                        continue;
                    }

                    char[] str1 = word.ToCharArray();
                    char[] str2 = word.ToCharArray();
                    int count = 0;
                    for (int j = 0; j < str1.Length; j++)
                    {
                        if (str1[j] != str2[j])
                        {
                            count += 1;
                        }

                        if (count == 1 && j == str1.Length - 1)
                        {
                            return true;
                        }

                    }


                }

                return false;
            }
    catch (Exception)
    {
        throw;
    }
    return default;
}
public static void SolvePuzzle()
{
    try
    {
        //Write Your Code Here
    }
    catch (Exception)
    {
        throw;
    }
}
}
}
