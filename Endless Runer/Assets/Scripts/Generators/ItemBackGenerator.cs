using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBackGenerator : MonoBehaviour
{

    public GameObject Window;
    public Sprite[] WindowSprites;
    public GameObject GeneretingPoint;
    public GameObject BackBook;
    public Sprite[] BackBookSprites;

    public int CountItems;
    public float MinYWindows, MaxYWindows;
    public float MinYBooks, MaxYBooks;
    public float MaxRange;

    private List<GameObject> Windows;
    private List<GameObject> BackBooks;

    private GameObject ParentWindows, ParentBooks;

    void Start()
    {
        ParentWindows = new GameObject();
        ParentWindows.transform.name = "Windows";
        ParentWindows.transform.SetParent(GameObject.Find("Walls").transform);

        ParentBooks = new GameObject();
        ParentBooks.transform.name = "Books";
        ParentBooks.transform.SetParent(GameObject.Find("Walls").transform);

        Windows = new List<GameObject>();
        BackBooks = new List<GameObject>();

        CreateObjs();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < GeneretingPoint.transform.position.x)
        {
            CreateItem();
        }
    }

    private void CreateItem()
    {
            /*for (int i = 0; i < Windows.Count; i++)
            {
                if (!Windows[i].activeInHierarchy)
                {
                    Windows[i].transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(MinYWindows, MaxYWindows), transform.position.z);
                    Windows[i].SetActive(true);

                    JumpBetweenItems(Windows[i].GetComponent<SpriteRenderer>().bounds.size.x);
                    break;
                }
            }*/

            for (int i = 0; i < BackBooks.Count; i++)
            {
                if (!BackBooks[i].activeInHierarchy)
                {

                BackBooks[i].GetComponent<SpriteRenderer>().sprite = BackBookSprites[UnityEngine.Random.Range(0, BackBookSprites.Length)];
                transform.position = new Vector3(gameObject.transform.position.x + BackBooks[i].GetComponent<SpriteRenderer>().bounds.size.x + UnityEngine.Random.Range(0, MaxRange), transform.position.y, transform.position.z);
                BackBooks[i].transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(MinYBooks, MaxYBooks), transform.position.z);
                BackBooks[i].SetActive(true);         
                }
            }
    }

    private void CreateObjs()
    {
        /*for (int i = 0; i < WindowSprites.Length; i++)
        {
            for (int j = 0; j < CountItems; j++)
            {
                GameObject newObj = (GameObject)Instantiate(Window);
                newObj.GetComponent<SpriteRenderer>().sprite = WindowSprites[i];
                newObj.transform.SetParent(ParentWindows.transform);
                newObj.SetActive(false);
                Windows.Add(newObj);
            }
        }*/

        for (int j = 0; j < CountItems; j++)
        {
            GameObject newObj = (GameObject)Instantiate(BackBook);
            newObj.transform.SetParent(ParentBooks.transform);
            newObj.SetActive(false);
            BackBooks.Add(newObj);
        }
        
    }

    private void JumpBetweenItems(float sizeObj)
    {
        transform.position = new Vector3(gameObject.transform.position.x + sizeObj + UnityEngine.Random.Range(0, MaxRange), transform.position.y, transform.position.z);
    }

}
