using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetCache
{
    static string tipsParentPath = "UIParent";
    static string tipsParent3DPath = "UIParent3D";
    static string tipsObjPath = "Prefab/TipsObj";
    static string tipsObj3DPath = "Prefab/TipsObj3D";

    public static string desPanePath = "Prefab/DesPanel";

    private static GameObject tipsParent;
    public static GameObject TipsParent
    {
        get
        {
            if (null == tipsParent)
                tipsParent = GameObject.Find(tipsParentPath);
            return tipsParent;
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
                tipsObj = Object.Instantiate(obj, TipsParent.transform);
            }
            return tipsObj;
        }
    }

    private static GameObject tipsParent3D;
    public static GameObject TipsParent3D
    {
        get
        {
            if (null == tipsParent3D)
                tipsParent3D = GameObject.Find(tipsParent3DPath);
            return tipsParent3D;
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
                tipsObj3D = Object.Instantiate(obj, TipsParent3D.transform);
            }
            return tipsObj3D;
        }
    }
}
