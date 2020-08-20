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
}
