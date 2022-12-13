using Assets.Core.Engine;
using UnityEngine;

namespace JuhaKurisu
{
    public class TimeLine : MonoBehaviour
    {
        [SerializeField] UnityEngine.GameObject uObj;
        [SerializeField] int displayWidth;
        [SerializeField] int maxWidth;
        [SerializeField] int margin;

        public Frame frame;
        public int timeLineId;
        public int height;
        int length;
        RectTransform rectTransform;
        RectTransform uRectTransform;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            uRectTransform = uObj.GetComponent<RectTransform>();
        }

        private void Update()
        {
            length = frame.maxFrameCount - frame.frameCount;
            uObj.SetActive(timeLineId != 0);

            rectTransform.sizeDelta = new Vector2(maxWidth * (length / (float)frame.maxFrameCount), 1);
            rectTransform.position = new Vector2(frame.frameCount / (float)(frame.maxFrameCount) * maxWidth + (displayWidth - maxWidth) / 2f, timeLineId * margin + 30);
            uRectTransform.sizeDelta = new Vector2(1, margin * height);
        }
    }
}
