using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class SceneSelectionPanel : BasePanel
{
    public SceneSelectionItem[] sceneSelectionItems;
    public Button close;
    public Button ok;
    public override void Initial(params object[] objs)
    {
        ResetItems();
        sceneSelectionItems[0].RefrehItem(true, ResetItems);
        for (int i = 1; i < sceneSelectionItems.Length; i++)
        {
            sceneSelectionItems[i].RefrehItem(GameManager.GetInstance.AssessmentManager.isCompleteTheAssessment, ResetItems);
        }
    }

    public void InitButton(UnityAction close, UnityAction ok)
    {
        this.close.onClick.RemoveAllListeners();
        this.ok.onClick.RemoveAllListeners();
        this.close.onClick.AddListener(close);
        this.ok.onClick.AddListener(ok);
    }

    private void ResetItems()
    {
        for (int i = 0; i < sceneSelectionItems.Length; i++)
        {
            sceneSelectionItems[i].selectOb.SetActive(false);
        }
    }
}
