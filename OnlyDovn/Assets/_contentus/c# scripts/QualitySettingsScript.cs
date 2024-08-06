using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySettingsScript : MonoBehaviour
{

    public void OnQualitySet(int ind)
    {
        QualitySettings.SetQualityLevel(ind);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
