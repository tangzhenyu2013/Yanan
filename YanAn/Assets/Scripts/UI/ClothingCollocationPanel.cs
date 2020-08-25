using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothingCollocationPanel : BasePanel
{
    public Button[] buttons;
    public GameObject[] select;
    public GameObject Tips;
    private int index;
    private const int correctIndex = 1;

    public override void Initial(params object[] objs)
    {
        ResetObjs();
    }

    public void OnClickClothing(int index)
    {
        this.index = index;
        SetSelectState(index);
    }

    public void OnClickOk()
    {
        if (index == correctIndex)
        {
            //选择正确 进入下一段剧情
            GameManager.GetInstance.AssessmentManager.isEnterYanggeju = true;
            GameManager.GetInstance.AssessmentManager.ExecutionCallYanggejuTheAssessment();
            GameManager.GetInstance.UIPanelManager.CloseBasePanel();

            EmojiManagementPanel emojiManagementPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.emojiManagementPanelPath) as EmojiManagementPanel;
            emojiManagementPanel.Initial();
        }
        else
        {
            Tips.SetActive(true);
        }
    }

    private void ResetObjs()
    {
        Tips.SetActive(false);

        for (int i = 0; i < select.Length; i++)
        {
            select[i].SetActive(false);
        }
    }

    private void SetSelectState(int index)
    {
        for (int i = 0; i < select.Length; i++)
        {
            select[i].SetActive(index == i);
        }
    }
}
