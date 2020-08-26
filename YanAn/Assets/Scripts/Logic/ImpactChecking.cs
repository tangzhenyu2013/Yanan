using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactChecking : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        TipsPanel tipsPanel;
        switch (collision.gameObject.name)
        {
            case "baimaonv":
                tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                tipsPanel.Initial("进入故事提示", "是否进入白毛女故事环节");
                tipsPanel.InitButton(
                    () =>
                    {
                        GameManager.GetInstance.AssessmentManager.isEnterBaimaonv = true;
                        GameManager.GetInstance.AssessmentManager.ExecutionCallBaiMaonvAssessment();
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                    }
                    , () =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                    }, "是的！进入", "我在逛逛");
                break;
            case "yanggeju":
                tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                tipsPanel.Initial("进入故事提示", "是否进入《兄妹开荒》秧歌剧排演环节");
                tipsPanel.InitButton(
                    () =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                        BasePanel basePanel =
                        GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.clothingCollocationPanelPath);
                        basePanel.Initial();
                    }
                    , () =>
                 {
                     GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                 }, "是的！进入", "我在逛逛");
                break;
            default:
                break;
        }
    }
}
