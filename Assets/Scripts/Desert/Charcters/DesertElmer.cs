using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertElmer : MonoBehaviour
{
    public Transform ElmerTransform;
    private float speed = 1.0f; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = ElmerTransform.position;

        position.x += Mathf.Cos(Time.time) * Time.deltaTime * speed * 2;
        position.z += Mathf.Sin(Time.time) * Time.deltaTime * speed * 2;

        ElmerTransform.position = position;

    }
}
