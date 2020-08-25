using System;
using UnityEngine;
using HighlightingSystem;

namespace HighlightingSystem.Demo
{
    public class HighlighterInteractionDemo : MonoBehaviour
    {
        // Hover color
        public Color hoverColor = Color.red;

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

            var highlighter = tr.GetComponentInParent<Highlighter>();
            if (highlighter == null) { return; }

            // Hover
            highlighter.Hover(hoverColor);

            // Switch tween
            if (Input.GetButtonDown(buttonFire1))
            {
                if (hitInfo.transform.name == "book")
                {
                    PhonePanel bookPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.bookPanelPath) as PhonePanel;
                    bookPanel.Initial();
                }
                if (hitInfo.transform.name == "phone")
                {
                    PhonePanel phonePanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.phonePanelPath) as PhonePanel;
                    phonePanel.Initial();
                }
                if (hitInfo.transform.name == "vedio")
                {
                    VideoPlayPanel videoPlay = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.videoPanelPath) as VideoPlayPanel;
                    videoPlay.Initial("搞笑网络视频", "Test");
                }

                if (hitInfo.transform.name == "book3d")
                {
                    BookLearnPanel bookLearnPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.bookLearnPanelPath) as BookLearnPanel;
                    bookLearnPanel.Initial();
                }

                if (hitInfo.transform.name == "gu")
                {
                    MusicPanel musicPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.musicPanelPath) as MusicPanel;
                    musicPanel.Initial("鼓");
                }

                if (hitInfo.transform.name == "xintianyou")
                {
                    XintianyouPanel xintianyouPanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.xintianyouPanelPath) as XintianyouPanel;
                    xintianyouPanel.Initial();
                }
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