using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
    public float timer = 0.0f;
    public VideoPlayer videoComplete;
    public GameObject buttons;
    // Start is called before the first frame update

     void Awake()
    {
        
    }
    void videoPause()
    {
        videoComplete.Pause();
    }
    void Start()
    {
        buttons.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 6)
        {
            videoPause();
        }
        if (timer >= 5.5f)
        {
            buttons.SetActive(true);
        }
    }
}
