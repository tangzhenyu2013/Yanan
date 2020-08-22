using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssessmentPanel : BasePanel
{
    public GameObject parentObj;
    public GameObject promptObj;
    public GameObject selectObj;
    public GameObject MasterObj;
    public QuestionItem[] questionItems;
    public GameObject up;
    public GameObject down;
    public GameObject upParsing;
    public GameObject downParsing;
    public List<QuestionData> questionDatas;
    public InputField inputField;
    public Text prompt;

    public ParsingItem[] parsingItems;

    private int curPage;
    private int MaxPage;
    public override void Initial(params object[] objs)
    {
        parentObj.SetActive(true);
        promptObj.SetActive(false);
        selectObj.SetActive(true);
        MasterObj.SetActive(false);
        curPage = 0;
        questionDatas = GameManager.GetInstance.JsonManager.QuestionCollection.context;
        if (questionDatas.Count % 5 == 0)
        {
            MaxPage = questionDatas.Count / 5;
        }
        if (questionDatas.Count % 5 != 0)
        {
            MaxPage = questionDatas.Count / 5 + 1;
        }
        RefreshList();
        RefreshAssessmentPoint();
    }

    private void RefreshList()
    {
        ResetList();
        int index = 0;
        for (int i = curPage * 5; i < questionDatas.Count; i++)
        {
            if (i < questionDatas.Count && index < questionItems.Length)
            {
                questionItems[index].gameObject.SetActive(true);
                questionItems[index].Initial(questionDatas[i]);
                index++;
            }
        }
        RefreshBtn();
    }

    private void ResetList()
    {
        for (int i = 0; i < questionItems.Length; i++)
        {
            questionItems[i].gameObject.SetActive(false);
        }
    }

    public void OnClickUp()
    {
        if (curPage <= 0) return;
        curPage--;
        RefreshList();
    }

    public void OnClickDown()
    {
        if (curPage > MaxPage) return;
        curPage++;
        RefreshList();
    }

    private void RefreshBtn()
    {
        up.SetActive(curPage > 0);
        down.SetActive(curPage < MaxPage - 1);
    }

    public void OnClickSelect()
    {
        selectObj.SetActive(true);
        MasterObj.SetActive(false);
    }

    public void OnClickMaster()
    {
        selectObj.SetActive(false);
        MasterObj.SetActive(true);
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
    /// 提交
    /// </summary>
    public void OnClickSubmit()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
            tipsPanel.Initial("提示", "主观题尚未完成，是否要提交");
            tipsPanel.InitButton(() =>
            {
                       GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                OpenpRomptObj();
            }, () =>
            {
                GameManager.GetInstance.UIPanelManager.CloseBasePanel();
            }, "提交", "做主观题");
        }
        else
        {
            OpenpRomptObj();
        }
    }

    private void OpenpRomptObj()
    {
        parentObj.SetActive(false);
        promptObj.SetActive(true);
        curPage = 0;
        if (questionDatas.Count % 3 == 0)
        {
            MaxPage = questionDatas.Count / 3;
        }
        if (questionDatas.Count % 3 != 0)
        {
            MaxPage = questionDatas.Count / 3 + 1;
        }
        RefreshParsingItems();
    }

    public void OnClickRomptUp()
    {
        if (curPage <= 0) return;
        curPage--;
        RefreshParsingItems();
    }

    public void OnClickRomptDown()
    {
        if (curPage > MaxPage) return;
        curPage++;
        RefreshParsingItems();
    }

    private void RefreshParsingItems()
    {
        ResetParsingItems();
        int index = 0;
        for (int i = curPage * 3; i < questionDatas.Count; i++)
        {
            if (i < questionDatas.Count && index < parsingItems.Length)
            {
                parsingItems[index].gameObject.SetActive(true);
                parsingItems[index].Initial(questionDatas[i]);
                index++;
            }
        }
        RefreshParsingBtn();
    }

    private void RefreshParsingBtn()
    {
        upParsing.SetActive(curPage > 0);
        downParsing.SetActive(curPage < MaxPage - 1);
    }

    private void ResetParsingItems()
    {
        for (int i = 0; i < parsingItems.Length; i++)
        {
            parsingItems[i].gameObject.SetActive(false);
        }
    }

    public void ExitPanel()
    {
        //考核完成
        GameManager.GetInstance.AssessmentManager.isCompleteTheAssessment = true;
        GameManager.GetInstance.AssessmentManager.ExecutionCallCompleteTheAssessment();

        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
        StudentMedalPanel studentMedalPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.studentMedalPanelPath) as StudentMedalPanel;
        studentMedalPanel.Initial("学员奖章", @"恭喜您，完成延安民族干部学院场景学习任务，获得此证
可前往鲁艺文学院场景探索");
        studentMedalPanel.InitButton(() =>
        {
            GameManager.GetInstance.AssessmentManager.assessmentPoint += 2;
            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
        }, "确定");
    }
}
