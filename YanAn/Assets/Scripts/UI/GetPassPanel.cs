using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetPassPanel : BasePanel
{
    public Button button;
    public override void Initial(params object[] objs)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
            TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
            tipsPanel.Initial("提示", "是否选择进入延安干部学院虚拟场景");
            tipsPanel.InitButton(
                () =>
                {
                    GameManager.LoadScene("文学院");
                },
                () =>
                {
                    GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                    MapPanel.GetInstance.btn.SetActive(true);
                }
                );
        });
    }
}
