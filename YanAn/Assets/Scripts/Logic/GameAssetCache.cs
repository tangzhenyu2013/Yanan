using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetCache
{

    static string tipsParentPath = "UIParent";
    static string tipsParent3DPath = "UIParent3D";
    static string tipsObjPath = "Prefab/TipsObj";
    static string tipsObj3DPath = "Prefab/TipsObj3D";

    public static string videoPanelPath = "Prefab/VideoPanel";
    public static string desPanePath = "Prefab/DesPanel";
    public static string dialogPath = "Prefab/Dialog";
    public static string tipsPanelPath = "Prefab/TipsPanel";
    public static string getPassPanelPath = "Prefab/GetPassPanel";
    public static string experReportPanelPath = "Prefab/ExperReportPanel";
    public static string sceneSelectionPanelPath = "Prefab/SceneSelectionPanel";
    public static string phonePanelPath = "Prefab/PhonePanel";
    public static string bookPanelPath = "Prefab/BookPanel";
    public static string bookLearnPanelPath = "Prefab/bookLearnPanel";
    public static string assessmentPanelPath = "Prefab/AssessmentPanel";
    public static string studentMedalPanelPath = "Prefab/StudentMedalPanel";
    public static string musicPanelPath = "Prefab/MusicPanel";
    public static string xintianyouPanelPath = "Prefab/XintianyouPanel";
    public static string clothingCollocationPanelPath = "Prefab/ClothingCollocationPanel";
    public static string emojiManagementPanelPath = "Prefab/EmojiManagementPanel";
    public static string selectPanelPath = "Prefab/SelectPanel";
    public static string yangkoScriptPanelPath = "Prefab/YangkoScriptPanel";
    public static string proofPanelPath = "Prefab/ProofPanel";
    public static string studentSummaryPanelPath = "Prefab/StudentSummaryPanel";
    
    private static GameObject uiParent;
    public static GameObject UIParent
    {
        get
        {
            if (null == uiParent)
                uiParent = GameObject.Find(tipsParentPath);
            return uiParent;
        }
    }
    private static GameObject tipsObj;
    public static GameObject TipsObj
    {
        get
        {
            if (null == tipsObj)
            {
                GameObject obj = Resources.Load(tipsObjPath) as GameObject;
                tipsObj = Object.Instantiate(obj, UIParent.transform);
            }
            return tipsObj;
        }
    }

    private static GameObject uiParent3D;
    public static GameObject UIParent3D
    {
        get
        {
            if (null == uiParent3D)
                uiParent3D = GameObject.Find(tipsParent3DPath);
            return uiParent3D;
        }
    }

    private static GameObject tipsObj3D;

    public static GameObject TipsObj3D
    {
        get
        {
            if (null == tipsObj3D)
            {
                GameObject obj = Resources.Load(tipsObj3DPath) as GameObject;
                tipsObj3D = Object.Instantiate(obj, UIParent3D.transform);
            }
            return tipsObj3D;
        }
    }
}
