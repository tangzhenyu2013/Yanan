using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class SceneSelectionPanel : BasePanel
{
    public Button close;
    public Button ok;
    public override void Initial(params object[] objs)
    {

    }

    public void InitButton(UnityAction close,UnityAction ok)
    {
        this.close.onClick.RemoveAllListeners();
        this.ok.onClick.RemoveAllListeners();
        this.close.onClick.AddListener(close);
        this.ok.onClick.AddListener(ok);
    }
}
