using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Assets.Core.Engine
{
    public class Frame
    {
        public readonly Frame past;
        public Frame future { get; private set; }
        public readonly bool isRoot;
        public Input input
        {
            get
            {
                return _input;
            }
            set
            {
                SetDirty();
                _input = value;
            }
        }
        public ReadOnlyCollection<GameObject> gameObjects
        {
            get
            {
                Calculate();
                return _gameObjects.AsReadOnly();
            }
        }
        public bool isDirty { get; private set; }

        private Input _input;
        private readonly List<GameObject> _gameObjects;

        private Frame() { }
        private Frame(GameObject[] gameObjects)
        {
            isRoot = true;
            _gameObjects = gameObjects.ToList();
        }
        private Frame(Frame past)
        {
            this.past = past;
        }

        private void SetDirty()
        {
            // 過去を変えると未来に影響を与えるため未来もdirtyにする
            future.SetDirty();
        }

        private void Calculate()
        {
            // isRootであれば固定のため計算しない
            if (isRoot) return;

            // isDirtyじゃないなら計算しない
            if (!isDirty) return;

            // 過去から全てのゲームオブジェクトをコピーする
            _gameObjects.Clear();
            past.gameObjects.ToList().ForEach(g => _gameObjects.Add(g));

            // 全てのゲームオブジェクトで計算する
            _gameObjects.ForEach(g => g.Update(this));
        }

        internal Frame CreateFuture()
        {
            return future = new Frame(this);
        }

        internal static Frame CreateRoot(GameObject[] gameObjects)
        {
            return new Frame(gameObjects);
        }
    }
}
