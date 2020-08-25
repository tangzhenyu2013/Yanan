using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SliderEvent : MonoBehaviour, IBeginDragHandler, IPointerDownHandler,IPointerUpHandler, IEndDragHandler
{
    [SerializeField]
    private VideoPlayPanel toPlayVideo;        // 视频播放的脚本

    public void OnBeginDrag(PointerEventData eventData)
    {
        toPlayVideo.isChangeTime = true;
        SetVideoTimeValueChange();
        toPlayVideo.vp_Player.Pause();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        toPlayVideo.isChangeTime = false;
        SetVideoTimeValueChange();
        toPlayVideo.vp_Player.Play();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        toPlayVideo.isChangeTime = true;
        SetVideoTimeValueChange();
        toPlayVideo.vp_Player.Pause();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        toPlayVideo.isChangeTime = false;
        SetVideoTimeValueChange();
        toPlayVideo.vp_Player.Play();
    }

    /// <summary>
    /// 当前的 Slider 比例值转换为当前的视频播放时间
    /// </summary>
    private void SetVideoTimeValueChange()
    {
        toPlayVideo.vp_Player.time = toPlayVideo.videoTimeSlider.value * (float)toPlayVideo.vp_Player.frameCount / toPlayVideo.vp_Player.frameRate;
    }
}
