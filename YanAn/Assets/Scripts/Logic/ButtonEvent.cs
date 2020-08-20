using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        string btnName = eventData.pointerEnter.name;
        switch (btnName)
        {
            case "教室_返回":
                Debug.Log("返回");
                break;
            case "教室_说明":
                Debug.Log("说明");
                break;
            case "教室_全屏":
                Debug.Log("全屏");
                break;
            default:
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        string btnName = eventData.pointerEnter.name;
        switch (btnName)
        {
            case "教室_返回":
                DesTipCtrl.ShowTips("教室", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, -50);
                break;
            case "教室_说明":
                DesTipCtrl.ShowTips("说明", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, -50);
                break;
            case "教室_全屏":
                DesTipCtrl.ShowTips("全屏", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, -50);
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DesTipCtrl.HideTips();
    }
}
