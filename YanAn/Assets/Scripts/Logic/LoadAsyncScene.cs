using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadAsyncScene : MonoBehaviour
{
    /// <summary>
    /// 进度文本
    /// </summary>
    [SerializeField] private Text proText;
    /// <summary>
    /// 描述文本
    /// </summary>
    [SerializeField] private Text desText;
    /// <summary>
    /// 当前进度
    /// </summary>
    int currentProgress;
    /// <summary>
    /// 目标进度
    /// </summary>
    int targetProgress;

    List<XmlData> xmlDatas;
    private void Start()
    {
        StartCoroutine(LoadingScene()); //开启协成
        xmlDatas = GameManager.XMLManager.GetDesXMLData();
        if (null == xmlDatas) xmlDatas = new List<XmlData>();
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <returns>协成</returns>
    private IEnumerator LoadingScene()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(GameManager.NextScene);
        asyncOperation.allowSceneActivation = false;
        while (asyncOperation.progress < 0.9f)
        {
            targetProgress = (int)(asyncOperation.progress * 100);
            yield return LoadProgress();
        }
        targetProgress = 100;
        yield return LoadProgress();
        asyncOperation.allowSceneActivation = true;
    }

    private IEnumerator<WaitForEndOfFrame> LoadProgress()
    {
        while (currentProgress < targetProgress)
        {
            if (currentProgress % 50 == 0)
            {
                desText.text = GetDes();
            }
            ++currentProgress;
            Helper.SetText(currentProgress + "%", proText);
            yield return new WaitForEndOfFrame();
        }
    }

    private string GetDes()
    {
        XmlData xmlData = xmlDatas[0];
        if (xmlDatas.Count > 1)
        {
            xmlDatas.Remove(xmlDatas[0]);
        }
        return xmlData.tips;
    }
}
