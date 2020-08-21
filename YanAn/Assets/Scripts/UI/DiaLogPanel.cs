using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class DiaLogPanel : BasePanel
{
    public Button button;
    public Text des;
    public override void Initial(params object[] objs)
    {
        Helper.SetText(objs[0].ToString(), des);
    }

    public void InitButton(UnityAction unityAction)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(unityAction);
    }
}
