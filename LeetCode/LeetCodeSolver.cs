using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Linq;

namespace LeetCodeSolver
{
    public class TripleInt : IEquatable<TripleInt>
    {
        private readonly int[] arr;
        public int this[int i] => arr[i];
        public int Length => arr.Length;

        public TripleInt(params int[] arr)
        {
            this.arr = arr;
            Array.Sort(this.arr);
        }


        public bool Equals(TripleInt? other)
        {
            if (other == null) return false;
            if (this.Length != other.Length) return false;

            for (int i = 0; i < this.Length; i++)
                if (this[i] != other[i]) return false;
            return true;
        }

        public IList<int> ToList() => arr.ToList();
        public int[] ToArray() => arr.ToArray();
    }


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

        //Max Area of Island
        //https://leetcode.com/problems/max-area-of-island/
        public int MaxAreaOfIsland(int[][] grid)
        {
            int maxArea = int.MinValue;
            bool[][] visited = new bool[grid.Length][];
            for (int i = 0; i < grid.Length; i++)
                visited[i] = new bool[grid[i].Length];

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                    maxArea = Math.Max(maxArea, CalcVisited(i, j, grid, visited));
            return maxArea;
        }

        private int CalcVisited(int i, int j, int[][] grid, bool[][] visited)
        {
            if (i < 0 || j < 0) return 0;
            if (i >= grid.Length || j >= grid[0].Length) return 0;
            if (visited[i][j] || grid[i][j] == 0) return 0;

            visited[i][j] = true;
            int z = 1
                + CalcVisited(i - 1, j, grid, visited)
                + CalcVisited(i + 1, j, grid, visited)
                + CalcVisited(i, j - 1, grid, visited)
                + CalcVisited(i, j + 1, grid, visited);
            return z;
        }

        //https://leetcode.com/problems/adding-spaces-to-a-string/
        //2109. Adding Spaces to a String

        public string AddSpaces(string s, int[] spaces)
        {
            string sPart;
            StringBuilder sb = new();
            for (int i = 0; i < spaces.Length; i++)
            {
                if (i == 0)
                {
                    sPart = s[..spaces[0]];
                    sb.Append(sPart);
                }
                else
                {
                    sPart = s[(spaces[i - 1])..(spaces[i])];
                    sb.Append(sPart);
                }
                sb.Append(' ');
            }
            sPart = s[spaces[^1]..];
            sb.Append(sPart);

            return sb.ToString();
        }




        //Merge Sorted Array
        //https://leetcode.com/explore/learn/card/fun-with-arrays/525/inserting-items-into-an-array/3253/
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int[] res = new int[m + n];
            if (m > 0) nums1[..m].CopyTo(res, 0);
            if (n > 0) nums2[..n].CopyTo(res, m);
            Array.Sort(res);
            Array.Resize(ref nums1, res.Length);
            res.CopyTo(nums1, 0);
        }


        //15. 3Sum
        //https://leetcode.com/problems/3sum/
        public IList<IList<int>> ThreeSum(int[] nums)
        //Time Limit Exceeded
        {
            List<TripleInt> tripleInts = new();
            for (int i = 0; i < nums.Length; i++)
                for (int j = 0; j < nums.Length; j++)
                    for (int k = 0; k < nums.Length; k++)
                        if (i != j && i != k && j != k && nums[i] + nums[j] + nums[k] == 0)
                        {
                            var trpl = new TripleInt(nums[i], nums[j], nums[k]);
                            if (!tripleInts.Contains(trpl))
                                tripleInts.Add(trpl);
                        }
            return tripleInts.Select(t => t.ToList()).ToList();
        }

        //Game Play Analysis I
        //https://leetcode.com/problems/game-play-analysis-i/
        /*
         select player_id , min(event_date) as first_login 
        from Activity
        group by player_id
        order by 1
         */


        //2165. Smallest Value of the Rearranged Number
        //https://leetcode.com/problems/smallest-value-of-the-rearranged-number/
        public long SmallestNumber(long num)
        {
            if (num == 0) return 0;
            char[] chars = Math.Abs(num).ToString().ToCharArray();
            if (num < 0)
                return (-1) * long.Parse(chars.OrderByDescending(c => c).ToArray());
            else
            {
                int ZeroCount = 0;
                StringBuilder sb = new StringBuilder();

                Array.Sort(chars);
                for (int i = 0; i < chars.Length; i++)
                {
                    if (chars[i] == '0')
                    {
                        ZeroCount++;
                        continue;
                    }
                    else
                    {
                        sb.Append(chars[i]);
                        if (ZeroCount > 0)
                        {
                            sb.Append(new string('0', ZeroCount));
                            ZeroCount = 0;
                        }
                    }
                }
                return long.Parse(sb.ToString());
            }
        }


        //2167. Minimum Time to Remove All Cars Containing Illegal Goods
        //https://leetcode.com/problems/minimum-time-to-remove-all-cars-containing-illegal-goods/
        public int MinimumTime(string s)
        //"010110" Wrong Answer output 6  expected 5 why
        {
            if (s == null) return 0;
            if (!s.Contains('0')) return s.Length;
            if (!s.Contains('1')) return 0;

            int zeroFirst = s.IndexOf('0');
            int zeroLast = s.LastIndexOf('0');

            if (zeroFirst == zeroLast) return s.Length - 1;

            return (zeroFirst) + (s.Length - zeroLast - 1) + 2 * s[zeroFirst..zeroLast].Where(c => c == '1').Count();
        }



        //1796. Second Largest Digit in a String
        //https://leetcode.com/problems/second-largest-digit-in-a-string/
        public int SecondHighest(string s)
        {
            char[] data = s.Where(c => char.IsDigit(c)).Distinct().OrderByDescending(c => c).Take(2).ToArray();
            if (data.Length != 2) return -1;
            return int.Parse(data[1].ToString());
        }


        //388. Longest Absolute File Path
        //https://leetcode.com/problems/longest-absolute-file-path/
        public int LengthLongestPath(string input)
        {
            if (input == null || input == string.Empty || !input.Contains('.')) return 0;

            string[] lines = input.Split('\n');
            string[] paths = new string[lines.Length];

            return 0;
        }


        //        NumberOfDiscIntersections
        //https://app.codility.com/programmers/task/number_of_disc_intersections/

        public int solution0(int[] A)
        {
            var data = A.Select((r, index) => new { radius = (long)r, pos = (long)index });
            var res =
                from a in data
                from b in data
                where a.pos < b.pos && a.pos + a.radius >= b.pos - b.radius
                select new { a, b };

            long z = res.Count();
            if (z > 10000000) return -1;
            return (int)z;
        }

        public int solution1(int[] A)
        {
            long[] B = new long[A.Length];
            A.CopyTo(B, 0);

            long[] startPos = B.Select((a, i) => (long)i - a).ToArray();
            long[] endPos = B.Select((a, i) => (long)i + a).ToArray();

            int z = 0;
            for (long i = 0; i < B.Length; i++)
                for (long j = i + 1; j < B.Length; j++)
                    if (endPos[i] >= startPos[j])
                    {
                        z++;
                        if (z > 10000000) return -1;
                    }
            return z;
        }

        public int solution(int[] A)
        {
            long[] B = new long[A.Length];
            A.CopyTo(B, 0);

            int[] startPosArray = new int[B.Length];
            int[] endPosArray = new int[B.Length];

            long maxPos = B.Length - 1;
            for (long i = 0; i < B.Length; i++)
            {
                long startPos = 0;
                if (B[i] < i) startPos = i - B[i];

                long endPos = maxPos;
                if (i + B[i] < maxPos) endPos = i + B[i];

                startPosArray[startPos]++;
                endPosArray[endPos]++;
            }

            int sumOfIntersections = 0;
            int activeRingsCounter = 0;
            for (int i = 0; i < B.Length; i++)
            {
                if (startPosArray[i] > 0)
                {
                    sumOfIntersections += startPosArray[i] * activeRingsCounter + startPosArray[i] * (startPosArray[i] - 1) / 2;
                    activeRingsCounter += startPosArray[i];
                }
                if (sumOfIntersections > 10000000) return -1;
                activeRingsCounter -= endPosArray[i];
            }
            return sumOfIntersections;
        }

        //Valid Sudoku
        //https://leetcode.com/problems/valid-sudoku/
        public bool IsValidSudoku(char[][] board)
        {
            if (board == null) return false;
            if (board.Length != 9) return false;
            for (int i = 0; i < board.Length; i++)
                if (board[i].Length != 9) return false;

            for (int i = 0; i < 9; i++)
                if (!IsValidSudokuLine(string.Join("", board[i])))
                    return false;

            StringBuilder sb = new();
            for (int i = 0; i < 9; i++)
            {
                sb.Clear();
                for (int j = 0; j < 9; j++)
                    sb.Append(board[i][j]);
                if (!IsValidSudokuLine(sb.ToString()))
                    return false;
            }
            for (int k = 0; k < 9; k++)
            {
                sb.Clear();
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        sb.Append(board[3 * (k / 3) + i][3 * (k % 3) + j]);
                if (!IsValidSudokuLine(sb.ToString()))
                    return false;
            }
            return true;
        }

        public static bool IsValidSudokuLine(string sLine)
        {
            if (sLine == null) return false;
            if (sLine.Length != 9) return false;

            char[] chars = sLine.Replace(".", "").ToCharArray();
            Array.Sort(chars);
            for (int i = 1; i < chars.Length; i++)
                if (chars[i - 1] == chars[i]) return false;
            return true;
        }



        //Sudoku Solver
        //https://leetcode.com/problems/sudoku-solver/
        public void SolveSudoku(char[][] board)
        {
            if (!IsValidSudoku(board)) throw new ArgumentException("!IsValidSudoku");




        }


    }
    //https://leetcode.com/problems/trips-and-users/
    //https://leetcode.com/problems/merge-intervals/
    //https://leetcode.com/problems/find-bottom-left-tree-value/
}






