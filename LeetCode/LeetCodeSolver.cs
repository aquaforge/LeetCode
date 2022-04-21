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

        }
    }


}


}
