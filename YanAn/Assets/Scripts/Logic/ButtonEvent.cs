using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    bool fullScreen = false;
    public void OnPointerClick(PointerEventData eventData)
    {
        string btnName = eventData.pointerEnter.name;
        switch (btnName)
        {
            case "返回":
                GameManager.LoadScene("开始试验");
                break;
            case "说明":
                TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                tipsPanel.Initial("操作说明", "使用W,A,S,D键操作人物");
                tipsPanel.InitButton(() =>
                {
                    GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                }, "确定");
                break;
            //case "全屏":
            //    fullScreen = !fullScreen;
            //    Screen.fullScreen = !fullScreen;
            //    break;
            case "进入场景":
                GameManager.LoadScene("文学院");
                break;
            case "实验报告":
                ExperReportPanel experReportPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.experReportPanelPath) as ExperReportPanel;
                experReportPanel.Initial();
                experReportPanel.InitButton(() =>
                {
                    GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                });
                break;
            case "场景选择":
                SceneSelectionPanel sceneSelectionPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.sceneSelectionPanelPath) as SceneSelectionPanel;
                sceneSelectionPanel.Initial();
                sceneSelectionPanel.InitButton(
                    () =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                    }, () =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                    });
                break;
            case "学生总结":

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
            case "返回":
                DesTipCtrl.ShowTips("返回", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, 50);
                break;
            case "说明":
                DesTipCtrl.ShowTips("说明", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, 50);
                break;
            case "全屏":
                DesTipCtrl.ShowTips("全屏", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, 50);
                break;
            case "实验报告":
                DesTipCtrl.ShowTips("实验报告", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, 50);
                break;
            case "场景选择":
                DesTipCtrl.ShowTips("场景选择", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, 50);
                break;
            case "学生总结":
                DesTipCtrl.ShowTips("学生总结", eventData.pointerEnter.transform.localPosition, Anchor.Bottom, 50);
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DesTipCtrl.HideTips();
    }

    public void OnClickFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
