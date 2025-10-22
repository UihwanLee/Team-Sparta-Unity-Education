using System.Runtime.Intrinsics.Arm;

namespace Solution_03_Longest_Increasing_Subsequence
{
    internal class Program
    {
        public static int GetMaxLengthSubseqeunce(int[] nums)
        {
            int maxLength = 0;

            // nums와 똑같은 길이의 dp 생성
            int[] dp = new int[nums.Length];

            // dp의 원소를 모두 1로 초기화: 최소 길이 1
            Array.Fill(dp, 1);

            for(int i=0; i<nums.Length; i++)
            {
                // nums를 돌면서 오름차순이 가능한지 체크
                for(int j=0; j<i; j++)
                {
                    // 현재 숫자가 이전 숫자보다 크면 오름차순 가능
                    if (nums[i] > nums[j])
                    {
                        // dp에 현재까지 오름차순 길이를 저장
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }

                // nums를 돌면서 maxLength 값 업데이트
                maxLength = Math.Max(maxLength, dp[i]);
            }

            return maxLength;
        }

        static void Main(string[] args)
        {
            int[] nums = [10, 9, 2, 5, 3, 7, 101, 18];

            int maxLength = GetMaxLengthSubseqeunce(nums);

            Console.WriteLine(maxLength);
        }
    }
}
