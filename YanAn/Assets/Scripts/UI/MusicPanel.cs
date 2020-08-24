using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicPanel : BasePanel
{
    public GameObject[] gameObjects;
    public RectTransform rectTransform;
    public GameObject MusicDetail;
    public Text lyrics;
    public Text musicName;
    //public Scrollbar scrollbar;

    private Dictionary<string, List<MusicData>> keyValuePairs;
    private List<MusicData> musicDatas;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void InitMap()
    {
        if (null == keyValuePairs)
        {
            keyValuePairs = new Dictionary<string, List<MusicData>>();
            List<MusicData> musicDatas = GameManager.GetInstance.JsonManager.MusicCollection.context;
            for (int i = 0; i < musicDatas.Count; i++)
            {
                if (!keyValuePairs.ContainsKey(musicDatas[i].乐器))
                {
                    List<MusicData> temp = new List<MusicData>();
                    temp.Add(musicDatas[i]);
                    keyValuePairs.Add(musicDatas[i].乐器, temp);
                }
                else
                {
                    keyValuePairs[musicDatas[i].乐器].Add(musicDatas[i]);
                }
            }
        }
    }

    public override void Initial(params object[] objs)
    {
        InitMap();
        ResetButton();
        string musicName = objs[0].ToString();
        musicDatas = keyValuePairs[musicName];
        for (int i = 0; i < musicDatas.Count; i++)
        {
            if (i < gameObjects.Length)
            {
                gameObjects[i].SetActive(true);
                gameObjects[i].GetComponentInChildren<Text>().text = musicDatas[i].音乐;
            }
            else
            {
                break;
            }
        }
        if (musicDatas.Count > 5)
        {
            rectTransform.offsetMin = new Vector2(0, (musicDatas.Count - 5) * -50);
        }
    }

    private void ResetButton()
    {
        MusicDetail.SetActive(false);
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].gameObject.SetActive(false);
        }
    }

    private int lastIndex = -1;

    public void OnClickMusic(int index)
    {
        MusicDetail.SetActive(true);
        if (lastIndex == index)
            return;
        //scrollbar.value = 1f;
        musicName.text = "《" + musicDatas[index].音乐 + "》" + "歌词";
        lyrics.text = musicDatas[index].歌词;
        audioClip = Resources.Load<AudioClip>(musicDatas[index].资源路径);
        audioSource.clip = audioClip;
        audioSource.Play();
        lastIndex = index;
    }

    public void CloseMusicDetail()
    {
        MusicDetail.SetActive(false);
    }

    public void OnClickPlayOrPause()
    {
        if (audioSource != null)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
            else
            {
                audioSource.Play();
            }
        }
    }

    public void ClosePanel()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        lastIndex = -1;
        GameManager.GetInstance.UIPanelManager.CloseBasePanel();
    }
}
