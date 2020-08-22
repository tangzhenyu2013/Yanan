using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookLearnPanel : BasePanel
{
    public Text des1;
    public Text des2;
    public Text pag1;
    public Text pag2;

    private int curIndex;
    private List<BookData> bookDatas;

    private void OnDisable()
    {
        GameManager.GetInstance.AssessmentManager.isReadBook = true;
        GameManager.GetInstance.AssessmentManager.ExecutionCallCompleteTheAssessment();
    }
    public override void Initial(params object[] objs)
    {
        if (null == bookDatas)
        {
            bookDatas = new List<BookData>();
            bookDatas = GameManager.GetInstance.JsonManager.BookCollection.context;
        }
        curIndex = 1;
        RefreshText();
    }

    public void OnClickUp()
    {
        if (curIndex < 3) return;
        curIndex -= 2;
        RefreshText();
    }

    public void OnClickDown()
    {
        if (bookDatas.Count - 1 <= curIndex)
        {
            GameManager.GetInstance.UIPanelManager.CloseBasePanel();
            return;
        }
        curIndex += 2;
        RefreshText();
    }

    private void RefreshText()
    {
        des1.text = bookDatas[curIndex - 1].内容;
        pag1.text = bookDatas[curIndex - 1].页码;
        if (bookDatas.Count <= curIndex)
        {
            des2.text = string.Empty;
            pag2.text = string.Empty;
        }
        else
        {
            des2.text = bookDatas[curIndex].内容;
            pag2.text = bookDatas[curIndex].页码;
        }
    }
}
