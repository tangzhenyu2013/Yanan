using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiManagementPanel : BasePanel
{
    Queue<OperaData> operaDatas;

    public override void Initial(params object[] objs)
    {
        if (null == operaDatas)
            operaDatas = new Queue<OperaData>();
        else
            operaDatas.Clear();

        List<OperaData> datas = GameManager.GetInstance.JsonManager.OperaCollection.context;
        for (int i = 0; i < datas.Count; i++)
        {
            operaDatas.Enqueue(datas[i]);
        }
        ShowDialogue();
    }

    public void ShowDialogue()
    {
        GameManager.GetInstance.UIPanelManager.CloseAllPanel();

        if (operaDatas.Count == 0)
        {
            YangkoScriptPanel yangkoScript = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.yangkoScriptPanelPath) as YangkoScriptPanel;
            yangkoScript.InitButton(
                () =>
                {
                    GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                    VideoPlayPanel videoPlay = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.videoPanelPath) as VideoPlayPanel;
                    videoPlay.Initial("搞笑网络视频", "Test");
                    videoPlay.InitButton(() =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                        GameManager.GetInstance.AssessmentManager.isCompleteYangko = true;
                        GameManager.GetInstance.AssessmentManager.ExecutionCallCallartistMedal();
                    });
                }
                );
            return;
        }

        OperaData operaData = operaDatas.Dequeue();
        DiaLogPanel diaLogPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.dialogPath) as DiaLogPanel;
        diaLogPanel.Initial(operaData.男主问题);
        diaLogPanel.InitButton(() =>
        {
            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
            SelectPanel selectPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.selectPanelPath) as SelectPanel;
            selectPanel.Initial(operaData);
        });
    }
}
