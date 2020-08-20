using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Test : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DesTipCtrl.ShowTips("你是个傻逼", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, -80);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DesTipCtrl.HideTips();
    }
}
