using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactChecking : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "xintianyou":

                break;
            case "baimaonv":

                break;
            case "yanggequ":

                break;
            case "taicipaiyan":

                break;
            default:
                break;
        }
    }
}
