using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assets.Core.Engine
{
    public class Frame
    {
        public readonly Frame past;
        public ReadOnlyCollection<Frame> futures => _futures.AsReadOnly();
        public ReadOnlyCollection<GameObject> gameObjects => _gameObjects.AsReadOnly();
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
        private readonly List<GameObject> _gameObjects;
        private Input _input;

        private Frame() { }
        private Frame(Frame past)
        {
            this.past = past;
        }

        private void OnPastChanged()
        {
            // 入力と過去をもとに現在を再計算
            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update(this);
            }

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
