using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BooksGenerator : MonoBehaviour
{

    public GameObject StartPlatform;
    public GameObject PoolPlatform;
    public GameObject EndPlatform;
    public GameObject GeneretingPoint;
    public GameObject BoxColliderFull;
    public Sprite[] PoolCentralSprites;

    public int MaxCountPlatformOnScene;
    public int CountOfPlatform;
    public float MaxRangeBetweenPlatforms;
    public int MaxCountPartOfPlatform;

    private List<GameObject> StartPlatforms;
    private List<GameObject> PoolPlatforms;
    private List<GameObject> EndPlatforms;
    private List<GameObject> BoxColliderFulls;

    public float sizeX;

    void Start()
    {
        StartPlatforms = new List<GameObject>();
        PoolPlatforms = new List<GameObject>();
        EndPlatforms = new List<GameObject>();
        BoxColliderFulls = new List<GameObject>();

        CreateObjectOnScene();

        sizeX = StartPlatforms[0].GetComponent<BoxCollider2D>().size.x;
    }
    
    void Update()
    {
        if (transform.position.x < GeneretingPoint.transform.position.x)
        {
            SetFullPlatform();
            JumpBetweenPlatforms();
        }
    }

    private void JumpBetweenPlatforms()
    {
        MoveYourSelf((sizeX * 4) + UnityEngine.Random.Range(0, MaxRangeBetweenPlatforms));
    }

    private void SetFullPlatform()
    {

        float positionStartX = SetStartPlatform();

        int countCentralPlatforms = SetCentralPlatforms();

        float positionEndX = SetEndPlatform();

        Vector2 positinXY = new Vector2((positionStartX + positionEndX) / 2, transform.position.y);

        countCentralPlatforms = countCentralPlatforms + 2;

        SetBox(positinXY, countCentralPlatforms);
    }
    private void SetBox(Vector2 positionCenter, int CountPLatform)
    {
        for (int i = 0; i < BoxColliderFulls.Count; i++)
        {
            if (!BoxColliderFulls[i].activeInHierarchy)
            {
                BoxColliderFulls[i].transform.position = new Vector3(positionCenter.x, positionCenter.y);
                BoxColliderFulls[i].GetComponent<BoxCollider2D>().size = new Vector2(CountPLatform * 0.64f,BoxColliderFulls[i].GetComponent<BoxCollider2D>().size.y);
                BoxColliderFulls[i].SetActive(true);
                break;
            }
        }
    }

    private float SetStartPlatform()
    {
        float positionPlatform = transform.position.x;

        for (int i = 0; i < StartPlatforms.Count; i++)
        {
            if (!StartPlatforms[i].activeInHierarchy)
            {
                StartPlatforms[i].transform.position = transform.position;
                StartPlatforms[i].SetActive(true);
                MoveYourSelf(sizeX*4);
                positionPlatform = StartPlatforms[i].transform.position.x;
                break;
            }
        }

        return positionPlatform;
    }
    private int SetCentralPlatforms()
    {
        int countOfEnabledElevents = 0;

        for (int k = 0; k < PoolPlatforms.Count; k++)
        {
            if (!PoolPlatforms[k].activeInHierarchy)
                countOfEnabledElevents++;            
        }

        if (countOfEnabledElevents > MaxCountPartOfPlatform)
            countOfEnabledElevents = MaxCountPartOfPlatform;

        int randomCountCentralPlatform = UnityEngine.Random.Range(0, countOfEnabledElevents);

        int countEnabledPlatform = 0;

        for (int j = 0; j < PoolPlatforms.Count; j++)
        {
            if (!PoolPlatforms[j].activeInHierarchy)
                countEnabledPlatform++;
            if (countEnabledPlatform == PoolPlatforms.Count)
            {
                randomCountCentralPlatform = 8;
                break;
            }
        }


        for (int i = 0; i < randomCountCentralPlatform; i++)
        {

            for (int j = 0; j < PoolPlatforms.Count; j++)
            {
                if (!PoolPlatforms[j].activeInHierarchy)
                {
                    PoolPlatforms[j].transform.position = transform.position;
                    PoolPlatforms[j].SetActive(true);

                    PoolPlatforms[j].GetComponent<SpriteRenderer>().sprite = PoolCentralSprites[UnityEngine.Random.Range(0, PoolCentralSprites.Length)];

                    if (UnityEngine.Random.Range(0, 2) == 0)
                        PoolPlatforms[j].GetComponent<SpriteRenderer>().flipX = true;

                    MoveYourSelf(sizeX*4);
                    break;
                }
            }
        }

        return randomCountCentralPlatform;
    }
    private float SetEndPlatform()
    {
        float positionPlatform = transform.position.x;
        for (int i = 0; i < EndPlatforms.Count; i++)
        {
            if (!EndPlatforms[i].activeInHierarchy)
            {
                EndPlatforms[i].transform.position = transform.position;
                EndPlatforms[i].SetActive(true);
                MoveYourSelf(sizeX*4);
                positionPlatform = EndPlatforms[i].transform.position.x;
                break;
            }
        }

        return positionPlatform;
    }

    private void CreateObjectOnScene()
    {
        for (int i = 0; i < CountOfPlatform; i++)
        {
            StartPlatforms.Add(CreateOneObject(1));

            EndPlatforms.Add(CreateOneObject(2));

            for(int k = 0; k < 3; k++)
                PoolPlatforms.Add(CreateOneObject(3));

            BoxColliderFulls.Add(CreateOneObject(4));
        }
    }

    /*private GameObject CreateBox()
    {
        GameObject NewObj = (GameObject)Instantiate(BoxColliderFull);
        NewObj.SetActive(false);
        return NewObj;
    }
    private GameObject CreateStartPlatforms()
    {
        GameObject NewObj = (GameObject)Instantiate(StartPlatform);
        NewObj.SetActive(false);
        return NewObj;
    }
    private GameObject CreateEndPlatforms()
    {
        GameObject NewObj = (GameObject)Instantiate(EndPlatform);
        NewObj.SetActive(false);
        return NewObj;
    }
    private GameObject CreateCentralPlatforms()
    {
        GameObject NewObj = (GameObject)Instantiate(PoolPlatform);
        NewObj.SetActive(false);
        return NewObj;    
    }
    */

    private void MoveYourSelf(float moveSize)
    {
        transform.position = new Vector3(transform.position.x + moveSize, transform.position.y,transform.position.z);
    }

    private GameObject CreateOneObject(int nuberOfObject)
    {
        GameObject NewObj = new GameObject();
        switch (nuberOfObject)
        {
            case 1:
                {
                    NewObj = (GameObject)Instantiate(StartPlatform);
                    break;
                }
            case 2:
                {
                    NewObj = (GameObject)Instantiate(EndPlatform);
                    break;
                }
            case 3:
                {
                    NewObj = (GameObject)Instantiate(PoolPlatform);
                    break;
                }
            case 4:
                {
                    NewObj = (GameObject)Instantiate(BoxColliderFull);
                    break;
                }                           
        }

        NewObj.SetActive(false);

        return NewObj;
    }
}

