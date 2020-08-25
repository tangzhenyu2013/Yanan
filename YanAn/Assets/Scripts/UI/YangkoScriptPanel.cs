using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class YangkoScriptPanel : BasePanel
{
    public Text text;
    public Button button;
    public override void Initial(params object[] objs)
    {

    }

    public void InitButton(UnityAction unityAction)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(unityAction);
    }
}
