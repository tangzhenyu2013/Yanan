using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssetCache
{
    private static Canvas mainCanvas;
    public static Canvas MainCanvas
    {
        get
        {
            if (null == mainCanvas)
                mainCanvas = GameObject.Find(mainCanvaspath).GetComponent<Canvas>();
            return mainCanvas;
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
                tipsObj = GameObject.Instantiate(obj, MainCanvas.transform);
            }
            mainCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
            return tipsObj;
        }
    }

    static string mainCanvaspath = "Canvas";
    static string tipsObjPath = "Prefab/TipsObj";
}
