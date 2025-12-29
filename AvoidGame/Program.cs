using ConsoleProject.util;

namespace ConsoleProject
{
    internal class Program
    {
        private const int MAP_SIZE = 100;

        private const int START_X = MAP_SIZE / 2;
        private const int START_Y = MAP_SIZE - 30;

        private const int MAX_ENEMY = 3;

        //플레이어 캐릭터 사이즈
        private const int ROW = 30;
        private const int COL = 29;

        //스카몬 사이즈
        private const int ROW_S = 14;
        private const int COL_S = 16;

        //플레이어가 이동할 수 있는 좌/우 상한선
        private const int LEFT_LIMIT = 10;
        private const int RIGHT_LIMIT = MAP_SIZE - (ROW + 10);

        private DotImageMaker maker;
        private Character player;
        private Character[] enemies;

        private Pixel[,] map;

        private Random random;

        private int avoidCnt = -1;    //땅에 떨어진 스카몬 수. 랭킹에 활용되는 점수

        private string nickname = ""; //랭킹에 사용되는 유저의 닉네임

        private void PrintPixel(char ch, ConsoleColor color)
        {
            Console.BackgroundColor = color;
            Console.Write(ch);
        }

        private void PrintMap()
        {
            Console.SetCursorPosition(0, 0);    //맵을 그릴때마다 커서 이동해서 스크롤 방지
            Console.CursorVisible = false;

            for (int i = 0; i < MAP_SIZE; i++)
            {
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    PrintPixel(map[i, j].Ch, map[i, j].Color);
                }

                Console.WriteLine();
            }

            //플레이어 이동 범위를 알 수 있는 바닥 출력
            for (int i = 0; i < MAP_SIZE; i++)
                PrintPixel(' ', ConsoleColor.Green);

        }

        private void SetGame()
        {
            Console.CursorVisible = false;

            random = new Random();
            map = new Pixel[MAP_SIZE, MAP_SIZE];

            avoidCnt = 0; //랭크에 사용되는 점수 초기화

            //맵 초기화
            for (int i = 0; i < MAP_SIZE; i++)
            {
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    map[i, j] = new Pixel();
                    map[i, j].Color = ConsoleColor.Black;
                }
            }

            maker = new DotImageMaker();
            player = new Character();
            enemies = new Character[MAX_ENEMY];

            //플레이어 캐릭터 초기화
            player.ImageLeft = maker.MakePlayer();
            player.ImageRight = maker.Reverse(player.ImageLeft, ROW, COL);
            player.X = START_X;
            player.Y = START_Y;

            //스카몬 캐릭터 초기화
            for (int i = 0; i < MAX_ENEMY; i++)
            {
                enemies[i] = new Character();
                enemies[i].ImageLeft = maker.MakeEnemy();
                enemies[i].X = random.Next(COL_S, MAP_SIZE - COL_S);
                enemies[i].Y = random.Next(-50, 0); //화면 밖 ~ 화면 안
            }

            //맵에 플레이어 왼쪽 모습으로 넣기
            for (int i = player.Y; i < player.Y + ROW; i++)
            {
                for (int j = player.X; j < player.X + COL; j++)
                {
                    int y = i - player.Y;
                    int x = j - player.X;
                    map[i, j].Color = player.ImageLeft[y, x].Color;
                }
            }
        }

        private void InitMap()
        {
            //map 전체를 블랙으로 초기화해서 맵에 그려진 캐릭터들 지우기

            for (int i = 0; i < MAP_SIZE; i++)
            {
                for (int j = 0; j < MAP_SIZE; j++)
                {
                    map[i, j].Color = ConsoleColor.Black;
                }
            }
        }

        private void HandleUserInput(ref bool isLeft)
        {
            //방향키 좌/우에 따른 플레이어 캐릭터 이동

            ConsoleKeyInfo keyInfo;

            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        isLeft = true;
                        if (player.X >= LEFT_LIMIT)
                            player.MoveLeft();
                        break;

                    case ConsoleKey.RightArrow:
                        isLeft = false;
                        if (player.X <= RIGHT_LIMIT)
                            player.MoveRight();
                        break;
                }
            }
        }

        private void Update(ref bool isOver)
        {
            //스카몬을 아래로 이동시키고, 플레이어와 충돌 확인

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].MoveDown();

                //스카몬이 맵 밖으로 나가면 위치 리셋
                if (enemies[i].Y > MAP_SIZE)
                {
                    avoidCnt++;

                    enemies[i].X = random.Next(COL_S, MAP_SIZE - COL_S);
                    enemies[i].Y = random.Next(-50, 0); //화면 밖 ~ 화면 안
                }

                //충돌 판정
                bool isHitX = (enemies[i].X < player.X + COL) && (enemies[i].X + COL_S > player.X);
                bool isHitY = (enemies[i].Y < player.Y + ROW) && (enemies[i].Y + ROW_S > player.Y);


                if (isHitX && isHitY)
                {
                    //충돌 발생. 게임 종료
                    isOver = true;
                }
            }
        }

        private void Draw(bool isLeft)
        {
            //플레이어, 스카몬 캐릭터 map 배열에 넣고 콘솔에 출력

            InitMap();

            // map 배열에 플레이어 넣기
            Pixel[,] playerImg = isLeft ? player.ImageLeft : player.ImageRight;
            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    int y = player.Y + i;
                    int x = player.X + j;
                    if (y < 0 || y >= MAP_SIZE || x < 0 || x >= MAP_SIZE)
                        continue;

                    map[y, x].Color = playerImg[i, j].Color;
                }
            }

            // map 배열에 스카몬 넣기
            foreach (Character enemy in enemies)
            {
                Pixel[,] enemyImg = enemy.ImageLeft;
                for (int i = 0; i < ROW_S; i++)
                {
                    for (int j = 0; j < COL_S; j++)
                    {
                        int y = enemy.Y + i;
                        int x = enemy.X + j;
                        if (y < 0 || y >= MAP_SIZE || x < 0 || x >= MAP_SIZE)
                            continue;
                        map[y, x].Color = enemyImg[i, j].Color;
                    }
                }
            }

            //콘솔화면에 출력
            PrintMap(); 
        }

        private void TextClear()
        {
            //타이틀 메뉴에 쓰인 텍스트들 숨기기
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("                                                                                    ");
            }
        }

        private void ShowTitle()
        {
            string[] titleStr = {
                "스카몬 피하기",
                "",
                "개발 : 김태웅",
                "",
                "시작하려면 아무 키나 누르세요."
            };

            string space = "                         ";
            string[] pressStr = { "PRESS ANY KEY TO START", space };

            //타이틀 스트링 한글자씩 출력
            for (int i = 0; i < titleStr.Length; i++)
            {
                string s = titleStr[i];
                if (s.Length > 0)
                    Console.Write(space);

                for (int j = 0; j < s.Length; j++)
                {
                    Console.Write(s[j]);
                    Thread.Sleep(100);
                }

                Console.WriteLine();
                Thread.Sleep(1000);
            }

            bool flag = true;
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    //타이틀 화면 출력하는 동안에 누른 키 버퍼 비우기
                    while(Console.KeyAvailable)
                        Console.ReadKey(true);

                    TextClear();    //메인메뉴 보여주기 전에 콘솔화면에 적힌 텍스트 지우기
                    break;
                }
                else
                {
                    //텍스트 깜빡이기
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(0, 8);
                    Console.Write(space);
                    if (flag)
                        Console.WriteLine(pressStr[0]);
                    else
                        Console.WriteLine(pressStr[1]);

                    flag = !flag;
                }
                Thread.Sleep(300);
            }
        }

        private enum MenuState
        {
            Start,
            Rank,
            EXIT
        }

        private MenuState ShowMainMenu()
        {
            Console.CursorVisible = false;

            string[] menu = { "게임 시작  ", "랭킹 보기  ", "게임 종료  " }; //화살표 때문에 남는 글자 지우기 위해 뒤에 공백 추가

            int idx = 0;

            bool flag = true;
            while(flag)
            {
                ShowText(menu,idx);

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch(keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        idx = (idx + 1) % 3;
                        break;

                    case ConsoleKey.UpArrow:
                        idx--;
                        if (idx < 0)
                            idx = 2;
                        break;

                    case ConsoleKey.Enter:
                        flag = false;
                        break;
                }
                
            }

            return (MenuState)idx;

        }

        private void ShowText(string[] menu, int idx)
        {
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("시작 전에 Ctrl + 마우스 휠 아래로 9번 해주세요.");

            Console.SetCursorPosition(25, 4);
            Console.WriteLine("방향키를 이용해서 메뉴를 이동하고 Enter.");

            for(int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(25, 6 + i*2);
                if (idx == i)
                    Console.Write("▶ ");
                
                Console.WriteLine(menu[i]);
                
            }
        }

        private void ShowResult()
        {
            //게임 내 바닥 색깔 없애기
            Console.BackgroundColor = ConsoleColor.Black;

            RankIO.ReadRank();
            int idx = RankIO.CheckUpdate(avoidCnt);

            Console.Clear();
            Console.SetCursorPosition(25, 6);
            Console.WriteLine($"피한 스카몬 : {avoidCnt}");
            if(idx != -1)
            {
                Console.SetCursorPosition(25, 8);
                Console.WriteLine($"!!! 축하합니다. {idx+1}위 달성 !!!");
                RankIO.WriteRank(idx, nickname, avoidCnt);
            }

            Console.SetCursorPosition(25, 10);
            Console.WriteLine("아무 키나 눌러서 메뉴로 이동");
            Console.ReadKey(true);
            Console.Clear();
        }

        private void ShowRank()
        {
            int pos1 = 25, pos2 = 14;
            RankIO.ReadRank();
            RankIO.PrintRank(pos1,pos2);
        }

        private void InputNickname()
        {
            Console.Clear();
            Console.SetCursorPosition(25,6);
            Console.WriteLine("닉네임 영문 3글자를 입력하세요. (3글자가 아닐시 기본값 사용)");
            Console.SetCursorPosition(25, 8);
            Console.Write("영문 3글자 입력 : ");
            
            nickname = Console.ReadLine() ?? "___";
           
            if(nickname.Length != 3)
            {
                if (nickname.Length > 3)
                    nickname = nickname.Substring(0, 3);
                else
                {
                    nickname = "___";
                }
            }

            Console.SetCursorPosition(25, 10);
            Console.WriteLine($"플레이어 닉네임 : {nickname}");

            Console.SetCursorPosition(25, 14);
            Console.WriteLine("5초 뒤에 시작합니다.");
            Console.SetCursorPosition(25, 16);
            Console.WriteLine("Ctrl + 마우스 휠 아래로 9번을 설정 해주세요.");

            for (int i = 5; i > 0; i--)
            {
                Console.SetCursorPosition(25, 18);
                Console.WriteLine($"{i}");
                Thread.Sleep(1000);
            }
            
        }

        public void Run()
        {
            BGMPlayer.Play();

            ShowTitle();
            bool running = true;
            while(running)
            {
                MenuState state = ShowMainMenu();

                if(state == MenuState.Start)
                {
                    InputNickname();
                    SetGame();

                    bool isLeft = true;
                    bool isOver = false;

                    while (!isOver)
                    {
                        HandleUserInput(ref isLeft);
                        Update(ref isOver);
                        Draw(isLeft);
                    }

                    ShowResult();
                }

                else if (state == MenuState.Rank)
                    ShowRank();

                else
                    running = false;
            }
        }
    }
}