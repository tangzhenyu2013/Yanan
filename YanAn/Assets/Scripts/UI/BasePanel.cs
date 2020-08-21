using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour
{
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="objs"></param>
    public abstract void Initial(params object[] objs);
}
