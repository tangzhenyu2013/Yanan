using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : MonoBehaviour
{
    public PointItem[] pointItems;
    // Start is called before the first frame update
    void Start()
    {
        PointCollection pointCollection = GameManager.GetInstance.JsonManager.PointCollection;

        if (pointCollection != null)
        {
            List<PointData> pointDatas = pointCollection.context;

            if (pointItems.Length < pointDatas.Count) return;

            for (int i = 0; i < pointDatas.Count; i++)
            {
                pointItems[i].Initial(pointDatas[i]);
            }
        }
    }
}
