class Program
{
    static void Main()
    {
        //Nの値の入力
        int.TryParse(Console.ReadLine(), out int N);

        //時刻 t に 点 (x,y)の二次配列である旅行プランの初期化
        int[,] timePlace = InputDataInArray(N);

        //入力値は制約が合わない場合のメッセージ
        bool checkData = ValidationInputedData(timePlace, N);
        if (!checkData)
        {
            Console.WriteLine("入力値が不正です");
            return;
        }

        bool isPossible = CanMove(timePlace , N);
        string result;

        //旅行プランが実行可能かどうか判定した後の結果を出力する
        if (isPossible)
            result = "YES";
        else
            result = "NO";

        Console.WriteLine(result);
    }

    /// <summary>
    /// 旅行プランに値を入力する
    /// </summary>
    /// <param name="timePlace"></param>
    /// <param name="N"></param>
    static int[,] InputDataInArray(int N)
    {
        int[,] timePlace = new int[N,3];

        for (int i = 0; i < N; i++)
        {
            string[] input = Console.ReadLine().Split(' ');
            int.TryParse(input[0], out timePlace[i,0]);
            int.TryParse(input[1], out timePlace[i,1]);
            int.TryParse(input[2], out timePlace[i,2]);
        }
        return timePlace;
    }

    /// <summary>
    /// 旅行プランが実行可能かどうか判定する
    /// </summary>
    /// <param name="timePlace"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    static bool CanMove(int[,] timePlace , int N)
    {

        //現在の時刻と点の値は 0 を初期化する
        int tCurrent = 0;
        int xCurrent = 0;
        int yCurrent = 0;

        for (int i = 0; i < N; i++)
        {
            int tTarget = timePlace [i, 0]; 
            int xTarget = timePlace [i, 1];
            int yTarget = timePlace [i, 2];

            //現在地から目的地までの距離を計算する
            int distance = Math.Abs(xTarget - xCurrent) + Math.Abs(yTarget - yCurrent);

            //距離を比較して、現在地から目的地まで実行可能を判断する
            if (tTarget >= tCurrent + distance && (tTarget - (tCurrent + distance)) % 2 == 0)
            {
                //現在の時刻と点を更新する
                xCurrent = xTarget;
                yCurrent = yTarget;
                tCurrent = tTarget;
            }
            else
                return false;
        }
        return true;
    }

    /// <summary>
    /// 入力値の制約をチェックする
    /// </summary>
    /// <param name="timePlace"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    static bool ValidationInputedData(int[,] timePlace, int N)
    {
        //Nの入力値の条件のチェック
        if (N < 1 || N > 100000)
            return false;

        for (int i = 1; i < N; i++)
        {
            int t = timePlace[i, 0];
            int x = timePlace[i, 1];
            int y = timePlace[i, 2];

            // t、x、yの入力値の条件のチェック
            if (x < 0 || x > 100000 || y < 0 || y > 100000 || t < 1 || t > 100000)
                return false;

            // tの増加条件のチェック
            if (t <= timePlace[i - 1,0])
                return false;
        }
        return true;
    }
}