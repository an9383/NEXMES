namespace WIZ.Control
{
    public class Padding
    {
        private int _left = 0;

        private int _top = 0;

        private int _right = 0;

        private int _bottom = 0;

        public int Left => _left;

        public int Top => _top;

        public int Right => _right;

        public int Bottom => _bottom;

        public Padding(int left, int top, int right, int bottom)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }
    }
}
