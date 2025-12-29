namespace ConsoleProject
{
    class Character
    {
        const int STEP = 5;
        public int X {  get; set; }
        public int Y { get; set; }

        public Pixel[,] ImageLeft { get; set; }
        
        public Pixel[,] ImageRight { get; set; }

        public Character()
        {
            X = 0;
            Y = 0;
        }

        public void MoveLeft()
        {
            X -= STEP;
        }

        public void MoveRight()
        {
            X += STEP;
        }

        public void MoveDown()
        {
            Y += STEP;
        }
    }
}
