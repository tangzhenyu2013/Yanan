using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PointItem : MonoBehaviour, IPointerClickHandler
{
    public GameObject isReadObj;

    private PointData pointData;
    public void Initial(PointData pointData)
    {
        this.pointData = pointData;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DesTipCtrl.ShowTips3D(pointData.地名, transform.localPosition, Anchor.Top, 0.5f, OpenDesPanel);
    }

    public void OpenDesPanel()
    {
        DesObjPanel desObjPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.desPanePath) as DesObjPanel;
        if (desObjPanel != null)
        {
            desObjPanel.Initial(pointData.描述);
        }
    }
}
