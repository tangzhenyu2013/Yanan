using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProofPanel : VideoPlayPanel
{
    /// <summary>
    /// 证据图片
    /// </summary>
    public Image proofImage;
    /// <summary> 
    /// 证据卡片
    /// </summary>
    public Text card;
    /// <summary>
    /// 描述1
    /// </summary>
    public Text des1;
    /// <summary>
    /// 描述2
    /// </summary>
    public Text des2;

    public override void Initial(params object[] objs)
    {
        base.Initial(objs);
        proofImage.sprite = objs[2] as Sprite;
        card.text = objs[3].ToString();
        des1.text = objs[4].ToString();
        des2.text = objs[5].ToString();
    }
}
