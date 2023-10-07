using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimit : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private int targetFrameRate = 3;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  
        Application.targetFrameRate = targetFrameRate;
    }
}
