using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGame : MonoBehaviour
{
    public Button button;

    private void Awake()
    {
        button.onClick.AddListener(Begin);
    }

    public void Begin()
    {
        GameManager.LoadScene("教室");
    }
}
