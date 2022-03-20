using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablerPages : MonoBehaviour
{
    public GameObject particalCollect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            GameObject partislObj = (GameObject)Instantiate(particalCollect);
            partislObj.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);
            gameObject.SetActive(false);
            Destroy(partislObj, .5f);
        }
    }
}
