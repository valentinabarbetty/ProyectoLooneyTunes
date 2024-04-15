using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertSam : MonoBehaviour
{
    public Transform SamTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = SamTransform.position;
        position.x += Mathf.Cos(Time.time) * Time.deltaTime * 2;
        SamTransform.position = position;
    }
}
