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
    public Text okText;
    public Text cancelText;
    public override void Initial(params object[] objs)
    {
        Helper.SetText(objs[0], title);
        Helper.SetText(objs[1], des);
    }

    public void InitButton(UnityAction ok, UnityAction cancel, string okStr, string cancelStr)
    {
        okText.text = okStr;
        cancelText.text = cancelStr;
        this.cancel.gameObject.SetActive(true);
        this.ok.onClick.RemoveAllListeners();
        this.cancel.onClick.RemoveAllListeners();
        this.ok.onClick.AddListener(ok);
        this.cancel.onClick.AddListener(cancel);
        this.ok.transform.localPosition = new Vector3(250f, 57f, 0f);
        this.cancel.transform.localPosition = new Vector3(-250f, 57f, 0f);
    }

    public void InitButton(UnityAction ok, string okStr)
    {
        okText.text = okStr;
        this.cancel.gameObject.SetActive(false);
        this.ok.onClick.RemoveAllListeners();
        this.ok.onClick.AddListener(ok);
        this.ok.transform.localPosition = new Vector3(0f, 57f, 0f);
    }
}
