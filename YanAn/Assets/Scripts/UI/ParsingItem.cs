using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ParsingItem : MonoBehaviour
{
    /// <summary>
    /// 问题
    /// </summary>
    public Text problem;
    /// <summary>
    /// 提示
    /// </summary>
    public Text des;
    /// <summary>
    /// 选项
    /// </summary>
    public Toggle[] toggles;
    public Text A;
    public Text B;
    public Text C;
    public Text D;

    public void Initial(QuestionData _questionData)
    {
        ResetColor();
        problem.text = _questionData.问题;
        A.text = _questionData.选项A;
        B.text = _questionData.选项B;
        C.text = _questionData.选项C;
        D.text = _questionData.选项D;
        des.text = _questionData.提示;
        //没有回答
        if (null == _questionData.input)
        {
            //正确答案
            int index2 = GetToggleIndex(_questionData.答案);
            toggles[index2].isOn = true;
            GetTextIndex(_questionData.答案).color = Color.green;
            problem.color = Color.red;
            return;
        }

        //是否回答正确
        bool isAnswer = _questionData.input.Contains(_questionData.答案);
        if (isAnswer)
        {
            //你的回答
            int index1 = GetToggleIndex(_questionData.input);

            toggles[index1].isOn = true;

            GetTextIndex(_questionData.答案).color = Color.green;

            problem.color = Color.green;
        }
        else
        {
            //你的回答
            int index1 = GetToggleIndex(_questionData.input);
            //正确答案
            int index2 = GetToggleIndex(_questionData.答案);

            toggles[index1].isOn = true;

            toggles[index2].isOn = true;

            GetTextIndex(_questionData.input).color = Color.red;

            GetTextIndex(_questionData.答案).color = Color.green;

            problem.color = Color.red;
        }
    }

    private void ResetColor()
    {
        problem.color = Color.white;
        A.color = Color.white;
        B.color = Color.white;
        C.color = Color.white;
        D.color = Color.white;
    }
    private Text GetTextIndex(string str)
    {
        switch (str)
        {
            case "A":
                return A;
            case "B":
                return B;
            case "C":
                return C;
            case "D":
                return D;
            default:
                break;
        }
        return A;
    }

    private int GetToggleIndex(string str)
    {
        int index = -1;
        switch (str)
        {
            case "A":
                index = 0;
                break;
            case "B":
                index = 1;
                break;
            case "C":
                index = 2;
                break;
            case "D":
                index = 3;
                break;
            default:
                break;
        }
        return index;
    }
}
