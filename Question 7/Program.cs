class Program
{
    static void Main(string[] args)
    {
        List<int> cardList = CreateCardList();

        //配列の制約と合わない場合のメッセージ
        if (!cardList.Any())
        {
            Console.WriteLine("入力値が不正です");
            return;
        }

        //得点差の出力
        int scoreDiff = CalculateScoreDifference(cardList);
        Console.WriteLine(scoreDiff);
    }

    /// <summary>
    /// カードリストを初期化する
    /// </summary>
    /// <returns></returns>
    static List<int> CreateCardList()
    {
        var cardList = new List<int>();

        //配列の要素数の入力
        int.TryParse(Console.ReadLine(), out int listLength);

        // 要素数の制約のチェック
        if (listLength < 1 || listLength > 100)
            return cardList;

        //値の入力
        string[] card = Console.ReadLine().Split(' ');

        // 配列の要素数と入力値の比較
        if (card.Length != listLength)
            return cardList;

        //配列に値を代入する 
        foreach (var item in card)
        {
            if (int.TryParse(item, out int cardNum))
                cardList.Add(cardNum);
            else
                return cardList;
        }
        return cardList;
    }

    /// <summary>
    /// プレイヤーのカード引き
    /// </summary>
    /// <param name="cardList"></param>
    /// <returns></returns>
    static int PlayerDrawCard(List<int> cardList)
    {
        int card = cardList.Max();
        cardList.Remove(card);
        return card;
    }

    /// <summary>
    /// AliceとBobの得点差を計算する
    /// </summary>
    /// <param name="cardList"></param>
    /// <returns></returns>
    static int CalculateScoreDifference(List<int> cardList)
    {
        int aliceScore = 0;
        int bobScore = 0;
        int scoreDiff;

        while (cardList.Count > 0)
        {
            //Aliceの得点を計算する
            aliceScore += PlayerDrawCard(cardList);

            //カードがなくなったら、引くのをやめる
            if (cardList.Count == 0) break;

            //Bobの得点を計算する
            bobScore += PlayerDrawCard(cardList);
        }
        //得点差を計算する
        scoreDiff = aliceScore - bobScore;
        return scoreDiff;
    }
}