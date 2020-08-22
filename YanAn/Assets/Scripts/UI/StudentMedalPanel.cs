using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StudentMedalPanel : BasePanel
{
    public Text title;

    public Text des;

    public Button button;

    public Text buttonText;

    public override void Initial(params object[] objs)
    {
        Helper.SetText(objs[0], title);
        Helper.SetText(objs[1], des);
    }

    public void InitButton(UnityAction unityAction, string str)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(unityAction);
        Helper.SetText(str, buttonText);
    }
}
