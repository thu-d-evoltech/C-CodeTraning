class Program
{
    static void Main(string[] args)
    {
        List<int> mochiList = CreateMochiDiameterList();

        //配列の制約と合わない場合のメッセージ
        if (!mochiList.Any())
        {
            Console.WriteLine("入力値が不正です");
            return;
        }

        //鏡餅の最大の段数の出力
        int mochiLayers = MochiLayerCount(mochiList);
        Console.WriteLine("鏡餅の最大の段数: " + mochiLayers);
    }

    /// <summary>
    /// 餅の直径のリストを初期化する
    /// </summary>
    /// <returns></returns>
    static List<int> CreateMochiDiameterList()
    {
        List<int> mochiList = new List<int>();

        //配列の要素数の入力
        int.TryParse(Console.ReadLine(), out int arrayLength);

        // 要素数の制約のチェック
        if (arrayLength < 1 || arrayLength > 100)
            return mochiList;

        for (int i = 0; i < arrayLength; i++)
        {
            //値の入力
            string mochi = Console.ReadLine();

            //変数型を変換し、配列に値を代入する
            if (int.TryParse(mochi, out int values))
                mochiList.Add(values);
            else
                return mochiList;
        }
        return mochiList;
    }

    /// <summary>
    /// 最大で鏡餅を作ることができる段重ね数を数える
    /// </summary>
    /// <param name="mochiList"></param>
    /// <returns></returns>
    static int MochiLayerCount(List<int> mochiList)
    {
        //HashSetを使用して重複値を削除する
        HashSet<int> uniqueValues = new HashSet<int>(mochiList);

        //配列の一意値の数を数える
        int count = uniqueValues.Count;
        return count;
    }
}
