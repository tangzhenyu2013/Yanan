using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonManager
{
    /// <summary>
    /// 题库
    /// </summary>
    private QuestionCollection questionCollection;

    public QuestionCollection QuestionCollection
    {
        get
        {
            if (null == questionCollection)
            {
                questionCollection = new QuestionCollection();
                TextAsset text = Resources.Load<TextAsset>(JsonConfig.QuestionPath);
                JsonUtility.FromJsonOverwrite(text.text, questionCollection);
            }
            return questionCollection;
        }

    }
    /// <summary>
    /// 地名
    /// </summary>
    private PointCollection pointCollection;

    public PointCollection PointCollection
    {
        get
        {
            if (null == pointCollection)
            {
                pointCollection = new PointCollection();
                TextAsset text = Resources.Load<TextAsset>(JsonConfig.PointPath);
                JsonUtility.FromJsonOverwrite(text.text, pointCollection);
            }
            return pointCollection;
        }
    }
    /// <summary>
    /// 书籍
    /// </summary>
    private BookCollection bookCollection;

    public BookCollection BookCollection
    {
        get
        {
            if (null == bookCollection)
            {
                bookCollection = new BookCollection();
                TextAsset text = Resources.Load<TextAsset>(JsonConfig.BookPath);
                JsonUtility.FromJsonOverwrite(text.text, bookCollection);
            }
            return bookCollection;
        }
    }

    private MusicCollection musicCollection;
    public MusicCollection MusicCollection
    {
        get
        {
            if (null == musicCollection)
            {
                musicCollection = new MusicCollection();
                TextAsset text = Resources.Load<TextAsset>(JsonConfig.MusicPath);
                JsonUtility.FromJsonOverwrite(text.text, musicCollection);
            }
            return musicCollection;
        }
    }
}
