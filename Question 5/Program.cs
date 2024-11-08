class Program
{
    static void Main(string[] args)
    {
        //整数の入力
        int.TryParse(Console.ReadLine(), out int inputA);
        int.TryParse(Console.ReadLine(), out int inputB);
        int.TryParse(Console.ReadLine(), out int inputC);
        int totalX = int.Parse(Console.ReadLine());

        //入力値は制約が合わない場合のメッセージ
        bool dataValid = ValidationInputedData(inputA, inputB, inputC, totalX);
        if (!dataValid)
        {
            Console.WriteLine("入力値が不正です");
            return;
        }

        //合計金額をちょうどX円にする方法は何通り
        int count = CountWaysForTotalEqualToX(inputA, inputB, inputC, totalX);
        Console.WriteLine(count);
    }

    static int CountWaysForTotalEqualToX(int A, int B, int C, int X)
    {
        int count = 0;

        //すべての組み合わせを参照する
        for (int i = 0; i <= A; i++)
        {
            for (int j = 0; j <= B; j++)
            {
                for (int k = 0; k <= C; k++)
                {
                    //硬貨から合計する
                    int total = i * 500 + j * 100 + k * 50;
                    if (total == X)
                    {
                        //合計金額をちょうどX円にする場合、１通りを追加する
                        count++;
                    }
                }
            }
        }
        return count;
    }

    static bool ValidationInputedData(int A, int B, int C, int X)
    {
        int[] pieceList = { A, B, C };

        //入力値の制約をチェックする
        if (pieceList.Any(n => n < 0 || n > 50) || A + B + C < 1)
            return false;
        if (X < 50 || X > 20000 || X % 50 != 0)
            return false;

        return true;
    }
}