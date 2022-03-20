using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablerBackgroundItems : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < GameObject.Find("BackgroundItemsDisabler").transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
