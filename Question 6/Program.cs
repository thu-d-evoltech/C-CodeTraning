class Program
{
    static void Main()
    {
        //値の入力
        string[] inputs = Console.ReadLine().Split(' ');
        int.TryParse(inputs[0], out int N);
        int.TryParse(inputs[1], out int A);
        int.TryParse(inputs[2], out int B);

        //入力値は制約が合わない場合のメッセージ
        bool dataValid = ValidationInputedData(N, A, B);
        if (!dataValid)
        {
            Console.WriteLine("入力値が不正です");
            return;
        }

        //要素数は N がある配列の初期化
        List<int> numList = Enumerable.Range(1, N).ToList();

        //条件を満たした総和を出力する
        int sum = CalculateConditionalSum(numList, A, B);
        Console.WriteLine(sum);
    }

    /// <summary>
    /// 入力値の制約をチェックする
    /// </summary>
    /// <param name="N"></param>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    static bool ValidationInputedData(int N, int A, int B)
    {
        int[] ints = { A, B };
        if (ints.Any(n => n < 1 || n > 36) || A > B)
            return false;
        if (N < 1 || N > 10000)
            return false;

        return true;
    }

    /// <summary>
    /// 数値の各桁の和を計算する
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    static int SumOfDigits(int number)
    {
        int sum = 0;
        while (number != 0)
        {
            sum += number % 10;
            number /= 10;
        }
        return sum;
    }

    /// <summary>
    /// 配列から条件を満たした桁の和がある要素の総和を計算する
    /// </summary>
    /// <param name="numList"></param>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    private static int CalculateConditionalSum(List<int> numList, int A, int B)
    {
        int totalSum = 0;
        foreach (int number in numList)
        {
            //配列の要素の桁の和を計算し、変数 digitSum に代入する
            int digitSum = SumOfDigits(number);

            if (digitSum >= A && digitSum <= B)
            {
                //要素の桁の和の要件を満たす場合、その要素を合計に追加する
                totalSum += number;
            }
        }
        return totalSum;
    }
}