using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BckgroundGenerator : MonoBehaviour
{
    public GameObject Wall;

    public int speedObjects;

    public Sprite[] PoolSprites;

    private List<GameObject> Walls;


    void Start()
    {
        Walls = new List<GameObject>();

        CreateWalls();
    }

    private void CreateWalls()
    {
        float xPotision = transform.position.x;
        for (int i = 0; i < PoolSprites.Length; i++)
        {
            GameObject newObj = (GameObject)Instantiate(Wall);
            newObj.transform.position = new Vector3(xPotision, gameObject.transform.position.y, gameObject.transform.position.z);
            xPotision = xPotision + newObj.GetComponent<SpriteRenderer>().bounds.size.x;
            newObj.GetComponent<SpriteRenderer>().sprite = RandomWall();
            Walls.Add(newObj);
            Walls[i].transform.SetParent(gameObject.transform);
        }
    }

    public Sprite RandomWall()
    {
        return GameObject.Find("Walls").GetComponent<BckgroundGenerator>().PoolSprites[UnityEngine.Random.Range(0, PoolSprites.Length)];
    }
}
