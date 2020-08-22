using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ExperReportPanel : BasePanel
{
    public Button ok;
    public override void Initial(params object[] objs)
    {

    }

    public void InitButton(UnityAction unityAction)
    {
        ok.onClick.RemoveAllListeners();
        ok.onClick.AddListener(unityAction);
    }
}
