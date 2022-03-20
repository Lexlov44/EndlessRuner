using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLatformDestroer : MonoBehaviour
{
    private GameObject platmorDestructionPoint;

    void Start()
    {
        platmorDestructionPoint = GameObject.Find("PlatmorDestructionPoint");
    }

    void Update()
    {
        if (transform.position.x < platmorDestructionPoint.transform.position.x)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);

        }
    }
}
