using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public RectTransform Bar;
    float MaxWidth;
    float Y;

    float Progress;

    public RectTransform MyTransform;
    public CanvasGroup Canvas;

	// Use this for initialization
	void Awake ()
    {
        Y = Bar.sizeDelta.y;
        MaxWidth = Bar.sizeDelta.x;
        Bar.sizeDelta = new Vector2(0, Y);
    }

    public void Show()
    {
        Canvas.alpha = 1;
    }

    public void Hide()
    {
        Canvas.alpha = 0;
    }

    private void Update()
    {
        MyTransform.LookAt(GameObject.Find("UIPivot").transform.position);
    }

    public void SetProgress(float progress)
    {
        progress = Mathf.Clamp01(progress);
        Bar.sizeDelta = new Vector2(progress * MaxWidth, Y);
    }
    
    IEnumerator DebugFillBar(float time)
    {
        float startTime = Time.time;
        float endTime = startTime + time;

        while(Time.time < endTime)
        {
            float progress = (Time.time - startTime) / (endTime - startTime);

            Debug.Log(progress);

            SetProgress(progress);
            yield return new WaitForEndOfFrame();
        }

        SetProgress(1);

        yield return null;
    }
}
