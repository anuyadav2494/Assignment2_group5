using System;
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
           
            foreach (int n in r)
            {
                Console.Write(n + " ");
            }

            Console.WriteLine(); Console.WriteLine();

            Console.WriteLine("Question 2");
            string s = "University of South Florida";
            string rs = StringReverse(s);
            Console.WriteLine(rs); Console.WriteLine();

            Console.WriteLine("Question 3");
            int[] l2 = new int[] { 2, 2, 3, 5, 6 };
            int sum = MinimumSum(l2);
            Console.WriteLine(sum); Console.WriteLine();

            Console.WriteLine("Question 4");
            string s2 = "yYkk";
            string sortedString = FreqSort(s2);
            Console.WriteLine(sortedString); Console.WriteLine();

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
            Console.WriteLine(ContainsDuplicate(arr, k)); Console.WriteLine();

            Console.WriteLine("Question 7");
            int rodLength = 4;
            int priceProduct = GoldRod(rodLength);
            Console.WriteLine(priceProduct); Console.WriteLine();

            Console.WriteLine("Question 8");
            string[] userDict = new string[] { "rocky", "usf", "hello", "apple" };
            string keyword = "rocky";
            Console.WriteLine(DictSearch(userDict, keyword)); Console.WriteLine();
            Console.WriteLine("Question 9"); Console.WriteLine();

            SolvePuzzle();

        }
        public static int[] TargetRange(int[] l1, int t)
        {
            try
            {
                //intialise result array
                int[] arr1 = { -1, -1 };

                int l = l1.Length;

                //Checking element which are matching target and storing its first occurance in arr1[0] and last occurance in arr1[1]

                for (int i = 0; i < l; i++)
                {
                    if (t == l1[i])
                    {
                        if (arr1[0] == -1)
                        {
                            arr1[0] = i;
                        }
                        arr1[1] = i;
                    }
                }
                return arr1;

            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string StringReverse(string s)
        {
            try
            {
                string str = "";
                string final = "";
                char[] letters = s.ToCharArray();
                int len = letters.Length;

                //tracing elements from backword and storing in temporary string untill space is found temporary sting is appneded to final string and reset to "" 
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

        }
        public static void DisplayArray(int[] a)
        {
            foreach (int n in a)
            {
                Console.Write(n + " ");
            }
        }

        public static int MinimumSum(int[] l2)
        {
            try
            {

                int sum = 0;

                //checking ith element with i+1th element if they are equal then increment i+1th elelement by 1

                for (int i = 0; i < (l2.Length - 1); i++)
                {
                    if (l2[i] == l2[i + 1])
                    {
                        l2[i + 1] = l2[i + 1] + 1;
                    }
                    //calculating sum by ith element and adding last element after iteration
                    sum = sum + l2[i];
                }

                sum = sum + l2[l2.Length - 1];
                return sum;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static string FreqSort(string s2)

        {
            try
            {

                char[] letters2 = s2.ToCharArray();
                string sortedString = "";
                Dictionary<string, int> dict = new Dictionary<string, int>();
                //generated dictionary and adding chararcters in string as items with the occurance as key.value
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
                //sorting dictionary and storing item in dictionary as per their count
                foreach (KeyValuePair<string, int> item in dict.OrderBy(key => key.Value))
                {
                    for (int i = 0; i < item.Value; i++)
                    {
                        sortedString = item.Key + sortedString;
                        //Console.Write(item.Key);
                    }
                }

                // Console.WriteLine(sortedString);
                return sortedString;


            }
            catch (Exception)
            {
                throw;
            }

        }

        static int binarySearch(int[] arr, int l, int r, int x)
        {
            //search element in sorted array by using binary search approach to reduce complexity to O(logn)
            if (r >= l)
            {
                int mid = l + (r - l) / 2;


                if (arr[mid] == x)
                    return mid;

                if (arr[mid] > x)
                    return binarySearch(arr, l, mid - 1, x);

                return binarySearch(arr, mid + 1, r, x);
            }

            return -1;
        }

        public static int[] Intersect1(int[] nums1, int[] nums2)
        {
            try
            {
                int l1 = nums1.Length;
                int l2 = nums2.Length;
                List<int> result = new List<int>();

                if (l1 > l2)
                {
                    int[] tempp = nums1;
                    nums1 = nums2;
                    nums2 = tempp;

                    int temp = l1;
                    l1 = l2;
                    l2 = temp;
                }
                //sorting array
                Array.Sort(nums1);
                Console.WriteLine();

                //finding intersection of arrays by using binary search method
                for (int i = 0; i < l1; i++)
                {

                    if (binarySearch(nums2, 0, l1 - 1, nums1[i]) != -1)
                        result.Add(nums1[i]);
                    //Console.Write(nums1[i] + " ");
                }

                int[] resultA = result.ToArray();
                return resultA;

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
                // converting array to dictionary by checking occurance of element using count and putting same as item and key value
                var num1D = nums1.GroupBy(n => n).ToDictionary(g => g.Key, g => g.Count());

                //finding intersection using containskey on num1D as per its occurance in nums2 and returning same as array
                return nums2.Where(n => num1D.ContainsKey(n) && num1D[n]-- > 0).ToArray();
            }
            catch
            {
                throw;
            }
        }

        public static bool ContainsDuplicate(char[] arr, int k)
        {
            try
            {
                var numsSet = new Dictionary<int, int>();

                // checking characters in array and storing in dictionary with its index
                for (int i = 0; i < arr.Length; i++)
                {
                    var num = arr[i];
                    if (!numsSet.ContainsKey(num))
                    {
                        numsSet.Add(num, i);
                    }
                    else
                    {
                        //if the second occurance of duplicate element is at most equal to target then return true else return false outside for loop.
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

        }

        public static int GoldRod(int rodLength)
        {
            try
            {

                int maxcost = 0;
                for (int i = 1; i < rodLength; i++)

                {
                    //checking max betweeen maxcost and max between i*(rodlength-i) and i*GoldRod(rodLength - i) recursively
                    maxcost = Math.Max(maxcost, Math.Max(i * (rodLength - i), i * GoldRod(rodLength - i)));
                }
                return maxcost;
            }


            catch (Exception)
            {
                throw;
            }

        }

        public static bool DictSearch(string[] userDict, string keyword)
        {
            try
            {
                for (int i = 0; i < userDict.Length; i++)
                {
                    //checking length of word with keyword if does not match skip the particular iteration
                    string word = userDict[i];

                    if (word.Length != keyword.Length)
                    {
                        continue;
                    }
                    //converting string to character array
                    char[] str1 = word.ToCharArray();
                    char[] str2 = word.ToCharArray();
                    int count = 0;

                    //comparing characters in both string and if it does not match increment count
                    for (int j = 0; j < str1.Length; j++)
                    {
                        if (str1[j] != str2[j])
                        {
                            count += 1;
                        }
                        //when count is one and element at last return true otherwise false
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
