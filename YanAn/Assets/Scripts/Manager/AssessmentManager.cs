using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssessmentManager
{
    /// <summary>
    /// 是否阅读了视频
    /// </summary>
    public bool isReadVideo;
    /// <summary>
    /// 是否阅读了书籍
    /// </summary>
    public bool isReadBook;
    /// <summary>
    /// 是否完成了考核
    /// </summary>
    public bool isCompleteTheAssessment;
    /// <summary>
    /// 提示点
    /// </summary>
    public int assessmentPoint;
    /// <summary>
    /// 是否进入秧歌曲
    /// </summary>
    public bool isEnterYanggeju;
    /// <summary>
    /// 是否创作 信天游
    /// </summary>
    public bool isCreationXintianyou;
    /// <summary>
    /// 是否完成秧歌剧
    /// </summary>
    public bool isCompleteYangko;

    public event UnityAction CallCompleteTheAssessment;

    public void ExecutionCallCompleteTheAssessment()
    {
        CallCompleteTheAssessment?.Invoke();
    }

    public event UnityAction CallYanggejuTheAssessment;

    public void ExecutionCallYanggejuTheAssessment()
    {
        CallYanggejuTheAssessment?.Invoke();
    }

    public event UnityAction<bool> CallEmojiManagement;

    public void ExecutionCallEmojiManagement(bool state)
    {
        CallEmojiManagement?.Invoke(state);
    }

    public event UnityAction CallartistMedal;

    public void ExecutionCallCallartistMedal()
    {
        CallartistMedal?.Invoke();
    }
}



