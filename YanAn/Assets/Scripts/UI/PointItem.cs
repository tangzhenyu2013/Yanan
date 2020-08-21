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
        isReadObj.SetActive(this.pointData.isRead);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (pointData.isRead) return;
        DesTipCtrl.ShowTips3D(pointData.地名, transform.localPosition, Anchor.Top, 0.5f, OpenDesPanel);
    }

    public void OpenDesPanel()
    {
        DesTipCtrl.HideTips3D();
        pointData.isRead = true;
        isReadObj.SetActive(pointData.isRead);
        DesObjPanel desObjPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.desPanePath) as DesObjPanel;
        if (desObjPanel != null)
        {
            desObjPanel.Initial(pointData.描述);
            desObjPanel.InitButton(ShowGetPassPanel);
        }
    }

    private void ShowGetPassPanel()
    {
        PointCollection pointCollection = GameManager.GetInstance.JsonManager.PointCollection;
        List<PointData> pointDatas = pointCollection.context;
        bool isRead = true;
        for (int i = 0; i < pointDatas.Count; i++)
        {
            if (!pointDatas[i].isRead)
            {
                isRead = false;
                break;
            }
        }
        if (isRead)
        {
            BasePanel basePanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.getPassPanelPath);
            basePanel.Initial();
        }
    }
}
