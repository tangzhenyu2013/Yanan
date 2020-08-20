using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
/// <summary>
/// 题库
/// </summary>
public class QuestionData
{
    public string 问题;
    public string 选项A;
    public string 选项B;
    public string 选项C;
    public string 选项D;
    public string 提示;
    public string 答案;
    public int input;
}
[Serializable]
public class QuestionCollection
{
    public List<QuestionData> context;
}

