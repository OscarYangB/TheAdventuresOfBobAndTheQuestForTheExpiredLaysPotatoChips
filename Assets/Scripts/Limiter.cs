using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limiter : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }


}
