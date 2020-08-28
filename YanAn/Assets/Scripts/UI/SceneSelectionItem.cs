using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class SceneSelectionItem : MonoBehaviour, IPointerClickHandler
{
    /// <summary>
    /// 解锁状态
    /// </summary>
    private bool state;
    /// <summary>
    /// 上锁标识
    /// </summary>
    public GameObject lockObj;
    /// <summary>
    /// 选中标识
    /// </summary>
    public GameObject selectOb;
    /// <summary>
    /// 委托回调
    /// </summary>
    private UnityAction unityAction;

    public void RefrehItem(bool state, UnityAction _unityAction)
    {
        this.state = state;
        lockObj.SetActive(!state);
        selectOb.SetActive(false);
        unityAction = _unityAction;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!state) return;
        unityAction?.Invoke();
        selectOb.SetActive(true);
    }
}
