class Program
{
    static void Main(string[] args)
    {
        // スペース区切りの整数の入力
        string[] input = Console.ReadLine().Split(' ');
        int.TryParse(input[0], out int a);
        int.TryParse(input[1], out int b);

        string result = GetResultTextOfProductIsEvenOrOdd(a, b);

        Console.WriteLine(result);
    }

    /// <summary>
    /// //積のパリティのチェック
    /// </summary>
    /// <param name="valueA"></param>
    /// <param name="valueB"></param>
    /// <returns></returns>
    static string GetResultTextOfProductIsEvenOrOdd(int valueA, int valueB)
    {
        int[] num = { valueA, valueB };

        //入力値の制約のチェック
        if (num.Any(n => n < 1 || n > 10000))
            return "整数入力値が不正です";

        //積の評価結果の出力
        if ((valueA * valueB) % 2 == 0)
            return "Even";
        else
            return "Odd";
    }
}