using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionItem : MonoBehaviour
{
    /// <summary>
    /// 问题
    /// </summary>
    public Text problem;
    /// <summary>
    /// 选项
    /// </summary>
    public Toggle[] toggles;
    public Text A;
    public Text B;
    public Text C;
    public Text D;

    private QuestionData questionData;
    private void OnEnable()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].onValueChanged.AddListener(CallOnValueChanged);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].onValueChanged.RemoveAllListeners();
        }
    }

    public void Initial(QuestionData _questionData)
    {
        questionData = _questionData;
        problem.text = questionData.问题;
        A.text = questionData.选项A;
        B.text = questionData.选项B;
        C.text = questionData.选项C;
        D.text = questionData.选项D;
        ResetToggles();
        if (!string.IsNullOrEmpty(questionData.input))
        {
            toggles[GetToggleIndex(questionData.input)].isOn = true;
        }
    }

    private int GetToggleIndex(string str)
    {
        int index = 0;
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

    private void ResetToggles()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            toggles[i].isOn = false;
        }
    }

    private void CallOnValueChanged(bool value)
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn)
            {
                questionData.input = toggles[i].name;
            }
        }
    }
}
