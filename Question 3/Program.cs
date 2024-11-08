class Program
{
    static void Main()
    {

        Console.WriteLine("0 または 1 を入力してください。");

        // 値を入力する
        char[] values = ReadBinaryValue();
        Console.WriteLine();

        // 桁数１を返す
        int count = CountOnes(values);
        Console.WriteLine(count);
    }

    //配列の要素をチェックするメソッド
    static char[] ReadBinaryValue()
    {
        char[] values = new char[3];

        for (int i = 0; i < 3; i++)
        {
            while (true)
            {
                //キーボードの上で押したキーを画面に表示せずに、文字を読み取ります変数
                char keyPressed = Console.ReadKey(intercept: true).KeyChar;

                if (keyPressed == '0' || keyPressed == '1')
                {
                    //押したキーは 0 または１の場合、その文字を表示する
                    values[i] = keyPressed;
                    Console.Write(keyPressed);
                    break;
                }
            }
        }
        return values;
    }

    //配列の桁数１をカウントする
    static int CountOnes(char[] values)
    {
        int count = 0;
        foreach (char c in values)
        {
            if (c == '1')
            {
                count++;
            }
        }
        // 桁数１を返す
        return count;
    }
}