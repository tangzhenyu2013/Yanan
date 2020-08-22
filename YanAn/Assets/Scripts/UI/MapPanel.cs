using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : SingletonMono<MapPanel>
{
    public GameObject btn;
    public PointItem[] pointItems;
    // Start is called before the first frame update
    public static bool isLookMap;
    void Start()
    {
        PointCollection pointCollection = GameManager.GetInstance.JsonManager.PointCollection;

        if (pointCollection != null)
        {
            List<PointData> pointDatas = pointCollection.context;

            if (pointItems.Length < pointDatas.Count) return;

            for (int i = 0; i < pointDatas.Count; i++)
            {
                pointItems[i].Initial(pointDatas[i]);
            }
        }

        RefreshBtn();

        DelayedFunctionCaller.DelayedCall(this, 1f, OpenDialogPanel);
    }

    private void OpenDialogPanel()
    {
        DiaLogPanel diaLogPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.dialogPath) as DiaLogPanel;
        diaLogPanel.Initial("老师：你就是个dei；");
        diaLogPanel.InitButton(() => { GameManager.GetInstance.UIPanelManager.CloseBasePanel(); });
    }

    public void RefreshBtn()
    {
        btn.SetActive(isLookMap);
    }
}
