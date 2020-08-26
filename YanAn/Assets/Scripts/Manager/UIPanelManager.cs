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
            basePanel = GameObject.Instantiate(basePanel, GameAssetCache.UIParent.transform);
            GameObject mask = Resources.Load<GameObject>("Prefab/Mask");
            //增加个遮罩  防止界面互相影响点击事件
            mask = GameObject.Instantiate(mask, basePanel.transform);
            mask.transform.SetAsFirstSibling();
            basePanels.Push(basePanel);
            keyValuePairs.Add(path, basePanel);
        }
        else
        {
            basePanel = keyValuePairs[path];
            if (!basePanels.Contains(basePanel))
                basePanels.Push(basePanel);
        }
        basePanel.gameObject.SetActive(true);
        //设置为最后一个 提高渲染优先级
        basePanel.transform.SetAsLastSibling();
        return basePanel;
    }

    public void CloseAllPanel()
    {
        while (basePanels.Count > 0)
        {
            BasePanel basePanel = basePanels.Pop();
            basePanel.gameObject.SetActive(false);
        }
    }

    public void CloseBasePanel()
    {
        if (basePanels.Count < 1)
            return;
        BasePanel basePanel = basePanels.Pop();
        basePanel.gameObject.SetActive(false);
    }

    public bool GetIsShowPanel()
    {
        return basePanels.Count > 0;
    }

    public void Reset()
    {
        keyValuePairs.Clear();
        basePanels.Clear();
    }
}
