using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    uint numEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnemy()
    {
        numEnemies++;
    }
    public void RemoveEnemy()
    {
        numEnemies--;
        if (numEnemies == 0)
        {

        }
    }
}
