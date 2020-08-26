using System;
using UnityEngine;
using HighlightingSystem;

namespace HighlightingSystem.Demo
{
    public class HighlighterInteractionDemo : MonoBehaviour
    {
        // Hover color
        public Color hoverColor = Color.red;

        public Sprite card1;
        public Sprite card2;
        public Sprite card3;
        // Button names (for Input Manager)
        static private readonly string buttonFire1 = "Fire1";
        //static private readonly string buttonFire2 = "Fire2";
        // 
        void Update()
        {
            //ProcessControls();
        }

        // RaycastController should trigger this method via onHover event
        public void OnHover(RaycastHit hitInfo)
        {
            //如果有打开的界面 不可以点击三维物体
            if (GameManager.GetInstance.UIPanelManager.GetIsShowPanel())
            {
                return;
            }

            Transform tr = hitInfo.collider.transform;
            if (tr == null) { return; }

            if (tr.name == "Solt1" && GameManager.GetInstance.AssessmentManager.isEndDrag)
            {
                GameManager.GetInstance.AssessmentManager.ExecutionCallSetSlotCard("Solt1");
                GameManager.GetInstance.AssessmentManager.isEndDrag = false;
                return;
            }

            if (tr.name == "Solt2" && GameManager.GetInstance.AssessmentManager.isEndDrag)
            {
                GameManager.GetInstance.AssessmentManager.ExecutionCallSetSlotCard("Solt2");
                GameManager.GetInstance.AssessmentManager.isEndDrag = false;
                return;
            }

            if (tr.name == "Solt3" && GameManager.GetInstance.AssessmentManager.isEndDrag)
            {
                GameManager.GetInstance.AssessmentManager.ExecutionCallSetSlotCard("Solt3");
                GameManager.GetInstance.AssessmentManager.isEndDrag = false;
                return;
            }
            var highlighter = tr.GetComponentInParent<Highlighter>();
            if (highlighter == null) { return; }

            // Hover
            highlighter.Hover(hoverColor);

            // Switch tween
            if (Input.GetButtonDown(buttonFire1))
            {
                #region 书籍相关
                if (hitInfo.transform.name == "book")
                {
                    PhonePanel bookPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.bookPanelPath) as PhonePanel;
                    bookPanel.Initial();
                }
                if (hitInfo.transform.name == "book1")
                {
                    PhonePanel bookPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.bookPanelPath) as PhonePanel;
                    bookPanel.Initial();
                }
                if (hitInfo.transform.name == "book2")
                {
                    PhonePanel bookPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.bookPanelPath) as PhonePanel;
                    bookPanel.Initial();
                }
                #endregion
                #region 图片相关
                if (hitInfo.transform.name == "phone")
                {
                    PhonePanel phonePanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.phonePanelPath) as PhonePanel;
                    phonePanel.Initial();
                }

                if (hitInfo.transform.name == "phone1")
                {
                    PhonePanel phonePanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.phonePanelPath) as PhonePanel;
                    phonePanel.Initial();
                }

                if (hitInfo.transform.name == "phone2")
                {
                    PhonePanel phonePanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.phonePanelPath) as PhonePanel;
                    phonePanel.Initial();
                }

                if (hitInfo.transform.name == "phone3")
                {
                    PhonePanel phonePanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.phonePanelPath) as PhonePanel;
                    phonePanel.Initial();
                }
                #endregion
                #region 证据卡片
                if (hitInfo.transform.name == "proof1")
                {
                    ProofPanel proofPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.proofPanelPath) as ProofPanel;
                    proofPanel.Initial(string.Empty, "Test", card1, "获得白毛女证据卡片1", "新浪娱乐讯 据企查查，郑爽前男友张恒担任法人的“上海鲸乖乖人工智能科技有限公司”因未按时履行法律义务8月25日被法院强制执行，执行标的为一万，该公司实际控制人及受益人是郑爽。除此之外，张恒关联的风险共有19条， 因劳动合同纠纷被起诉的开庭公告和送达公告有18条，案由都是劳动合同纠纷，拖欠六名员工工资、补偿金、加班车费报销等。"
                        , "新浪娱乐讯 据企查查，郑爽前男友张恒担任法人的“上海鲸乖乖人工智能科技有限公司”因未按时履行法律义务8月25日被法院强制执行，执行标的为一万，该公司实际控制人及受益人是郑爽。除此之外，张恒关联的风险共有19条， 因劳动合同纠纷被起诉的开庭公告和送达公告有18条，案由都是劳动合同纠纷，拖欠六名员工工资、");
                    if (GameManager.GetInstance.AssessmentManager.crads.Contains(card1)) return;
                    proofPanel.InitButton(() =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                        GameManager.GetInstance.AssessmentManager.crads.Add(card1);
                        GameManager.GetInstance.AssessmentManager.ExecutionCallGetBaiMaoNvCard();
                    });
                }

                if (hitInfo.transform.name == "proof2")
                {
                    ProofPanel proofPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.proofPanelPath) as ProofPanel;
                    proofPanel.Initial(string.Empty, "Test", card2, "获得白毛女证据卡片2", "新浪娱乐讯 据企查查，郑爽前男友张恒担任法人的“上海鲸乖乖人工智能科技有限公司”因未按时履行法律义务8月25日被法院强制执行，执行标的为一万，该公司实际控制人及受益人是郑爽。除此之外，张恒关联的风险共有19条， 因劳动合同纠纷被起诉的开庭公告和送达公告有18条，案由都是劳动合同纠纷，拖欠六名员工工资、补偿金、加班车费报销等。"
                  , "新浪娱乐讯 据企查查，郑爽前男友张恒担任法人的“上海鲸乖乖人工智能科技有限公司”因未按时履行法律义务8月25日被法院强制执行，执行标的为一万，该公司实际控制人及受益人是郑爽。除此之外，张恒关联的风险共有19条， 因劳动合同纠纷被起诉的开庭公告和送达公告有18条，案由都是劳动合同纠纷，拖欠六名员工工资、");
                    if (GameManager.GetInstance.AssessmentManager.crads.Contains(card2)) return;
                    proofPanel.InitButton(() =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                        GameManager.GetInstance.AssessmentManager.crads.Add(card2);
                        GameManager.GetInstance.AssessmentManager.ExecutionCallGetBaiMaoNvCard();
                    });
                }

                if (hitInfo.transform.name == "proof3")
                {
                    ProofPanel proofPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.proofPanelPath) as ProofPanel;
                    proofPanel.Initial(string.Empty, "Test", card3, "获得白毛女证据卡片3", "新浪娱乐讯 据企查查，郑爽前男友张恒担任法人的“上海鲸乖乖人工智能科技有限公司”因未按时履行法律义务8月25日被法院强制执行，执行标的为一万，该公司实际控制人及受益人是郑爽。除此之外，张恒关联的风险共有19条， 因劳动合同纠纷被起诉的开庭公告和送达公告有18条，案由都是劳动合同纠纷，拖欠六名员工工资、补偿金、加班车费报销等。"
                   , "新浪娱乐讯 据企查查，郑爽前男友张恒担任法人的“上海鲸乖乖人工智能科技有限公司”因未按时履行法律义务8月25日被法院强制执行，执行标的为一万，该公司实际控制人及受益人是郑爽。除此之外，张恒关联的风险共有19条， 因劳动合同纠纷被起诉的开庭公告和送达公告有18条，案由都是劳动合同纠纷，拖欠六名员工工资、");
                    if (GameManager.GetInstance.AssessmentManager.crads.Contains(card3)) return;
                    proofPanel.InitButton(() =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                        GameManager.GetInstance.AssessmentManager.crads.Add(card3);
                        GameManager.GetInstance.AssessmentManager.ExecutionCallGetBaiMaoNvCard();
                    });
                }
                #endregion
                #region 视频相关
                if (hitInfo.transform.name == "vedio")
                {
                    VideoPlayPanel videoPlay = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.videoPanelPath) as VideoPlayPanel;
                    videoPlay.Initial("搞笑网络视频", "Test");
                }
                #endregion
                #region 3D翻页图书
                if (hitInfo.transform.name == "book3d")
                {
                    BookLearnPanel bookLearnPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.bookLearnPanelPath) as BookLearnPanel;
                    bookLearnPanel.Initial();
                }
                #endregion
                #region 乐器相关
                if (hitInfo.transform.name == "gu")
                {
                    MusicPanel musicPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.musicPanelPath) as MusicPanel;
                    musicPanel.Initial("鼓");
                }
                #endregion
                #region 信天游创作
                if (hitInfo.transform.name == "xintianyou")
                {
                    XintianyouPanel xintianyouPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.xintianyouPanelPath) as XintianyouPanel;
                    xintianyouPanel.Initial();
                }
                #endregion
                #region 解救喜儿
                if (hitInfo.transform.name == "baimaonv")
                {
                    //尚未完成卡片收集
                    if (!GameManager.GetInstance.AssessmentManager.isCompltetCollectCards)
                        return;
                    //证据已收集完成
                    if (GameManager.GetInstance.AssessmentManager.isAccusehuangshiren)
                        return;
                    VideoPlayPanel videoPlay = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.videoPanelPath) as VideoPlayPanel;
                    videoPlay.Initial("解救喜儿视频", "Test");
                    videoPlay.InitButton(() =>
                    {
                        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                        TipsPanel tipsPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.tipsPanelPath) as TipsPanel;
                        tipsPanel.Initial("恭喜", "恭喜您，集齐指控黄世仁的证据，喜儿已被就出，现在可以去扣押黄世仁");
                        tipsPanel.InitButton(() =>
                        {
                            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
                            GameManager.GetInstance.AssessmentManager.isAccusehuangshiren = true;
                            GameManager.GetInstance.AssessmentManager.ExecutionCallAccusehuangshiren();
                        }, "确定");
                    });
                }
                #endregion
                #region 指控黄世仁
                if (hitInfo.transform.name == "huangshiren")
                {

                }
                #endregion
                //highlighter.tween = !highlighter.tween;
            }

            // Toggle overlay
            //if (Input.GetButtonUp(buttonFire2))
            //{
            //	highlighter.overlay = !highlighter.overlay;
            //}
        }

        // 
        private void ProcessControls()
        {
            // Fade in/out constant highlighting
            if (Input.GetKeyDown(KeyCode.Alpha1)) { TriggerAll(0); }
            // Turn on/off constant highlighting
            if (Input.GetKeyDown(KeyCode.Alpha2)) { TriggerAll(1); }
            // Turn off all highlighting modes
            if (Input.GetKeyDown(KeyCode.Alpha3)) { TriggerAll(2); }
        }

        // 
        private void TriggerAll(int action)
        {
            var highlighters = HighlighterCore.highlighters;
            for (int i = 0; i < highlighters.Count; i++)
            {
                var highlighter = highlighters[i] as Highlighter;
                if (highlighter != null)
                {
                    switch (action)
                    {
                        case 0:
                            highlighter.ConstantSwitch();
                            break;
                        case 1:
                            highlighter.ConstantSwitchImmediate();
                            break;
                        case 2:
                            highlighter.Off();
                            break;
                    }
                }
            }
        }
    }
}