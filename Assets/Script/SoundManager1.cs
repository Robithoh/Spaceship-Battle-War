using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager1 : MonoBehaviour
{
    private static SoundManager1 instance = null;
    public GameObject player;
    public AudioClip deadSound;
    private AudioSource source;
    public static SoundManager1 Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void deadsound()
    {
        source.PlayOneShot(deadSound);
    }
}
