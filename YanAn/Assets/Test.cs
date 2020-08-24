using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BasePanel basePanel = GameManager.GetInstance.UIPanelManager.OpenPanel(GameAssetCache.musicPanelPath);
        basePanel.Initial("鼓");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
