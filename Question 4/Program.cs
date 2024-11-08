class Program
{
    static void Main(string[] args)
    {
        List<int> numList = GetInputtedValues();

        //配列の制約と合わない場合のメッセージ
        if (!numList.Any())
        {
            Console.WriteLine("入力値が不正です");
            return;
        }

        //配列の全て要素が偶数の回数を表示する
        int count = CountArrayNotHaveOdd(numList);
        Console.WriteLine(count);
    }

    static List<int> GetInputtedValues()
    {
        var numList = new List<int>();

        //配列の要素数の入力
        int arrayLength = int.Parse(Console.ReadLine());

        // 要素数の制約のチェック
        if (!ValidateItemLength(arrayLength))
            return numList;

        //値の入力
        string[] inputs = Console.ReadLine().Split(' ');

        // 入力値のチェック
        if (ValidateiInputtedNumber(inputs, arrayLength))
            return numList;

        foreach (string item in inputs)
        {
            int num = int.Parse(item);
            numList.Add(num);
        }

        return numList;
    }

    static bool ValidateItemLength(int arrayLength)
    {
        if (arrayLength < 1 || arrayLength > 200)
            return false;

        return true;
    }

    static bool ValidateiInputtedNumber(string[] inputtedString, int inputtedArrayLength)
    {
        //値数と配列の要素数を比較する
        if (inputtedString.Length != inputtedArrayLength)
            return false;

        foreach (string item in inputtedString)
        {
            int num = int.Parse(item);

            //要素の制約のチェック (1 <= numArray[i] <= 10^9)
            if (num < 1 || num > 1000000000)
                return false;
        }

        return true;
    }

    static int CountArrayNotHaveOdd(List<int> numList)
    {
        int count = 0;

        //奇数要素が存在するまで繰り返し
        while (numList.All(x => x % 2 == 0))
        {
            //要素ずつを２で割り、配列に代入する
            for (int i = 0; i < numList.Count; i++)
            {
                numList[i] /= 2;
            }
            count++;
        }
        //ループの回数を返す
        return count;
    }
}