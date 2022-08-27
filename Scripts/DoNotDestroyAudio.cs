using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyAudio : MonoBehaviour
{
    public void DoNotDestroy()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Button");
        DontDestroyOnLoad(this.gameObject);
    }

}
