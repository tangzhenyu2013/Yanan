using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AssessmentManager
{
    public event UnityAction CallCompleteTheAssessment;

    public void ExecutionCallCompleteTheAssessment()
    {
        CallCompleteTheAssessment?.Invoke();
    }

    public bool isReadVideo;

    public bool isReadBook;

    public bool isCompleteTheAssessment;

    public int assessmentPoint;
}


