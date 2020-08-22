using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollegePanel :MonoBehaviour
{ 
    public Button assessmentBtn;
    public GameObject airWall;
    private void OnEnable()
    {
        GameManager.GetInstance.AssessmentManager.CallCompleteTheAssessment += RefreshButton;
        RefreshButton();
    }

    private void OnDisable()
    {
        GameManager.GetInstance.AssessmentManager.CallCompleteTheAssessment -= RefreshButton;
    }

    private void Start()
    {
        airWall.SetActive(!GameManager.GetInstance.AssessmentManager.isCompleteTheAssessment);
        assessmentBtn.onClick.AddListener(
            () =>
            {
                AssessmentPanel assessmentPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.assessmentPanelPath) as AssessmentPanel;
                assessmentPanel.Initial();
            });
        ShowOperTips();
    }

    private void ShowOperTips()
    {
        TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
        tipsPanel.Initial("操作说明", "使用W,A,S,D键操作人物");
        tipsPanel.InitButton(() =>
        {
            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
        }, "确定");
    }

    public void RefreshButton()
    {
        if (GameManager.GetInstance.AssessmentManager.isCompleteTheAssessment)
        {
            airWall.SetActive(false);
            assessmentBtn.gameObject.SetActive(false);
            return;
        }
        assessmentBtn.gameObject.SetActive(
            GameManager.GetInstance.AssessmentManager.isReadBook &&
            GameManager.GetInstance.AssessmentManager.isReadVideo);
    }
}
