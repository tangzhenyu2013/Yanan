using System;
using System.Collections.Generic;
[Serializable]
public class MusicData
{
    public string 乐器 ;
    public string 资源路径 ;
    public string 歌词 ;
    public string 音乐;
}
[Serializable]
public class MusicCollection
{
    /// <summary>
    /// Context
    /// </summary>
    public List<MusicData> context ;
}
