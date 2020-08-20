using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesObjPanel : BasePanel
{
    public Button closeBtn;

    public Text des;

    public void Awake()
    {
        closeBtn.onClick.AddListener(() =>
        {
            GameManager.GetInstance.uIPanelManager.CloseBasePanel();
        });
    }
    public override void Initial(params object[] objs)
    {
        des.text = objs[0].ToString();
    }
}
