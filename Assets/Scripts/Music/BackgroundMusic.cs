using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic music;
 
    void Awake()
    {
        if (music != null)
            Destroy(gameObject);
        else
        {
            music = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
 