using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class VideoPlay : BasePanel
{
    //obj.SetActive(false)该方法使用后再显示时会占用消耗大量内存，
    //因此我们可以使用将obj移出屏幕或移入屏幕的方法来替代显示与隐藏obj
    //定义一个移出屏幕外的坐标位置（无限远处）
    //static Vector3 FAR_AWAY = new Vector3(10000, 10000, 10000);
    //定义一个坐标原点位置（将全部按钮放在同一个空的父GameObject下，并设置该物体的初始位置为坐标原点，方便移回）
    //static Vector3 ZERO_POS = new Vector3(0, 0, 0);
    public Text videoTimeText;          // 视频的时间 Text
    public Text videoNameText;          // 视频的名字 Text
    public Slider videoTimeSlider;      // 视频的时间 Slider
    public Slider videoVoiceSlider;      // 视频的时间 Slider
    private int currentHour;
    private int currentMinute;
    private int currentSecond;
    private int clipHour;
    private int clipMinute;
    private int clipSecond;
    public RawImage vp_RawImage;
    public VideoPlayer vp_Player;
    public AudioSource VideoAudio;//视频音量
    private float fVol;
    //public VideoPlayer Video;
    public static string VideofoldPath = "";//加载视频地址
    public GameObject PlayCtrlObj;
    public Image image;
    public Sprite play;
    public Sprite pause;
    private int iTimer;
    private int iTimerCount = 60 * 10;
    private bool bShow = false;
    public bool isChangeTime;
    // Use this for initialization
    //void Start()
    //{
    //HideObj(PlayCtrlObj);
    //Init();
    //}

    //void Init()
    //{
    //    fVol = (float)1.0;
    //    //Video.url = GetFilePath("", "1", ".MP4");//默认视频地址
    //    //vp_Player.url = Video.url;
    //    vp_Player.url = GetFilePath("", "Test", ".MP4");
    //    videoNameText.text = "刷丝袜";
    //    vp_Player.Play();
    //    vp_Player.started += Started;
    //}
    /// <summary>
    /// 计算视频时长
    /// </summary>
    /// <param name="source"></param>
    private void Started(VideoPlayer source)
    {
        clipHour = (int)((float)vp_Player.frameCount / (float)vp_Player.frameRate / (float)3600);
        clipMinute = (int)((float)vp_Player.frameCount / (float)vp_Player.frameRate - (float)clipHour * (float)3600) / 60;
        clipSecond = (int)((float)vp_Player.frameCount / (float)vp_Player.frameRate - (float)clipHour * (float)3600 - (float)clipMinute * (float)60);
    }
    void ShowVideoTime()
    {
        // 当前的视频播放时间
        currentHour = (int)vp_Player.time / 3600;
        currentMinute = (int)(vp_Player.time - currentHour * 3600) / 60;
        currentSecond = (int)(vp_Player.time - currentHour * 3600 - currentMinute * 60);
        // 把当前视频播放的时间显示在 Text 上
        videoTimeText.text = string.Format("{0:D2}:{1:D2}:{2:D2} / {3:D2}:{4:D2}:{5:D2}",
            currentHour, currentMinute, currentSecond, clipHour, clipMinute, clipSecond);
        // 把当前视频播放的音量比例赋值到 Slider 上
        videoVoiceSlider.value = VideoAudio.volume;
        if (isChangeTime) return;
        // 把当前视频播放的时间比例赋值到 Slider 上
        videoTimeSlider.value = (float)vp_Player.frame / (float)vp_Player.frameCount;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            bShow = true;
            iTimer = 0;
        }

        //Show_Hide();

        if (vp_Player.isPlaying)
        {
            vp_RawImage.texture = vp_Player.texture;
            ShowVideoTime();
        }

        image.sprite = vp_Player.isPlaying ? play : pause;
    }

    //void Show_Hide()//是否显示控制条
    //{
    //    if (bShow)
    //    {
    //        ShowObj(PlayCtrlObj);

    //        iTimer++;
    //        if (iTimer >= iTimerCount)
    //        {
    //            iTimer = 0;
    //            HideObj(PlayCtrlObj);
    //            bShow = false;
    //        }
    //    }
    //}
    public void VideoPlayCtrl(int _iWhich)
    {
        switch (_iWhich)
        {
            case 0:
                if (vp_Player.isPlaying)
                {
                    vp_Player.Pause();
                }
                else
                {
                    vp_Player.Play();
                }
                break;
            case 1:
                vp_Player.Pause();
                break;
            case 2:
                videoTimeSlider.value = 0;
                vp_Player.Stop();
                break;
            case 3:
                fVol += (float)0.1;
                if (fVol >= (float)1.0)
                {
                    fVol = (float)1.0;
                }
                VideoAudio.volume = fVol;
                break;
            case 4:
                fVol -= (float)0.1;
                if (fVol <= (float)0.0)
                {
                    fVol = (float)0.0;
                }
                VideoAudio.volume = fVol;
                break;
            default:
                break;
        }
    }

    public void SetVideoTimeValueChange()
    {
        vp_Player.time = videoTimeSlider.value * vp_Player.frameCount / vp_Player.frameRate;
    }

    public void SetVideoVoiceValueChange()
    {
        VideoAudio.volume = fVol = videoVoiceSlider.value;
    }

    //public void ChangeVideo()//替换视频
    //{
    //    OpenFileDialog ofd = new OpenFileDialog();
    //    ofd.InitialDirectory = "file://" + UnityEngine.Application.dataPath;
    //    if (ofd.ShowDialog() == DialogResult.OK)
    //    {
    //        VideoPlay.VideofoldPath = ofd.FileName;
    //        Debug.Log(VideoPlay.VideofoldPath);
    //        Video.url = "file://" + VideofoldPath;
    //        vp_Player.url = Video.url;
    //        vp_Player.Play();
    //    }
    //}

    string GetFilePath(string foldPath, string fileName, string fileFormat)//
    {
        string filePath;
#if UNITY_IPHONE
                if (!string.IsNullOrEmpty(foldPath))
                {
                    filePath=Application.dataPath + "/Raw/"+foldPath+"/"+fileName+fileFormat;
                }
                else
                {
                    filePath=Application.dataPath + "/Raw/"+fileName+fileFormat;
                }
#elif UNITY_ANDROID
                if (!string.IsNullOrEmpty(foldPath))
                {
                    filePath="jar:file://" + Application.dataPath + "!/assets/"+foldPath+"/"+fileName+fileFormat;
                }
                else
                {
                    filePath="jar:file://" + Application.dataPath + "!/assets/"+fileName+fileFormat;
                }
#endif
        //if (!string.IsNullOrEmpty(foldPath))
        //{
        //    filePath = UnityEngine.Application.dataPath + "/StreamingAssets/" + foldPath + "/" + fileName + fileFormat;
        //}
        //else
        //{
        //    filePath = UnityEngine.Application.dataPath + "/StreamingAssets/" + fileName + fileFormat;
        //}
        filePath = UnityEngine.Application.streamingAssetsPath + "/" + fileName + fileFormat;
        return filePath;
    }

    public override void Initial(params object[] objs)
    {
        fVol = (float)1.0;
        //Video.url = GetFilePath("", "1", ".MP4");//默认视频地址
        //vp_Player.url = Video.url;
        string vedioNmae = objs[0].ToString();
        string name = objs[1].ToString();
        vp_Player.url = GetFilePath("", name, ".MP4");
        videoNameText.text = vedioNmae;
        vp_Player.Play();
        vp_Player.started += Started;
    }
    //void ShowObj(GameObject _obj)
    //{
    //    _obj.transform.position = ZERO_POS;
    //}

    //void HideObj(GameObject _obj)
    //{
    //    _obj.transform.position = FAR_AWAY;
    //}

    public void OnDisable()
    {
        GameManager.GetInstance.AssessmentManager.isReadVideo = true;
        GameManager.GetInstance.AssessmentManager.ExecutionCallCompleteTheAssessment();
    }
}
