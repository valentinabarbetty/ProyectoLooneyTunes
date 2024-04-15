using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertWile : MonoBehaviour
{
    public Transform WhileTransform;
    private float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = WhileTransform.position;
  
        if (position.x >= -2.0f && position.x < 2.0f && position.y == 0.0f)
        {
            position.x += Time.deltaTime * speed;
        }
        else if (position.x > 0.0f && position.y >= 0.0f)
        {
            position.x -= Time.deltaTime * speed;
            position.y += Time.deltaTime * speed;
        }
        else if (position.x > -2.0f && position.y >= 0.0f)
        {
            position.x -= Time.deltaTime * speed;
            position.y -= Time.deltaTime * speed;
        }
        else
        {
            position.x = -2.0f;
            position.y = 0.0f;
        }

        WhileTransform.position = position;
    }
}
