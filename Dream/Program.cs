class Program
{
    static void Main()
    {
        //Sの値の入力
        string S = Console.ReadLine();

        //入力値は制約が合わない場合のメッセージ
        bool checkData = ValidationInputedData(S);
        if (!checkData)
        {
            Console.WriteLine("入力値が不正です");
            return;
        }

        bool matched = CanSMatchT(S);
        string result;

        if (matched)
        { 
            //S=T とすることができる場合 YES を出力する
            result = "YES";
        }
        else
        {
            //S=T とすることができない場合 NO を出力する 
            result = "NO";
        }
        Console.WriteLine(result);
    }

    /// <summary>
    /// Sの文字列を確認して、S=Tとすることができるか判定する
    /// </summary>
    /// <param name="S"></param>
    /// <returns></returns>
    static bool CanSMatchT(string S)
    {
        //Tの末尾に追加できる文字列リスト
        string[] words = { "dream", "dreamer", "erase", "eraser" };
        int n = S.Length;

        while (n > 0)
        {
            bool matched = false;

            //Wordの単語を参照して、S の先頭と一致するかどうかを確認する
            foreach (var word in words)
            {
                if (n >= word.Length)
                {
                    //S の末尾を探す
                    string str = S.Substring(n - word.Length, word.Length);

                    //S の先頭と一致する場合、S の末尾と一致するかどうかを確認する
                    if (str == word)
                    {
                        n -= word.Length;
                        matched = true;
                        break;
                    }
                }
            }
            //一致しない場合、偽を返す
            if (!matched) return false;
        }
        return true;
    }

    /// <summary>
    /// 入力値の制約をチェックする
    /// </summary>
    /// <param name="S"></param>
    /// <returns></returns>
    static bool ValidationInputedData(string S)
    {
        int n = S.Length;

        if (n < 1 || n > 100000)
            return false;
        foreach (char c in S)
        {
            // S は英小文字からなるかどうか確認する
            if (!Char.IsLower(c))
            {
                return false;  
            }
        }
        return true;
    }
}