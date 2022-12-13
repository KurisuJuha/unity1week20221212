using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Assets.Core.Engine
{
    public class Frame
    {
        public readonly Frame past;
        public readonly int frameCount;
        public readonly int maxFrameCount;
        public bool isDirty { get; private set; } = true;
        public ReadOnlyCollection<Frame> futures => _futures.AsReadOnly();
        public ReadOnlyCollection<GameObject> gameObjects => _gameObjects.AsReadOnly();
        public Input input
        {
            get => _input;
            set
            {
                _input = value;
                SetDirty();
            }
        }

        private readonly List<Frame> _futures = new List<Frame>();
        private readonly List<GameObject> _gameObjects = new List<GameObject>();
        private Input _input;

        private Frame() { }
        private Frame(Frame past, int maxFrameCount)
        {
            this.past = past;
            past._gameObjects.ForEach(g => _gameObjects.Add(g.Copy()));
            frameCount = past.frameCount + 1;
            this.maxFrameCount = maxFrameCount;
        }
        private Frame(List<GameObject> gameObjects, int maxFrameCount)
        {
            _gameObjects = gameObjects;
            this.maxFrameCount = maxFrameCount;
        }

        private void SetDirty()
        {
            // 全ての未来に過去が変わったことを知らせる
            foreach (var future in _futures)
            {
                future.SetDirty();
            }
        }

        public void Calculate()
        {
            // もし変更が適用済みならそのまま返す
            if (!isDirty) return;

            // もし過去が変わっているなら、過去を再計算する
            if (past.isDirty) past.Calculate();

            // 過去のゲームオブジェクトを全てコピーする
            _gameObjects.Clear();
            past._gameObjects.ForEach(g => _gameObjects.Add(g));

            // 全てのゲームオブジェクトを再計算する
            foreach (var gameObject in gameObjects)
            {
                gameObject.Update(this);
            }

            // 変更を適用したことを示す
            isDirty = false;
        }

        public Frame CreateFuture()
        {
            // frameCountがmaxFrameCountに達していないなら
            if (frameCount + 1 >= maxFrameCount) return null;

            var f = new Frame(this, maxFrameCount);
            _futures.Add(f);
            return f;
        }

        public static Frame CreateRoot(GameObject[] gameObjects, int maxFrameCount)
        {
            return new Frame(gameObjects.ToList(), maxFrameCount);
        }
    }
}
