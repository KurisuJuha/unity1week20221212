namespace Assets.Core.Engine
{
    public struct Input
    {
        public readonly bool rightArrow;
        public readonly bool leftArrow;
        public readonly bool jumpButton;

        public Input(bool rightArrow, bool leftArrow, bool jumpButton)
        {
            this.rightArrow = rightArrow;
            this.leftArrow = leftArrow;
            this.jumpButton = jumpButton;
        }
    }
}
