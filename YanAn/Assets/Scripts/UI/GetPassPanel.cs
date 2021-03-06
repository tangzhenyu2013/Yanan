﻿using UnityEngine.UI;
public class GetPassPanel : BasePanel
{
    public Button button;
    public override void Initial(params object[] objs)
    {
        GameManager.GetInstance.AssessmentManager.assessmentPoint += 2;

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
                    MapPanel.isLookMap = true;
                    MapPanel.GetInstance.RefreshBtn();
                }, "是的!进入", "不！我再看看"
                );
        });
    }
}
