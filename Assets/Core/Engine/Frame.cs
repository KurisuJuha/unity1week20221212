namespace Assets.Core.Engine
{
    public class Frame
    {
        public readonly Frame past;
        public readonly Frame future;
        private bool isDirty;

        internal Frame(Frame past = null, Frame future = null)
        {
            this.past = past;
            this.future = future;
        }

    }
}
