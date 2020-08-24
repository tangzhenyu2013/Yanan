using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XintianyouPanel : BasePanel
{
    public InputField inputField;

    public Text prompt;

    public override void Initial(params object[] objs)
    {
        //刷新提示点
        RefreshAssessmentPoint();
    }
    /// <summary>
    /// 提示
    /// </summary>
    public void OnClickPrompt()
    {
        if (GameManager.GetInstance.AssessmentManager.assessmentPoint <= 0) return;
        GameManager.GetInstance.AssessmentManager.assessmentPoint--;
        RefreshAssessmentPoint();
        TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
        tipsPanel.Initial("提示", "好好看看 好好写写  小心你毕不了业！");
        tipsPanel.InitButton(() =>
        {
            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
        }, "确定");
    }
    private void RefreshAssessmentPoint()
    {
        Helper.SetText("提示:" + GameManager.GetInstance.AssessmentManager.assessmentPoint, prompt);
    }
    /// <summary>
    /// 作品提交
    /// </summary>
    public void OnClickOK()
    {

    }
}
