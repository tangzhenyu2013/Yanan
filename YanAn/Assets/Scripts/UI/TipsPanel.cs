using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TipsPanel : BasePanel
{
    public Text title;
    public Text des;
    public Button ok;
    public Button cancel;
    public override void Initial(params object[] objs)
    {
        Helper.SetText(objs[0], title);
        Helper.SetText(objs[1], des);
    }

    public void InitButton(UnityAction ok, UnityAction cancel)
    {
        ResetButton();
        this.ok.onClick.AddListener(ok);
        this.cancel.onClick.AddListener(cancel);
    }

    private void ResetButton()
    {
        ok.onClick.RemoveAllListeners();
        cancel.onClick.RemoveAllListeners();
    }
}
