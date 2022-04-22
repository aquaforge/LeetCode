using System.Collections;
using System.Collections.Generic;

namespace LeetCodeSolver
{

    public class LeetCodeSolver
    {
        //Remove Duplicates from Sorted Array
        //https://leetcode.com/explore/featured/card/top-interview-questions-easy/92/array/727/
        public int RemoveDuplicates(int[] nums)
        {
            int[] nums2 = nums.Distinct().ToArray();
            nums2.CopyTo(nums, 0);
            return nums2.Length;
        }


        //Rotate Array
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/646/
        public void Rotate(int[] nums, int k)
        {
            if (k < 0) return;

            k %= nums.Length;
            int[] nums1 = nums[..(nums.Length - k)];
            int[] nums2 = nums[^k..];
            nums2.CopyTo(nums, 0);
            nums1.CopyTo(nums, nums2.Length);
        }


        //Two Sum
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/546/

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new();
            for (int i = 0; i < nums.Length; i++)
                dict[nums[i]] = i;
            for (int i = 0; i < nums.Length; i++)
                if (dict.TryGetValue(target - nums[i], out int j))
                    if (i != j) return new int[] { i, j };

            throw new KeyNotFoundException("not found");
        }


        //Single Number
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/
        public int SingleNumber(int[] nums)
        {
            var v = nums.GroupBy(x => x)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .Where(a => a.Count == 1)
                .FirstOrDefault();
            return v?.Name ?? throw new KeyNotFoundException("not found");
        }


        //Plus One
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/559/
        public int[] PlusOne(int[] digits)
        {
            int addInt = 1;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                addInt += digits[i];
                digits[i] = addInt % 10;
                addInt /= 10;
            }
            if (addInt == 0) return digits;
            int[] res = new int[digits.Length + 1];
            res[0] = addInt;
            digits.CopyTo(res, 1);
            return res;
        }

        //First Unique Character in a String
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/881/
        public int FirstUniqChar(string s)
        {
            char[] chars = s.ToCharArray();

            Dictionary<char, int> dict = new();
            for (int i = 0; i < chars.Length; i++)
                dict[chars[i]] = i;

            var v = chars.GroupBy(x => x)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .Where(a => a.Count == 1)
                .FirstOrDefault();
            if (v == null) return -1;
            return dict.GetValueOrDefault(v.Name);
        }



        //Valid Palindrome
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/127/strings/883/

        public bool IsPalindrome(string s)
        {
            if (s == null) return true;

            s = new string(s.ToLower().Where(c => char.IsLetterOrDigit(c)).ToArray());
            string ss = new string(s.ToCharArray().Reverse().ToArray());
            return s == ss;
        }


        //Pascal's Triangle
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/99/others/601/
        public IList<IList<int>> Generate(int numRows)
        {
            int[][] pascalTriangle = new int[numRows][];
            for (int r = 0; r < numRows; r++)
            {
                pascalTriangle[r] = new int[r + 1];
                for (int i = 0; i <= r; i++)
                {
                    if (i == 0 || i == r)
                        pascalTriangle[r][i] = 1;
                    else
                        pascalTriangle[r][i] = pascalTriangle[r - 1][i - 1] + pascalTriangle[r - 1][i];
                }
            }
            return pascalTriangle;
        }


        //Valid Parentheses
        //https://leetcode.com/explore/interview/card/top-interview-questions-easy/99/others/721/

        public bool IsValid(string s)
        {
            char ch;
            if (s == null) return true;
            s = s.Replace(" ", "");
            if (s.Length == 0) return true;

            var bracketsStack = new Stack<char>(s.Length / 2);
            char[] chars = s.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case '{':
                    case '(':
                    case '[':
                        bracketsStack.Push(chars[i]);
                        break;
                    case '}':
                        if (bracketsStack.Count == 0) return false;
                        ch = bracketsStack.Pop();
                        if (ch != '{') return false;
                        break;
                    case ')':
                        if (bracketsStack.Count == 0) return false;
                        ch = bracketsStack.Pop();
                        if (ch != '(') return false;
                        break;
                    case ']':
                        if (bracketsStack.Count == 0) return false;
                        ch = bracketsStack.Pop();
                        if (ch != '[') return false;
                        break;

                    default:
                        return false;
                }
            }
            return bracketsStack.Count == 0;
        }


        //Integer to Roman
        //https://leetcode.com/problems/integer-to-roman/
        public string IntToRoman(int num)
        {
            int k = 0;
            string res = "";
            k = num / 1000;
            if (k > 0)
            {
                num -= k * 1000;
                res += new string('M', k);
            }

            k = num / 100;
            if (k > 0)
            {
                num -= k * 100;
                res += k switch
                {
                    1 => "C",
                    2 => "CC",
                    3 => "CCC",
                    4 => "CD",
                    5 => "D",
                    6 => "DC",
                    7 => "DCC",
                    8 => "DCCC",
                    9 => "CM",
                    _ => throw new NotImplementedException()
                };
            }

            k = num / 10;
            if (k > 0)
            {
                num -= k * 10;
                res += k switch
                {
                    1 => "X",
                    2 => "XX",
                    3 => "XXX",
                    4 => "XL",
                    5 => "L",
                    6 => "LX",
                    7 => "LXX",
                    8 => "LXXX",
                    9 => "XC",
                    _ => throw new NotImplementedException()
                };
            }

            k = num;
            if (k > 0)
            {
                res += k switch
                {
                    1 => "I",
                    2 => "II",
                    3 => "III",
                    4 => "IV",
                    5 => "V",
                    6 => "VI",
                    7 => "VII",
                    8 => "VIII",
                    9 => "IX",
                    _ => throw new NotImplementedException()
                };
            }
            return res;
        }

        //Roman to Integer
        //https://leetcode.com/problems/roman-to-integer/
        public int RomanToInt(string s)
        {
            if (s == null || s.Length == 0) return 0;

            int res = 0;
            char[] chars = s.ToUpper().ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case 'M':
                        res += 1000;
                        break;
                    case 'D':
                        res += 500;
                        break;
                    case 'L':
                        res += 50;
                        break;
                    case 'V':
                        res += 5;
                        break;

                    case 'C':
                        if (i + 1 < chars.Length)
                        {
                            switch (chars[i + 1])
                            {
                                case 'M':
                                    res += 900;
                                    i++;
                                    break;
                                case 'D':
                                    res += 400;
                                    i++;
                                    break;
                                default:
                                    res += 100;
                                    break;
                            }
                        }
                        else
                            res += 100;
                        break;

                    case 'X':
                        if (i + 1 < chars.Length)
                        {
                            switch (chars[i + 1])
                            {
                                case 'C':
                                    res += 90;
                                    i++;
                                    break;
                                case 'L':
                                    res += 40;
                                    i++;
                                    break;
                                default:
                                    res += 10;
                                    break;
                            }
                        }
                        else
                            res += 10;
                        break;

                    case 'I':
                        if (i + 1 < chars.Length)
                        {
                            switch (chars[i + 1])
                            {
                                case 'X':
                                    res += 9;
                                    i++;
                                    break;
                                case 'V':
                                    res += 4;
                                    i++;
                                    break;
                                default:
                                    res += 1;
                                    break;
                            }
                        }
                        else
                            res += 1;
                        break;

                    default:
                        break;
                }
            }
            return res;
        }

        //Powerful Integers
        //https://leetcode.com/problems/powerful-integers/
        public IList<int> PowerfulIntegers(int x, int y, int bound)
        {   //check time
            Dictionary<int, int> result = new();

            int xx = 1;
            while (xx <= bound - 1)
            {
                int yy = 1;
                while (yy <= bound - xx)
                {
                    int zz = xx + yy;
                    if (!result.ContainsKey(zz))
                        result.Add(zz, yy);
                    yy *= y;
                }
                xx *= x;
            }

            return result.Keys.ToArray();
        }

        //K Closest Points to Origin
        //https://leetcode.com/problems/k-closest-points-to-origin/

        public int[][] KClosest(int[][] points, int k)
        {
            if (k == points.Length) return points;
            k = Math.Min(points.Length, k);

            return Enumerable.Range(0, points.Length)
                .Select(r => new
                {
                    row = r,
                    x = points[r][0],
                    y = points[r][1],
                    distSqr = Math.Pow(points[r][0], 2) + Math.Pow(points[r][1], 2)
                })
                .OrderBy(v => v.distSqr)
                .Take(k)
                .Select(data => new[] { data.x, data.y })
                .ToArray();
        }


        //Top K Frequent Words
        //https://leetcode.com/problems/top-k-frequent-words/
        public IList<string> TopKFrequent(string[] words, int k)
        {
            return words
                .GroupBy(w => w)
                .Select(g => new { Name = g.Key, Count = g.Count() })
                .OrderByDescending(w => w.Count)
                .ThenBy(w => w.Name)
                .Take(k)
                .Select(z => z.Name)
                .ToList();
        }

    }
}



