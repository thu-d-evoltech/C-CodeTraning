class Program
{
    static void Main()
    {
        //値の入力
        string[] input = Console.ReadLine().Split(' ');
        int.TryParse(input[0], out int N);
        int Y = int.Parse(input[1]);

        //使える数枚を数える
        int cnt1Man;
        int cnt5Sen;
        int cnt1Sen;

        //入力値は制約が合わない場合のメッセージ
        bool checkData = ValidationInputedData(N, Y);
        if (!checkData)
        {
            Console.WriteLine("入力値が不正です");
            return;
        }

        bool found = FindValidCombination(N, Y, out cnt1Man, out cnt5Sen, out cnt1Sen);
        string result;
        if (found)
        {
            //N 枚のお札の合計金額が Y 円となる組み合わせを返す
            result = $"[{cnt1Man} {cnt5Sen} {cnt1Sen}]";
        }
        else
        {
            //N 枚のお札の合計金額が Y 円とならない場合、-1を返す
            result = $"[{cnt1Man} {cnt5Sen} {cnt1Sen}]";
        }
        Console.WriteLine(result);
    }

    /// <summary>
    /// N 枚のお札の合計金額が Y 円となる組み合わせを探す
    /// </summary>
    /// <param name="N"></param>
    /// <param name="Y"></param>
    /// <param name="cnt1Man"></param>
    /// <param name="cnt5Sen"></param>
    /// <param name="cnt1Sen"></param>
    /// <returns></returns>
    static bool FindValidCombination(int N, int Y, out int cnt1Man, out int cnt5Sen, out int cnt1Sen)
    {
        for (cnt1Man = 0; cnt1Man <= N; cnt1Man++)
        {
            for (cnt5Sen = 0; cnt5Sen <= N - cnt1Man; cnt5Sen++)
            {
                cnt1Sen = N - cnt1Man - cnt5Sen;
                int sum = cnt1Man * 10000 + cnt5Sen * 5000 + cnt1Sen * 1000;

                // N 枚のお札の合計金額が Y 円となる場合、真を返す
                if (sum == Y)
                {
                    return true;
                }
            }
        }
        cnt1Man = -1;
        cnt5Sen = -1;
        cnt1Sen = -1;
        return false;
    }

    /// <summary>
    /// 入力値の制約をチェックする
    /// </summary>
    /// <param name="N"></param>
    /// <param name="Y"></param>
    /// <returns></returns>
    static bool ValidationInputedData(int N, int Y)
    {
        if (N < 1 || N > 2000)
            return false;
        if (Y < 1000 || Y > 20000000 || Y % 1000 != 0)
            return false;

        return true;
    }
}