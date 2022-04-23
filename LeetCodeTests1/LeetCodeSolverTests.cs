using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCodeSolver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolver.Tests
{
    [TestClass()]
    public class LeetCodeSolverTests
    {
        [TestMethod()]
        public void RemoveDuplicatesTest()
        {
            int[] nums = { 1, 1, 2, 3, 3, 3, 4 }; // Input array
            int[] expectedNums = { 1, 2, 3, 4 }; // The expected answer with correct length

            int k = new LeetCodeSolver().RemoveDuplicates(nums); // Calls your implementation

            Assert.AreEqual(k, expectedNums.Length);
            for (int i = 0; i < k; i++)
                Assert.AreEqual(nums[i], expectedNums[i]);
        }


        [TestMethod()]
        public void RotateTest()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 }; // Input array
            int[] expectedNums = { 5, 6, 7, 1, 2, 3, 4 }; // The expected answer with correct length
            int k = 3;

            new LeetCodeSolver().Rotate(nums, k);

            for (int i = 0; i < nums.Length; i++)
                Assert.AreEqual(nums[i], expectedNums[i]);
        }

        [TestMethod()]
        public void TwoSumTest()
        {
            int[] nums = { 3, 3 }; // Input array
            int[] expectedNums = { 0, 1 }; // The expected answer with correct length
            int target = 6;
            //int[] nums = { 2, 7, 11, 15 }; // Input array
            //int[] expectedNums = { 0, 1 }; // The expected answer with correct length
            //int target = 9;

            nums = new LeetCodeSolver().TwoSum(nums, target);
            for (int i = 0; i < nums.Length; i++)
                Assert.AreEqual(nums[i], expectedNums[i]);
        }

        [TestMethod()]
        public void SingleNumberTest()
        {

            int[] nums = { 3, 3, 1, 2, 2 }; // Input array
            int target = 1;

            Assert.AreEqual(new LeetCodeSolver().SingleNumber(nums), target);

        }

        [TestMethod()]
        public void PlusOneTest()
        {
            int[] nums = { 8, 9 }; // Input array
            int[] expectedNums = { 9, 0 }; // The expected answer with correct length
            //int[] nums = { 9, 9 }; // Input array
            //int[] expectedNums = { 1, 0, 0 }; // The expected answer with correct length

            nums = new LeetCodeSolver().PlusOne(nums);

            Assert.AreEqual(nums.Length, expectedNums.Length);
            for (int i = 0; i < nums.Length; i++)
                Assert.AreEqual(nums[i], expectedNums[i]);

        }

        [TestMethod()]
        public void FirstUniqCharTest()
        {
            string s = "aabbc";
            int target = 4;
            Assert.AreEqual(new LeetCodeSolver().FirstUniqChar(s), target);
        }

        [TestMethod()]
        public void IsPalindromeTest()
        {
            string s = "A man, a plan, a canal: Panama";
            bool target = true;

            Assert.AreEqual(new LeetCodeSolver().IsPalindrome(s), target);
        }

        [TestMethod()]
        public void GenerateTest()
        {
            int numRows = 5;
            int[][] expectedNums = {
                new int[]{ 1 },
                new int[] { 1, 1 },
                new int[] { 1, 2, 1 },
                new int[] { 1, 3, 3, 1 },
                new int[] { 1, 4, 6, 4, 1 } };

            int[][] nums = (int[][])new LeetCodeSolver().Generate(numRows);
            Assert.AreEqual(nums.Length, expectedNums.Length);
            for (int r = 0; r < numRows; r++)
            {
                Assert.AreEqual(nums[r].Length, expectedNums[r].Length);
                for (int i = 0; i <= r; i++)
                    Assert.AreEqual(nums[r][i], expectedNums[r][i]);
            }
        }

        [TestMethod()]
        public void IsValidTest()
        {
            string s = "{ (){ } [ ] [ [ ([ ]) ] ] }";
            bool target = true;
            Assert.AreEqual(new LeetCodeSolver().IsValid(s), target);
        }

        [TestMethod()]
        public void IntToRomanTest()
        {
            int k = 1994;
            string target = "MCMXCIV";
            Assert.AreEqual(new LeetCodeSolver().IntToRoman(k), target);
        }

        [TestMethod()]
        public void RomanToIntTest()
        {
            string s = "MCMXCIV";
            int target = 1994;
            Assert.AreEqual(new LeetCodeSolver().RomanToInt(s), target);
        }

        [TestMethod()]
        public void RomanAllTest()
        {
            LeetCodeSolver lc = new();

            for (int i = 0; i < 3000; i++)
            {
                Assert.AreEqual(lc.RomanToInt(lc.IntToRoman(i)), i);
            }

        }

        [TestMethod()]
        public void PowerfulIntegersTest()
        {
            int x = 2, y = 3, bound = 10;
            int[] output = { 2, 3, 4, 5, 7, 9, 10 };
            //int x = 3, y = 5, bound = 15;
            //int[] output = { 2, 4, 6, 8, 10, 14 };

            int[] result = (int[])new LeetCodeSolver().PowerfulIntegers(x, y, bound);

            Assert.AreEqual(result.Length, output.Length);


            Array.Sort(output);
            Array.Sort(result);

            for (int i = 0; i < result.Length; i++)
                Assert.AreEqual(result[i], output[i]);

        }

        [TestMethod()]
        public void KClosestTest()
        {
            int[][] points = { new[] { 3, 3 }, new[] { 5, -1 }, new[] { -2, 4 } };
            int k = 2;
            int[][] expect = { new[] { 3, 3 }, new[] { -2, 4 } };

            int[][] actual = new LeetCodeSolver().KClosest(points, k);

            Assert.AreEqual(expect.Length, actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                bool bFound = false;
                for (int j = 0; j < actual.Length; j++)
                {
                    if (actual[i][0] == expect[j][0] && actual[i][1] == expect[j][1])
                    {
                        bFound = true;
                        break;
                    }
                }
                if (!bFound) Assert.Fail($"Not found {actual[i][0]}_{actual[i][i]}");
            }

        }

        [TestMethod()]
        public void TopKFrequentTest()
        {
            string[] words = { "i", "love", "leetcode", "i", "love", "coding" };
            int k = 2;
            string[] expect = { "i", "love" };
            //string[] words = { "the", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is" };
            //int k = 4;
            //string[] expect = { "the", "is", "sunny", "day" };

            IList<string> z = new LeetCodeSolver().TopKFrequent(words, k);
            string[] actual = new string[z.Count];
            z.CopyTo(actual, 0);

            Assert.AreEqual(expect.Length, actual.Length);

            Array.Sort(actual);
            Array.Sort(expect);
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual(expect[i], actual[i]);

        }

        [TestMethod()]
        public void MaxAreaOfIslandTest()
        {
            //int[][] grid = {
            //    new[]{ 0,0,1,0,0,0,0,1,0,0,0,0,0},
            //    new[]{ 0,0,0,0,0,0,0,1,1,1,0,0,0},
            //    new[]{ 0,1,1,0,1,0,0,0,0,0,0,0,0},
            //    new[]{ 0,1,0,0,1,1,0,0,1,0,1,0,0},
            //    new[]{ 0,1,0,0,1,1,0,0,1,1,1,0,0},
            //    new[]{ 0,0,0,0,0,0,0,0,0,0,1,0,0},
            //    new[]{ 0,0,0,0,0,0,0,1,1,1,0,0,0},
            //    new[]{ 0,0,0,0,0,0,0,1,1,0,0,0,0}};
            //int expected = 6;
            int[][] grid =  {
                new[]{ 1,1,0,0,0},
                new[]{ 1,1,0,0,0},
                new[]{ 0,0,0,1,1},
                new[]{ 0,0,0,1,1} };
            int expected = 4;

            int actual = new LeetCodeSolver().MaxAreaOfIsland(grid);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void AddSpacesTest()
        {
            string input = "LeetcodeHelpsMeLearn";
            int[] spaces = { 8, 13, 15 };
            string expected = "Leetcode Helps Me Learn";

            string actual = new LeetCodeSolver().AddSpaces(input, spaces);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MergeTest()
        {
            int[] nums1 = { 1, 2, 3, 0, 0, 0 };
            int m = 3;
            int[] nums2 = { 2, 5, 6 };
            int n = 3;
            int[] expected = { 1, 2, 2, 3, 5, 6 };

            new LeetCodeSolver().Merge(nums1, m, nums2, n);

            Assert.AreEqual(expected.Length, nums1.Length);
            for (int i = 0; i < expected.Length; i++)
                Assert.AreEqual(expected[i], nums1[i]);


        }

        [TestMethod()]
        public void ThreeSumTest()
        {
            int[] nums = { -1, 0, 1, 2, -1, -4 };
            List<TripleInt> expected = new();
            expected.Add(new TripleInt(-1, -1, 2));
            expected.Add(new TripleInt(-1, 0, 1));

            IList<IList<int>> res = new LeetCodeSolver().ThreeSum(nums);
            List<TripleInt> actual = res.Select(l => new TripleInt(l.ToArray())).ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            foreach (TripleInt item in expected)
                if (!actual.Contains(item))
                    Assert.Fail(String.Join(",", item.ToArray()));
        }
    }
}