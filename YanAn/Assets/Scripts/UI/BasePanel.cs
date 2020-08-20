using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    /// <summary>
    /// 初始化
    /// </summary>
    public abstract void Initial(params object[] objs);
}
