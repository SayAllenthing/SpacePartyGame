using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tweens;

public class MenuBase : MonoBehaviour
{
    public CanvasGroupAlphaTween actionAlpha;
    public CanvasGroup Self;

    public bool IsShowing = false;

    public void Toggle()
    {
        if (IsShowing)
            Hide();
        else
            Show();
    }

    public virtual void Show()
    {
        actionAlpha.Init(Self, 1, 0.2f);
        actionAlpha.begin();
        Self.interactable = true;
        Self.blocksRaycasts = true;

        OnShow();

        IsShowing = true;
    }
    public virtual void Hide()
    {
        actionAlpha.Init(Self, 0, 0.2f);
        actionAlpha.begin();
        Self.interactable = false;
        Self.blocksRaycasts = false;

        OnHide();

        IsShowing = false;
    }

    protected virtual void OnShow() { }
    protected virtual void OnHide() { }
}
