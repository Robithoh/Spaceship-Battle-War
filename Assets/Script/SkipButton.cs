using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipButton : MonoBehaviour
{
    public string leveltoload;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey
            )
        {
            SceneManager.LoadScene(leveltoload);
        }
    }

    
}
