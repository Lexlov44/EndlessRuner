using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsBackgroundMove : MonoBehaviour
{
    private int speed;

    void Start()
    {
        speed = GameObject.Find("Walls").GetComponent<BckgroundGenerator>().speedObjects;

    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

}
