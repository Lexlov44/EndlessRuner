using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{

    private int speed;

    private float sizeX;


    void Start()
    {
        speed = GameObject.Find("Walls").GetComponent<BckgroundGenerator>().speedObjects;
        sizeX = gameObject.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.x != 0)
            transform.position += Vector3.left * speed * Time.deltaTime;

        if (GameObject.Find("WallDestroyer").transform.position.x > transform.position.x)
        {
            MoveYourSelf();
        }
    }

    private void MoveYourSelf()
    {
        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        transform.position = new Vector3(transform.position.x + sizeX * GameObject.Find("Walls").GetComponent<BckgroundGenerator>().PoolSprites.Length, transform.position.y, transform.position.z);


        GetComponent<SpriteRenderer>().sprite = GameObject.Find("Walls").GetComponent<BckgroundGenerator>().RandomWall();
    }
}
