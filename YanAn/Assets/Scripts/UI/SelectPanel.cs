using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPanel : BasePanel
{
    OperaData operaData;

    public Text[] texts;

    bool isTrue;

    public override void Initial(params object[] objs)
    {
        operaData = objs[0] as OperaData;
        texts[0].text = operaData.选项A;
        texts[1].text = operaData.选项B;
        texts[2].text = operaData.选项C;
        texts[3].text = operaData.选项D;

        isTrue = false;
    }

    public void OnClickSelect(string options)
    {
        if (operaData.正确答案.Equals(options))
        {
            isTrue = true;
            GameManager.GetInstance.AssessmentManager.ExecutionCallEmojiManagement(true);
        }
        else
        {
            isTrue = false;
            GameManager.GetInstance.AssessmentManager.ExecutionCallEmojiManagement(false);
        }
    }

    public void Next()
    {
        if (!isTrue) return;
        EmojiManagementPanel emojiManagementPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.emojiManagementPanelPath) as EmojiManagementPanel;
        emojiManagementPanel.ShowDialogue();
    }
}
