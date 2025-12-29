namespace ConsoleProject.util
{
    // 랭크 데이터 파일 입출력 클래스
    public class RankIO
    {
        class RankData
        {
            //랭크에 보여지는 닉네임과 점수를 가지고 있는 데이터 클래스
            public string Nickname { get; set; } = "";
            public int Score { get; set; }

            public RankData(string nickname, int score)
            {
                Nickname = nickname;
                Score = score;
            }
        }

        private const int MAX_RANK = 5;

        private static string filePath = "AvoidGameRanking.txt";
        private static List<RankData> rankList = new List<RankData>();

        private static void InitRank()
        {
            StreamWriter writer = new StreamWriter(filePath);

            for (int i = 0; i < MAX_RANK; i++)
            {
                writer.WriteLine($"{i + 1}\t___\t0");
            }
            writer.Close();
        }

        public static void ReadRank()
        {
            try
            {
                //파일이 없다면 생성
                if (!File.Exists(filePath))
                {
                    InitRank();
                }

                rankList.Clear();   //리스트 초기화

                //파일에 있는 데이터 한번에 읽어오기
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    string[] data = lines[i].Split('\t');
                    int score = int.Parse(data[2]);
                    RankData rankData = new RankData(data[1], score);
                    rankList.Add(rankData);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("파일 읽기 실패.");
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

        }

        public static void WriteRank(int idx, string nickname, int score)
        {
            RankData data = new RankData(nickname, score);
            rankList.Add(data);

            //점수 내림차순 정렬 리스트
            rankList = rankList.OrderByDescending(data => data.Score).ToList();

            try
            {
                string[] lines = new string[MAX_RANK];

                for (int i = 0; i < MAX_RANK; i++)
                {
                    var v = rankList[i];
                    lines[i] = $"{i + 1}\t{v.Nickname}\t{v.Score}";
                }

                File.WriteAllLines(filePath, lines); // 모든 줄 덮어쓰기
            }
            catch (Exception e)
            {
                Console.WriteLine("파일 쓰기 실패.");
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }
        }

        public static int CheckUpdate(int score)
        {
            //랭크 5위안에 들었는지 확인
            int idx = -1;

            for (int i = 0; i < rankList.Count; i++)
            {
                RankData data = rankList[i];

                if (score > data.Score)
                {
                    idx = i;
                    break;
                }
            }
            return idx;
        }

        public static void PrintRank(int pos1,int pos2)
        {
            for (int i = 0; i < MAX_RANK; i++)
            {
                Console.SetCursorPosition(pos1, pos2 + i*2);
                Console.Write(i + 1 + "\t" + rankList[i].Nickname + "\t" + rankList[i].Score);
            }
        }
    }
}
