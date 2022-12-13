using Assets.Core.Engine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JuhaKurisu
{
    public class TimeLineViewer : MonoBehaviour
    {
        [SerializeField] UnityEngine.GameObject timeLinePrefab;
        [SerializeField] List<TimeLine> timeLineObjs;
        public TimeLineEngine timeLineEngine;
        List<Frame> rootFrames = new();

        private void Start()
        {
            rootFrames.Clear();
            // 初期のrootFrameのみ差分として検知されないため追加する
            rootFrames.Add(timeLineEngine.rootFrame);
            ApplyFrame(timeLineEngine.rootFrame);
            ApplyDiff();
        }

        private void ApplyFrame(Frame frame)
        {
            for (int i = 0; i < frame.futures.Count; i++)
            {
                // 複数の未来があるならTimeLineを分ける
                if (i > 0)
                {
                    AddTimeLine(frame.futures[i]);
                }

                // 全ての未来でもApplyFrameをする
                ApplyFrame(frame.futures[i]);
            }
        }

        private void AddTimeLine(Frame frame)
        {
            rootFrames.Add(frame);
        }

        private void ApplyDiff()
        {
            // 数合わせ
            if (timeLineObjs.Count != rootFrames.Count)
            {
                // 削除
                while (timeLineObjs.Count > rootFrames.Count) DelteTimeLine();
                // 追加
                while (timeLineObjs.Count < rootFrames.Count) CreateTimeLine();
            }

            // 各タイムラインのFrameを変更していく
            for (int i = 0; i < rootFrames.Count; i++)
            {
                timeLineObjs[i].frame = rootFrames[i];
                timeLineObjs[i].timeLineId = i;
            }
        }

        private TimeLine CreateTimeLine()
        {
            TimeLine timeLine = Instantiate(timeLinePrefab).GetComponent<TimeLine>();
            timeLine.gameObject.transform.SetParent(transform);
            timeLineObjs.Add(timeLine);
            return timeLine;
        }

        private void DelteTimeLine()
        {
            Destroy(timeLineObjs.Last());
            timeLineObjs.RemoveAt(timeLineObjs.Count - 1);
        }
    }
}
