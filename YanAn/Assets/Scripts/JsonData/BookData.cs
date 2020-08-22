using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BookData
{
    public string 页码 ;
    public string 内容 ;
}

[Serializable]
public class BookCollection
{
    public List<BookData> context ;
}
