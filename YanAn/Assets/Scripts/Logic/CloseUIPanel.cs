using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUIPanel : MonoBehaviour
{
    private void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(
            () =>
            {
                GameManager.GetInstance.UIPanelManager.CloseBasePanel();
            }
            );
    }
}
