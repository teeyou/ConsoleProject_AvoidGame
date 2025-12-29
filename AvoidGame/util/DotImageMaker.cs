namespace ConsoleProject.util
{
    // 도트이미지를 만들어주는 클래스
    class DotImageMaker
    {
        //도트이미지 하나의 라인을 그릴 때 사용하는 데이터 클래스
        class Data
        {
            public int Count { get; set; }
            public ConsoleColor Color { get; set; }

            public Data(int count, ConsoleColor color)
            {
                Count = count;
                Color = color;
            }
        }

        //플레이어 캐릭터 사이즈
        private const int ROW = 30;
        private const int COL = 29;

        //스카몬 사이즈
        private const int ROW_S = 14;
        private const int COL_S = 16;

        //14x16 크기의 스카몬
        public Pixel[,] MakeEnemy()
        {
            Pixel[,] pixels = new Pixel[ROW_S, COL_S];
            MakeLine(pixels, 0,
                new Data(8, ConsoleColor.Black),
                new Data(3, ConsoleColor.Yellow),
                new Data(5, ConsoleColor.Black));

            MakeLine(pixels, 1,
                new Data(6, ConsoleColor.Black),
                new Data(2, ConsoleColor.Yellow),
                new Data(3, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(4, ConsoleColor.Black));

            MakeLine(pixels, 2,
                new Data(5, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(4, ConsoleColor.Black),
                new Data(2, ConsoleColor.Yellow),
                new Data(4, ConsoleColor.Black));

            MakeLine(pixels, 3,
                new Data(4, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(5, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(5, ConsoleColor.Black));

            MakeLine(pixels, 4,
                new Data(4, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(5, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(5, ConsoleColor.Black));

            MakeLine(pixels, 5,
                new Data(3, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(7, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(4, ConsoleColor.Black));

            MakeLine(pixels, 6,
                new Data(2, ConsoleColor.Black),
                new Data(3, ConsoleColor.Yellow),
                new Data(3, ConsoleColor.Black),
                new Data(2, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(3, ConsoleColor.Black));

            MakeLine(pixels, 7,
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black),
                new Data(2, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black),
                new Data(2, ConsoleColor.Yellow),
                new Data(3, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(3, ConsoleColor.Black));

            MakeLine(pixels, 8,
                new Data(1, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(11, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black));

            MakeLine(pixels, 9,
                new Data(1, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(3, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black));

            MakeLine(pixels, 10,
                new Data(1, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black),
                new Data(2, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black),
                new Data(2, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black),
                new Data(2, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black));

            MakeLine(pixels, 11,
                new Data(1, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(4, ConsoleColor.Black),
                new Data(1, ConsoleColor.Yellow),
                new Data(1, ConsoleColor.Black));

            MakeLine(pixels, 12,
               new Data(1, ConsoleColor.Black),
               new Data(1, ConsoleColor.Yellow),
               new Data(11, ConsoleColor.Black),
               new Data(1, ConsoleColor.Yellow),
               new Data(2, ConsoleColor.Black));

            MakeLine(pixels, 13,
               new Data(2, ConsoleColor.Black),
               new Data(11, ConsoleColor.Yellow),
               new Data(3, ConsoleColor.Black));
             
            return pixels;
        }

        //30x29 크기의 플레이어 길몬
        public Pixel[,] MakePlayer()
        {
            Pixel[,] pixels = new Pixel[ROW, COL];

            MakeLine(pixels, 0,
                new Data(8, ConsoleColor.Black),
                new Data(7, ConsoleColor.Red),
                new Data(2, ConsoleColor.Black),
                new Data(8, ConsoleColor.Red),
                new Data(4, ConsoleColor.Black));

            MakeLine(pixels, 1,
                new Data(7, ConsoleColor.Black),
                new Data(2, ConsoleColor.Red),
                new Data(4, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(6, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(5, ConsoleColor.Black));

            MakeLine(pixels, 2,
                new Data(6, ConsoleColor.Black),
                new Data(2, ConsoleColor.Red),
                new Data(4, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(3, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(5, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(6, ConsoleColor.Black));

            MakeLine(pixels, 3,
                new Data(5, ConsoleColor.Black),
                new Data(12, ConsoleColor.Red),
                new Data(2, ConsoleColor.Black),
                new Data(3, ConsoleColor.Red),
                new Data(7, ConsoleColor.Black));

            MakeLine(pixels, 4,
                new Data(4, ConsoleColor.Black),
                new Data(2, ConsoleColor.Red),
                new Data(13, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(9, ConsoleColor.Black));

            MakeLine(pixels, 5,
                new Data(3, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(15, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(9, ConsoleColor.Black));

            //눈 시작
            MakeLine(pixels, 6,
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(7, ConsoleColor.Black),
                new Data(6, ConsoleColor.Red),
                new Data(3, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(9, ConsoleColor.Black));

            MakeLine(pixels, 7,
                  new Data(1, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(7, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //눈동자
                  new Data(2, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Yellow),
                  new Data(1, ConsoleColor.Red),
                  new Data(5, ConsoleColor.Black),
                  new Data(2, ConsoleColor.Red),
                  new Data(7, ConsoleColor.Black));


            MakeLine(pixels, 8,
                  new Data(1, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(7, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.Black),  //눈동자
                  new Data(2, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Yellow),
                  new Data(1, ConsoleColor.Red),
                  new Data(5, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(8, ConsoleColor.Black));


            MakeLine(pixels, 9,
                  new Data(1, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(2, ConsoleColor.Black),
                  new Data(3, ConsoleColor.Red),
                  new Data(2, ConsoleColor.Black),  //눈동자
                  new Data(6, ConsoleColor.Red),
                  new Data(4, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(9, ConsoleColor.Black));

            //눈 끝

            MakeLine(pixels, 10,
                  new Data(1, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(18, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(8, ConsoleColor.Black));


            MakeLine(pixels, 11,
                  new Data(2, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(17, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(8, ConsoleColor.Black));


            MakeLine(pixels, 12,
                  new Data(3, ConsoleColor.Black),
                  new Data(12, ConsoleColor.Red),
                  new Data(4, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(9, ConsoleColor.Black));


            MakeLine(pixels, 13,
                    new Data(5, ConsoleColor.Black),
                    new Data(1, ConsoleColor.Red),
                    new Data(13, ConsoleColor.Black),
                    new Data(1, ConsoleColor.Red),
                    new Data(9, ConsoleColor.Black));


            MakeLine(pixels, 14,
                 new Data(5, ConsoleColor.Black),
                 new Data(10, ConsoleColor.Red),
                 new Data(5, ConsoleColor.Black),
                 new Data(1, ConsoleColor.Red),
                 new Data(8, ConsoleColor.Black));

            MakeLine(pixels, 15,
                 new Data(8, ConsoleColor.Black),
                 new Data(1, ConsoleColor.Red),
                 new Data(11, ConsoleColor.Black),
                 new Data(1, ConsoleColor.Red),
                 new Data(8, ConsoleColor.Black));

            //손 시작
            MakeLine(pixels, 16,
                 new Data(4, ConsoleColor.Black),
                 new Data(5, ConsoleColor.Red),
                 new Data(6, ConsoleColor.Black),
                 new Data(4, ConsoleColor.Red),
                 new Data(1, ConsoleColor.Black),
                 new Data(1, ConsoleColor.Red),
                 new Data(6, ConsoleColor.Black),
                 new Data(1, ConsoleColor.Red),
                 new Data(1, ConsoleColor.Black));


            MakeLine(pixels, 17,
                  new Data(4, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //왼쪽 손톱
                  new Data(2, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.Black),
                  new Data(6, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //오른쪽 손톱
                  new Data(3, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(5, ConsoleColor.Black),
                  new Data(2, ConsoleColor.Red),
                  new Data(1, ConsoleColor.Black));


            MakeLine(pixels, 18,
                  new Data(4, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //왼쪽 손톱
                  new Data(2, ConsoleColor.Black),
                  new Data(2, ConsoleColor.Red),
                  new Data(5, ConsoleColor.White),  //배
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //오른쪽 손톱
                  new Data(4, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(3, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.Black));

            MakeLine(pixels, 19,
                  new Data(4, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //왼쪽 손톱
                  new Data(2, ConsoleColor.Black),
                  new Data(2, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //배
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //배
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //배
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.White),  //오른쪽 손톱
                  new Data(5, ConsoleColor.Black),
                  new Data(3, ConsoleColor.Red),
                  new Data(2, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(1, ConsoleColor.Black));


            MakeLine(pixels, 20,
                 new Data(5, ConsoleColor.Black),
                 new Data(3, ConsoleColor.Red),
                 new Data(1, ConsoleColor.Black),
                 new Data(1, ConsoleColor.Red),
                 new Data(2, ConsoleColor.White),   //배
                 new Data(1, ConsoleColor.Red),
                 new Data(2, ConsoleColor.White),   //배
                 new Data(4, ConsoleColor.Red),
                 new Data(7, ConsoleColor.Black),
                 new Data(2, ConsoleColor.Red),
                 new Data(1, ConsoleColor.Black));
            //손 끝 

            MakeLine(pixels, 21,
                new Data(6, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(2, ConsoleColor.White),   //배
                new Data(1, ConsoleColor.Red),
                new Data(2, ConsoleColor.White),   //배
                new Data(1, ConsoleColor.Red),
                new Data(10, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(2, ConsoleColor.Black));

            MakeLine(pixels, 22,
                new Data(6, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(2, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(5, ConsoleColor.White),   //배
                new Data(1, ConsoleColor.Red),
                new Data(9, ConsoleColor.Black),
                new Data(1, ConsoleColor.Red),
                new Data(3, ConsoleColor.Black));

            MakeLine(pixels, 23,
                  new Data(6, ConsoleColor.Black),
                  new Data(3, ConsoleColor.Red),
                  new Data(1, ConsoleColor.Black),
                  new Data(5, ConsoleColor.Red),
                  new Data(1, ConsoleColor.Black),
                  new Data(3, ConsoleColor.Red),
                  new Data(5, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(4, ConsoleColor.Black));

            MakeLine(pixels, 24,
                  new Data(5, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(9, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(5, ConsoleColor.Black),
                  new Data(3, ConsoleColor.Red),
                  new Data(5, ConsoleColor.Black));

            MakeLine(pixels, 25,
                  new Data(5, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(9, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(5, ConsoleColor.Black),
                  new Data(3, ConsoleColor.Red),
                  new Data(5, ConsoleColor.Black));

            MakeLine(pixels, 26,
                      new Data(4, ConsoleColor.Black),
                      new Data(1, ConsoleColor.Red),
                      new Data(9, ConsoleColor.Black),
                      new Data(1, ConsoleColor.Red),
                      new Data(6, ConsoleColor.Black),
                      new Data(1, ConsoleColor.Red),
                      new Data(7, ConsoleColor.Black));

            MakeLine(pixels, 27,
                  new Data(4, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(6, ConsoleColor.Black),
                  new Data(4, ConsoleColor.Red),
                  new Data(6, ConsoleColor.Black),
                  new Data(1, ConsoleColor.Red),
                  new Data(7, ConsoleColor.Black));

            MakeLine(pixels, 28,
                 new Data(4, ConsoleColor.Black),
                 new Data(1, ConsoleColor.Red),
                 new Data(6, ConsoleColor.White),   //발톱
                 new Data(1, ConsoleColor.Red),
                 new Data(2, ConsoleColor.Black),
                 new Data(1, ConsoleColor.Red),
                 new Data(6, ConsoleColor.White),   //발톱
                 new Data(1, ConsoleColor.Red),
                 new Data(7, ConsoleColor.Black));

            MakeLine(pixels, 29,
                   new Data(4, ConsoleColor.Black),
                   new Data(8, ConsoleColor.Red),
                   new Data(2, ConsoleColor.Black),
                   new Data(8, ConsoleColor.Red),
                   new Data(7, ConsoleColor.Black));

            return pixels;
        }

        //왼쪽 모습의 이미지를 오른쪽으로 뒤집기
        public Pixel[,] Reverse(Pixel[,] origin, int row, int col)
        {
            Pixel[,] pixels = new Pixel[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    pixels[i, j] = origin[i, col - 1 - j];
                }
            }
            return pixels;
        }

        private Pixel MakeColorPixel(ConsoleColor color)
        {
            return new Pixel(color);
        }

        //도트 라인마다 파라미터 개수 다르게 받아옴
        private void MakeLine(Pixel[,] pixels, int line, params Data[] inputs)
        {
            int idx = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                int j = 0;
                while (j < inputs[i].Count)
                {
                    Pixel p = MakeColorPixel(inputs[i].Color);
                    pixels[line, idx] = p;
                    idx++;
                    j++;
                }
            }
        }

    }
}
