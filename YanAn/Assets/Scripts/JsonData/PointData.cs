using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class PointData
{
    /// <summary>
    /// 桂林
    /// </summary>
    public string 地名;
    /// <summary>
    /// 山水甲天下
    /// </summary>
    public string 描述;

    public bool isRead;
}
[Serializable]
public class PointCollection
{
    /// <summary>
    /// Context
    /// </summary>
    public List<PointData> context;
}