using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
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
    /// 是否进入秧歌剧
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
    /// <summary>
    /// 是否进入白毛女
    /// </summary>
    public bool isEnterBaimaonv;
    /// <summary>
    /// 是否完成卡片收集
    /// </summary>
    public bool isCompltetCollectCards;
    /// <summary>
    /// 是否可以指控黄世仁
    /// </summary>
    public bool isAccusehuangshiren;
    /// <summary>
    /// 是否扣押黄世仁
    /// </summary>
    public bool isSeizehuangshiren;
    /// <summary>
    /// 当前拖拽证据卡片
    /// </summary>
    public Sprite dragSprite;
    /// <summary>
    /// 是否结束拖拽
    /// </summary>
    public bool isEndDrag = false;
    /// <summary>
    /// 是否获得学员奖章
    /// </summary>
    public bool isGetCollege;
    /// <summary>
    /// 是否获得文艺工作者奖章
    /// </summary>
    public bool isGetArt;
    /// <summary>
    /// 是否获得基层工作者奖章
    /// </summary>
    public bool isGetBase;
    /// <summary>
    /// 收集的卡片列表
    /// </summary>
    public List<Sprite> crads = new List<Sprite>();
    /// <summary>
    /// 已使用的卡片列表
    /// </summary>
    public Dictionary<string, Sprite> useCrads = new Dictionary<string, Sprite>();

    public void AddUseCrad(string cradname)
    {
        if (null == cradname) return;
        if (!useCrads.ContainsKey(cradname))
        {
            useCrads.Add(cradname, dragSprite);
        }
    }

    public Sprite GetUseCrad(string cradname)
    {
        if (null == cradname) return null;
        if (useCrads.ContainsKey(cradname))
        {
            return useCrads[cradname];
        }
        return null;
    }
    /// <summary>
    /// 干部学院 考核完成 委托事件
    /// </summary>
    public event UnityAction CallCompleteTheAssessment;

    public void ExecutionCallCompleteTheAssessment()
    {
        CallCompleteTheAssessment?.Invoke();
    }
    /// <summary>
    /// 文学院 进入秧歌剧 剧委托事件
    /// </summary>
    public event UnityAction CallYanggejuTheAssessment;

    public void ExecutionCallYanggejuTheAssessment()
    {
        CallYanggejuTheAssessment?.Invoke();
    }
    /// <summary>
    /// 文学院对台词 表情展示 委托事件
    /// </summary>
    public event UnityAction<bool> CallEmojiManagement;

    public void ExecutionCallEmojiManagement(bool state)
    {
        CallEmojiManagement?.Invoke(state);
    }
    /// <summary>
    /// 文艺工作者奖章 委托事件
    /// </summary>
    public event UnityAction CallartistMedal;

    public void ExecutionCallCallartistMedal()
    {
        CallartistMedal?.Invoke();
    }
    /// <summary>
    /// 文学院 进入白毛女 剧委托事件
    /// </summary>
    public event UnityAction CallBaiMaonvAssessment;

    public void ExecutionCallBaiMaonvAssessment()
    {
        CallBaiMaonvAssessment?.Invoke();
    }

    /// <summary>
    /// 获得白毛女卡片
    /// </summary>
    public event UnityAction CallGetBaiMaoNvCard;

    public void ExecutionCallGetBaiMaoNvCard()
    {
        CallGetBaiMaoNvCard?.Invoke();
    }
    /// <summary>
    /// 指控黄世仁
    /// </summary>
    public event UnityAction CallAccusehuangshiren;

    public void ExecutionCallAccusehuangshiren()
    {
        CallAccusehuangshiren.Invoke();
    }
    /// <summary>
    /// 设置槽位卡片
    /// </summary>
    public event UnityAction<string> CallSetSlotCard;

    public void ExecutionCallSetSlotCard(string str)
    {
        CallSetSlotCard.Invoke(str);
    }
}



