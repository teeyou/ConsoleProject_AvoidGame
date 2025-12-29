namespace ConsoleProject
{
    class Pixel
    {
        public char Ch { get; set; }
        public ConsoleColor Color { get; set; }

        public Pixel()
        {
            Ch = ' ';
            Color = ConsoleColor.Black;
        }

        public Pixel(ConsoleColor color)
        {
            Ch = ' ';
            Color = color;
        }
    }
}
