using Assets.Core.Engine;
using System.Collections.Generic;
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
            ApplyFrame(timeLineEngine.rootFrame);
        }

        private void ApplyFrame(Frame frame)
        {
            for (int i = 0; i < frame.futures.Count; i++)
            {
                // �����̖���������Ȃ�TimeLine�𕪂���
                if (i > 0)
                {
                    AddTimeLine(frame.futures[i]);
                }

                // �S�Ă̖����ł�ApplyFrame������
                ApplyFrame(frame.futures[i]);
            }
        }

        private void AddTimeLine(Frame frame)
        {
            rootFrames.Add(frame);
        }

        private void ApplyDiff()
        {

        }
    }
}
