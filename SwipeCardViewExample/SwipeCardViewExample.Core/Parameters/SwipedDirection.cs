namespace SwipeCardViewExample.Core.Parameters
{
    public class SwipedDirection
    {
        public SwipedDirection(string item, string direction)
        {
            this.Item = item;
            this.Direction = direction;
        }

        public string Item { get; set; }

        public string Direction { get; set; }
    }
}
