using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(restart());
    }

    IEnumerator restart()
    {
        yield return new WaitForSecondsRealtime(50);
        SceneManager.LoadScene("Menu");
    }
    
}
