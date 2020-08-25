using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollegePanel : MonoBehaviour
{
    public Button assessmentBtn;
    public GameObject airWall;
    public GameObject yanggejuBox;
    private void OnEnable()
    {
        GameManager.GetInstance.AssessmentManager.CallCompleteTheAssessment += RefreshButton;
        GameManager.GetInstance.AssessmentManager.CallYanggejuTheAssessment += RefreshYanggeju;
        GameManager.GetInstance.AssessmentManager.CallartistMedal += CallartistMedal;
        RefreshButton();
    }

    private void OnDisable()
    {
        GameManager.GetInstance.AssessmentManager.CallCompleteTheAssessment -= RefreshButton;
        GameManager.GetInstance.AssessmentManager.CallYanggejuTheAssessment += RefreshYanggeju;
        GameManager.GetInstance.AssessmentManager.CallartistMedal -= CallartistMedal;
    }

    private void Start()
    {
        airWall.SetActive(!GameManager.GetInstance.AssessmentManager.isCompleteTheAssessment);
        yanggejuBox.SetActive(!GameManager.GetInstance.AssessmentManager.isEnterYanggeju);
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
    /// <summary>
    /// 文学院空气墙 和 考核按钮刷新
    /// </summary>
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
    /// <summary>
    /// 秧歌曲 空气墙刷新
    /// </summary>
    public void RefreshYanggeju()
    {
        yanggejuBox.SetActive(!GameManager.GetInstance.AssessmentManager.isEnterYanggeju);
    }

    public void CallartistMedal()
    {
        if (GameManager.GetInstance.AssessmentManager.isCreationXintianyou
            && GameManager.GetInstance.AssessmentManager.isCompleteYangko)
        {
            TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
            tipsPanel.Initial("文艺工作者奖章", "恭喜您，完成鲁艺文学院场景创作任务，获得此证，可继续探索");
            tipsPanel.InitButton(() =>
            {
                GameManager.GetInstance.UIPanelManager.CloseBasePanel();
            }, "确定");
        }
    }
}
