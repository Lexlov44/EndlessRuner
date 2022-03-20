using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroer : MonoBehaviour
{
    private GameObject Disabler;

    void Start()
    {
        Disabler = GameObject.Find("Disabler");
    }

    void Update()
    {
        if (transform.position.x < Disabler.transform.position.x)
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);

        }
    }
}
