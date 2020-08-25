using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmojiManagement : MonoBehaviour
{
    /// <summary>
    /// 鼓掌
    /// </summary>
    public GameObject clapObj;
    /// <summary>
    /// 疑问
    /// </summary>
    public GameObject doubtObj;

    private void Awake()
    {
        SetHise();
    }

    private void OnEnable()
    {
        GameManager.GetInstance.AssessmentManager.CallEmojiManagement += CallEmojiManagement;
    }

    private void OnDisable()
    {
        GameManager.GetInstance.AssessmentManager.CallEmojiManagement -= CallEmojiManagement;
    }
    /// <summary>
    /// 设置男主角状态 2f后隐藏表情
    /// </summary>
    /// <param name="state"></param>
    public void CallEmojiManagement(bool state)
    {
        clapObj.SetActive(state);
        doubtObj.SetActive(!state);
        CancelInvoke("SetHise");
        Invoke("SetHise", 2f);
    }

    public void SetHise()
    {
        clapObj.SetActive(false);
        doubtObj.SetActive(false);
    }
}
