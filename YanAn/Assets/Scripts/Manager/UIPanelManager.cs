using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelManager
{
    public Dictionary<string, BasePanel> keyValuePairs = new Dictionary<string, BasePanel>();
    public Stack<BasePanel> basePanels = new Stack<BasePanel>();
    public BasePanel OpenPanel(string path)
    {
        BasePanel basePanel;
        if (!keyValuePairs.ContainsKey(path))
        {
            basePanel = Resources.Load<BasePanel>(path);
            basePanel = GameObject.Instantiate(basePanel,GameAssetCache.TipsParent.transform);
            basePanel.transform.localPosition = Vector3.zero;
            basePanels.Push(basePanel);
            keyValuePairs.Add(path, basePanel);
        }
        else
        {
            basePanel = keyValuePairs[path];
            basePanels.Push(basePanel);
        }
        basePanel.gameObject.SetActive(true);
        return basePanel;
    }

    public void CloseBasePanel()
    {
        BasePanel basePanel =  basePanels.Pop();
        basePanel.gameObject.SetActive(false);
    }
}
