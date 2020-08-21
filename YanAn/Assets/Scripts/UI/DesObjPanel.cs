using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DesObjPanel : BasePanel
{
    public Button btn;

    public Text des;

    public override void Initial(params object[] objs)
    {
        des.text = objs[0].ToString();
    }

    public void InitButton(UnityAction unityAction)
    {
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(() =>
        {
            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
        });
        btn.onClick.AddListener(unityAction);
    }
}
