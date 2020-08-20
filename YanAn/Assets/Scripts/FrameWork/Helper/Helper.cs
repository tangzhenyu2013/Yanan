using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public static class Helper
{
    public static void SetText(object str, Text text)
    {
        if (text != null)
        {
            text.text = str.ToString();
        }
    }
}
