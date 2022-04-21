using Microsoft.VisualStudio.TestTools.UnitTesting;
using LeetCodeSolver;

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
            Assert.AreEqual(new LeetCodeSolver().FirstUniqChar(s),target);
        }

        [TestMethod()]
        public void IsPalindromeTest()
        {
            string s = "A man, a plan, a canal: Panama";
            bool target = true;

            Assert.AreEqual(new LeetCodeSolver().IsPalindrome(s), target);
        }

    }
}