using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    private string windowName;

    [Space(10)]
    [SerializeField]
    private Animator windowAnimator;
    [SerializeField]
    private string openAnimationName;
    [SerializeField]
    private string idleAnimationName;
    [SerializeField]
    private string closeAnimationName;
    [SerializeField]
    private string hiddenAnimationName;

    public bool IsOpened { get; protected set; } = false;

    protected Animator WindowAnimator
    {
        get
        {
            if (windowAnimator == null)
                windowAnimator = GetComponent<Animator>();

            return windowAnimator;
        }
    }

    public virtual void Initialize() { }


    public void Show(bool isImmediatyle)
    {
        OpenStart();
        WindowAnimator.Play(isImmediatyle ? idleAnimationName : openAnimationName);

        if (isImmediatyle)
            OpenEnd();
    }

    public void Hide(bool isImmediatyle)
    {
        CloseStart();
        WindowAnimator.Play(isImmediatyle ? hiddenAnimationName : closeAnimationName);

        if (isImmediatyle)
            CloseEnd();
    }

    protected virtual void OpenStart()
    {
        this.gameObject.SetActive(true);
        IsOpened = true;
    }

    protected virtual void OpenEnd()
    {

    }

    protected virtual void CloseStart()
    {
        IsOpened = false;
    }

    protected virtual void CloseEnd()
    {
        this.gameObject.SetActive(false);
    }

}
