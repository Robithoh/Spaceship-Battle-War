using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSine : MonoBehaviour
{
    float sinCenterY;
    public float amplitude = 2;
    public float frequency = 2;

    public bool inverted = false;
    // Start is called before the first frame update
    void Start()
    {
        sinCenterY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sine = Mathf.Sin(pos.x * frequency) * amplitude;  
        pos.y = sinCenterY + sine;
        if (inverted)
        {
            sine *= -1;
        }

        transform.position = pos;
    }
}
