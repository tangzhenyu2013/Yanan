using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum Anchor
{
    Left,
    Right,
    Top,
    Bottom,
}
public class DesTipCtrl
{
    public static void ShowTips(string str, Vector3 vector3, Anchor anchor, float offset)
    {
        GameAssetCache.TipsObj.SetActive(true);
        Text text = GameAssetCache.TipsObj.GetComponentInChildren<Text>();
        text.text = str;
        switch (anchor)
        {
            case Anchor.Left:
                GameAssetCache.TipsObj.transform.localPosition = new Vector3(vector3.x - offset, vector3.y);
                break;
            case Anchor.Right:
                GameAssetCache.TipsObj.transform.localPosition = new Vector3(vector3.x + offset, vector3.y);
                break;
            case Anchor.Top:
                GameAssetCache.TipsObj.transform.localPosition = new Vector3(vector3.x, vector3.y - offset);
                break;
            case Anchor.Bottom:
                GameAssetCache.TipsObj.transform.localPosition = new Vector3(vector3.x, vector3.y + offset);
                break;
            default:
                break;
        }
    }

    public static void HideTips()
    {
        GameAssetCache.TipsObj.SetActive(false);
    }
}
