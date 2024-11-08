class Program
{
    static void Main()
    {
        //整数の入力
        int a = int.Parse(Console.ReadLine());

        // スペース区切りの整数の入力
        string[] input = Console.ReadLine().Split(' ');
        int b = int.Parse(input[0]);
        int c = int.Parse(input[1]);

        //文字列の入力
        string s = Console.ReadLine();

        // a,b,cを含める配列の作成
        int[] numbers = { a, b, c };

        //整数の制約のチェック
        if (numbers.All(n => 1 <= n && n <= 1000))
        {
            //条件が合う場合の出力
            Console.WriteLine((a + b + c) + " " + s);
        }
        else
        {
            //条件が合わない場合の出力
            Console.WriteLine("整数入力値が不正です");
        }
    }
}