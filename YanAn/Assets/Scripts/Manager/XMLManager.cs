using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMLManager
{
    /// <summary>
    /// 提示
    /// </summary>
    DesXml desXml;
    /// <summary>
    /// 提示内容
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public List<XmlData> GetDesXMLData()
    {
        if (null == desXml)
        {
            desXml = new DesXml();
        }
        return desXml.m_xmldata;
    }
}
