using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Core.Engine
{
    public class Frame
    {
        public readonly Frame past;
        public ReadOnlyCollection<Frame> future => _future.AsReadOnly();
        public readonly Input input;

        private readonly List<Frame> _future;

        private Frame() { }
        private Frame(Frame past)
        {
            this.past = past;
        }

        public static Frame CreateRoot()
        {
            return new Frame();
        }

        public Frame CreateFuture()
        {
            var f = new Frame(this);
            _future.Add(f);
            return f;
        }
    }
}
