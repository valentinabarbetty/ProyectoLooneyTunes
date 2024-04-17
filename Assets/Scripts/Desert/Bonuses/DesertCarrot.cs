using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesertCarrot : MonoBehaviour
{
    public Transform carrot1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoverZanahorias();

    }

     void MoverZanahorias()
    {
        Transform[] zanahorias = { carrot1};
        foreach (Transform zanahoria in zanahorias)
        {
            Vector3 position = zanahoria.position;
            position.y += Mathf.Cos(Time.time) * 3.5f * Time.deltaTime;
            zanahoria.position = position;
        }
    }
}
