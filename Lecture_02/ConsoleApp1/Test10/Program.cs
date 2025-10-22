namespace Test10
{
    internal class Program
    {
        // 유저의 숫자 입력을 받아오고 이것을 오름차순으로 정렬시키는 알고리즘을 직접 구현하세요.

        public static List<int> SortList(List<int> numList)
        {
            for(int i=0; i<numList.Count; i++)
            {
                for(int j=i; j<numList.Count; j++)
                {
                    // 앞으로 나올 번호가 이전보다 작다면 변경
                    if (numList[j] < numList[i])
                    {
                        int temp = numList[i];
                        numList[i] = numList[j];
                        numList[j] = temp;
                    }
                }
            }

            return numList;
        }


        static void Main(string[] args)
        {
            List<int> numList = new List<int>();

            while(true)
            {
                Console.WriteLine("숫자를 입력하세요. 0이면 종료");

                string input = Console.ReadLine();

                if(int.TryParse(input, out int num))
                {
                    if (num == 0) break;

                    numList.Add(num);
                    numList = SortList(numList);

                    Console.WriteLine("정렬된 값");
                    foreach(int i in numList)
                    {
                        Console.Write($"{i} ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("잘못 입력하였습니다.");
                }
            }
        }
    }
}
