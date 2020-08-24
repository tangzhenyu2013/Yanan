using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactChecking : MonoBehaviour
{
    private TipsPanel tipsPanel;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "xintianyou":
                tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                tipsPanel.Initial("提示", "功能暂未开发，敬请期待!");
                tipsPanel.InitButton(() =>
                {
                    GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                }, "确定");
                break;
            case "baimaonv":
                tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                tipsPanel.Initial("提示", "功能暂未开发，敬请期待!");
                tipsPanel.InitButton(() =>
                {
                    GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                }, "确定");
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
            case "taicipaiyan":
                tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                tipsPanel.Initial("提示", "功能暂未开发，敬请期待!");
                tipsPanel.InitButton(() =>
                {
                    GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                }, "确定");
                break;
            default:
                break;
        }
    }
}
