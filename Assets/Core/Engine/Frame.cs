using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Core.Engine
{
    public class Frame
    {
        public readonly Frame past;
        public ReadOnlyCollection<Frame> futures => _futures.AsReadOnly();
        public Input input
        {
            get => _input; 
            set
            {
                _input = value;
                OnPastChanged();
            }
        }

        private readonly List<Frame> _futures;
        private Input _input;

        private Frame() { }
        private Frame(Frame past)
        {
            this.past = past;
        }

        private void OnPastChanged()
        {
            //TODO: 入力と過去をもとに現在を再計算


            // 全ての未来に過去が変わったことを知らせる
            foreach (var future in _futures)
            {
                future.OnPastChanged();
            }
        }

        public Frame CreateFuture()
        {
            var f = new Frame(this);
            _futures.Add(f);
            return f;
        }

        public static Frame CreateRoot()
        {
            return new Frame();
        }
    }
}
