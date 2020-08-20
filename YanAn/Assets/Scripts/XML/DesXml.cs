using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;
public class XmlData
{
    public int id;
    public string tips;
}
public class DesXml
{
    public DesXml()
    {
        LoadXMLFlie("Data/Tips","item","id","tips");
    }
    //定义一个链表，该链表存放了xml的数据
    public List<XmlData> m_xmldata = new List<XmlData>();
    /// <summary>
    /// 加载xml表
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="nodeRoot">父节点</param>
    /// <param name="node1">子节点1</param>
    /// <param name="node2">子节点2</param>
    public void LoadXMLFlie(string path, string nodeRoot, string node1, string node2)
    {
        //new出一个XmlDocument
        XmlDocument xmlDoc = new XmlDocument();

        #region 方法1 保守写法
        //这个就是加载你的XML表的内容
        TextAsset xmlAsset = (TextAsset)Resources.Load(path);
        //由于编码问题，要设置编码方式
        byte[] encodeString = Encoding.UTF8.GetBytes(xmlAsset.text);
        //以流的形式来读取
        MemoryStream ms = new MemoryStream(encodeString);
        xmlDoc.Load(ms);
        #endregion

        # region 方法二 简单偷懒写法
        //xmlDoc.LoadXml(path);
        #endregion

        //获取XML表中的父节点
        XmlNode root = xmlDoc.SelectSingleNode(nodeRoot);

        //在父节点中遍历循环一下子节点
        foreach (XmlElement element in root.ChildNodes)
        {
            XmlData data = new XmlData();
            XmlNode node_order = element.SelectSingleNode(node1);
            // InnerText就相当于节点中的内容,也就是节点1的内容   
            data.id = int.Parse(node_order.InnerText);
            XmlNode node_content = element.SelectSingleNode(node2);
            // InnerText就相当于节点中的内容,也就是节点2的内容    
            data.tips = node_content.InnerText;
            //我们把它加入到链表中
            m_xmldata.Add(data);
            //关闭流  
            ms.Close();
        }
    }
}
