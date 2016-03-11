public class ConfigData
{
    //CSVファイルの絶対パス
    const string config_path = "C:\\Users\\s1534\\Desktop\\config.csv";

    //CSVファイルの全体のデータ
    public Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();

    //マップデータのリスト
    //すべてのエリアの情報を格納
    public List<MapData> m;

    //エリアの数
    //CSVファイルで定義しておく
    int area_num;

    /// <summary>
    /// CSVファイルを読み込み，FittingMapによりマップデータを作成
    /// </summary>
    public void Load()
    {
        try
        {
            using (var sr = new System.IO.StreamReader(@config_path))
            {
                // ストリームの末尾まで繰り返す
                while (!sr.EndOfStream)
                {
                    // ファイルから一行読み込む
                    var line = sr.ReadLine();
                    DataSet(line);
                    //System.Console.WriteLine(line);
                }
            }
        }
        catch (System.Exception e)
        {
            // ファイルを開くのに失敗したとき
            System.Console.WriteLine(e.Message);
        }

        FittingMap(dict, area_num);
    }


    /// <summary>
    /// CSVから読み込んだ1行をひとつひとつハッシュマップに加える
    /// </summary>
    /// <param name="line"></param>
    private void DataSet(string line)
    {
        //一時データ
        //一行の内容を格納
        List<string> tmp_data = new List<string>();

        ///カンマにて分離
        ///要素が一つの場合，データがないとみなされる
        ///一つ目の要素が # ならばコメント
        ///               ! ならばマップのエリア数（とりあえず）
        var elements = line.Split(',');
        if (elements.Length == 1) return;
        if (elements[0] == "#")
        {
            return;
        }
        else if (elements[0] == "!")
        {
            area_num = int.Parse(elements[1]);
            return;
        }

        ///配列を動的配列にすることで，先頭要素の削除を可能に
        tmp_data = elements.ToList();
        tmp_data.RemoveAt(0);

        ///データの格納
        dict.Add(elements[0], tmp_data);
    }

    /// <summary>
    /// CSVのデータからマップデータを作成する
    /// </summary>
    /// <param name="data"></param>
    /// <param name="num"></param>
    public void FittingMap(Dictionary<string, List<string>> data, int num)
    {
        //CSVデータからマップの部分のみ切り取り
        Dictionary<string, List<string>> tmp_data = data.Take(num).ToDictionary(k => k.Key, k => k.Value);

        //マップデータの作成
        foreach (var v in tmp_data)
        {
            m.Add(new MapData(
                    v.Key,
                    int.Parse(v.Value[0]),
                    data[v.Value[1]].ToArray(),
                    new Size(int.Parse(v.Value[2]), int.Parse(v.Value[3]))
                    )
                 );
        }
    }
}

/// <summary>
/// ひとつひとつのマップのデータをまとめたもの
/// エリアの名前，部屋数，部屋のタイプ，大きさを格納
/// </summary>
public struct MapData
{
    public string name { get; }
    public int stages_count { get; }
    public string[] stages_type { get; }
    public Size size { get; }

    public MapData(string _name, int _n, string[] _types, Size _s)
    {
        name = _name;
        stages_count = _n;
        stages_type = _types;
        size = _s;
    }
}
