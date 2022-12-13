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
            // ������rootFrame�̂ݍ����Ƃ��Č��m����Ȃ����ߒǉ�����
            rootFrames.Add(timeLineEngine.rootFrame);
            ApplyFrame(timeLineEngine.rootFrame);
            ApplyDiff();
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
            // �����킹
            if (timeLineObjs.Count != rootFrames.Count)
            {
                // �폜
                while (timeLineObjs.Count > rootFrames.Count) DelteTimeLine();
                // �ǉ�
                while (timeLineObjs.Count < rootFrames.Count) CreateTimeLine();
            }

            // �e�^�C�����C����Frame��ύX���Ă���
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
