using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooksDisabler : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < GameObject.Find("PointDisabledPlatform").transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }

}
