using HighlightingSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollegePanel : MonoBehaviour
{
    public Button assessmentBtn;
    /// <summary>
    /// 干部学院 与文学院之间的空气墙
    /// </summary>
    public GameObject airWall;
    /// <summary>
    /// 文学院 秧歌剧空气墙
    /// </summary>
    public GameObject yanggejuBox;
    /// <summary>
    /// 文学院 白毛女空气墙
    /// </summary>
    public GameObject baimaonvBox;
    /// <summary>
    /// 文学院 白毛女左下角提示
    /// </summary>
    public GameObject baimaonvTipsObj;
    /// <summary>
    /// 文学院 白毛女右侧卡片收集提示
    /// </summary>
    public GameObject proofObj;
    /// <summary>
    /// 证据卡片
    /// </summary>
    public Image[] card;
    /// <summary>
    /// 是否可以帮助
    /// </summary>
    public GameObject helpObj;
    /// <summary>
    /// 白毛女 高亮
    /// </summary>
    public Highlighter baimaonv;
    /// <summary>
    /// 黄世仁 高亮
    /// </summary>
    public Highlighter huangshiren;
    /// <summary>
    /// 黄世仁证据槽
    /// </summary>
    public GameObject evidenceSlot;
    /// <summary>
    /// 槽位1
    /// </summary>
    public Image solt1;
    /// <summary>
    /// 槽位2
    /// </summary>
    public Image solt2;
    /// <summary>
    /// 槽位3
    /// </summary>
    public Image solt3;
    /// <summary>
    /// 返回班级
    /// </summary>
    public GameObject returnClass;
    private void OnEnable()
    {
        GameManager.GetInstance.AssessmentManager.CallCompleteTheAssessment += RefreshButton;
        GameManager.GetInstance.AssessmentManager.CallYanggejuTheAssessment += RefreshYanggeju;
        GameManager.GetInstance.AssessmentManager.CallartistMedal += CallartistMedal;
        GameManager.GetInstance.AssessmentManager.CallBaiMaonvAssessment += RefreshBaiMaoNvBox;
        GameManager.GetInstance.AssessmentManager.CallGetBaiMaoNvCard += CallGetBaiMaoNvCard;
        GameManager.GetInstance.AssessmentManager.CallAccusehuangshiren += CallAccusehuangshiren;
        GameManager.GetInstance.AssessmentManager.CallSetSlotCard += CallSetSlotCard;

        RefreshButton();
        RefreshYanggeju();
        RefreshBaiMaoNvBox();
        CallAccusehuangshiren();
        CallMedal();
        CallGetBaiMaoNvCard();
        CallSetSlotCard(null);
    }

    private void OnDisable()
    {
        GameManager.GetInstance.AssessmentManager.CallCompleteTheAssessment -= RefreshButton;
        GameManager.GetInstance.AssessmentManager.CallYanggejuTheAssessment -= RefreshYanggeju;
        GameManager.GetInstance.AssessmentManager.CallartistMedal -= CallartistMedal;
        GameManager.GetInstance.AssessmentManager.CallBaiMaonvAssessment -= RefreshBaiMaoNvBox;
        GameManager.GetInstance.AssessmentManager.CallGetBaiMaoNvCard -= CallGetBaiMaoNvCard;
        GameManager.GetInstance.AssessmentManager.CallAccusehuangshiren -= CallAccusehuangshiren;
        GameManager.GetInstance.AssessmentManager.CallSetSlotCard -= CallSetSlotCard;
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
                assessmentPanel.InitExitBtn(() =>
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
                        GameManager.GetInstance.AssessmentManager.isGetCollege = true;
                        CallMedal();
                    }, "确定");
                });
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
    private void RefreshButton()
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
    private void RefreshYanggeju()
    {
        yanggejuBox.SetActive(!GameManager.GetInstance.AssessmentManager.isEnterYanggeju);
    }

    private void CallartistMedal()
    {
        if (GameManager.GetInstance.AssessmentManager.isCreationXintianyou
            && GameManager.GetInstance.AssessmentManager.isCompleteYangko)
        {
            TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
            tipsPanel.Initial("文艺工作者奖章", "恭喜您，完成鲁艺文学院场景创作任务，获得此证，可继续探索");
            tipsPanel.InitButton(() =>
            {
                GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                GameManager.GetInstance.AssessmentManager.isGetArt = true;
                CallMedal();
            }, "确定");
        }
    }

    private void RefreshBaiMaoNvBox()
    {
        baimaonvBox.SetActive(!GameManager.GetInstance.AssessmentManager.isEnterBaimaonv);
        baimaonvTipsObj.SetActive(GameManager.GetInstance.AssessmentManager.isEnterBaimaonv);
        proofObj.SetActive(GameManager.GetInstance.AssessmentManager.isEnterBaimaonv);
    }

    private void CallGetBaiMaoNvCard()
    {
        List<Sprite> sprites = GameManager.GetInstance.AssessmentManager.crads;
        if (sprites.Count == 0) return;
        for (int i = 0; i < sprites.Count; i++)
        {
            card[i].sprite = sprites[i];
        }

        GameManager.GetInstance.AssessmentManager.isCompltetCollectCards = sprites.Count == 3;
        helpObj.SetActive(sprites.Count == 3);
        baimaonv.constant = sprites.Count == 3;
    }

    private void CallAccusehuangshiren()
    {
        huangshiren.constant = GameManager.GetInstance.AssessmentManager.isAccusehuangshiren;
        evidenceSlot.SetActive(GameManager.GetInstance.AssessmentManager.isAccusehuangshiren);
    }

    private void CallSetSlotCard(string str)
    {
        GameManager.GetInstance.AssessmentManager.AddUseCrad(str);

        Sprite sprite = GameManager.GetInstance.AssessmentManager.GetUseCrad("Solt1");
        if (sprite != null)
            solt1.sprite = sprite;

        sprite = GameManager.GetInstance.AssessmentManager.GetUseCrad("Solt2");
        if (sprite != null)
            solt2.sprite = sprite;

        sprite = GameManager.GetInstance.AssessmentManager.GetUseCrad("Solt3");
        if (sprite != null)
            solt3.sprite = sprite;

        if (GameManager.GetInstance.AssessmentManager.isSeizehuangshiren) return;
        //证据卡片收集完成 弹出扣押黄世仁视频
        if (!solt1.sprite.name.Equals("UISprite")
            && !solt2.sprite.name.Equals("UISprite")
            && !solt3.sprite.name.Equals("UISprite"))
        {
            GameManager.GetInstance.AssessmentManager.isSeizehuangshiren = true;
            VideoPlayPanel videoPlay = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.videoPanelPath) as VideoPlayPanel;
            videoPlay.Initial("扣押黄世仁视频", "Test");
            videoPlay.InitButton(() =>
            {
                GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                tipsPanel.Initial("恭喜", "恭喜您，黄世仁因证据确凿被扣押，完成任务");
                tipsPanel.InitButton(() =>
                {
                    GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                    videoPlay = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.videoPanelPath) as VideoPlayPanel;
                    videoPlay.Initial("庆祝视频", "Test");
                    //完成任务 进入考核模式
                    videoPlay.InitButton(() =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                        AssessmentPanel assessmentPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.assessmentPanelPath) as AssessmentPanel;
                        assessmentPanel.Initial();
                        assessmentPanel.InitExitBtn(() =>
                        {

                            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                            tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                            tipsPanel.Initial("基层工作者奖章", @"恭喜您，完成白毛女故事场景任务，获得此证");
                            tipsPanel.InitButton(() =>
                            {
                                GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                                GameManager.GetInstance.AssessmentManager.isGetBase = true;
                                CallMedal();
                            }, "确定");
                        });
                        assessmentPanel.subjectiveBtn.SetActive(false);
                    }, () =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                        AssessmentPanel assessmentPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.assessmentPanelPath) as AssessmentPanel;
                        assessmentPanel.Initial();
                        assessmentPanel.InitExitBtn(() =>
                        {

                            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                            tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                            tipsPanel.Initial("基层工作者奖章", @"恭喜您，完成白毛女故事场景任务，获得此证");
                            tipsPanel.InitButton(() =>
                            {
                                GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                                GameManager.GetInstance.AssessmentManager.isGetBase = true;
                                CallMedal();
                            }, "确定");
                        });
                        assessmentPanel.subjectiveBtn.SetActive(false);
                    });
                }, "确定");
            });
        }
    }

    private void CallMedal()
    {
        returnClass.SetActive(false);
        if (GameManager.GetInstance.AssessmentManager.isGetCollege
            && GameManager.GetInstance.AssessmentManager.isGetArt
            && GameManager.GetInstance.AssessmentManager.isGetBase)
        {
            returnClass.SetActive(true);
            TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
            tipsPanel.Initial("返回现实世界提示", "恭喜您，已经收集三枚印章，可以返回现实世界，请选择");
            tipsPanel.InitButton(() =>
            {
                GameManager.GetInstance.UIPanelManager.CloseAllPanel();
                OnClickReturnClass();
            }, () =>
            {
                GameManager.GetInstance.UIPanelManager.CloseBasePanel();
            }, "返回现实", "再逛逛");
        }
    }

    public void OnClickReturnClass()
    {
        GameManager.LoadScene("教室");
    }
}
