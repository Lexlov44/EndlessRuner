using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PLatformGenerator_books : MonoBehaviour
{
    public GameObject GeneratorPages;
    public float plusPositionYForPages;

    public GameObject SampleBooksPlatform;    
    public GameObject BoxColliderPlatform;
    public GameObject GeneretingPoint;
    public Sprite[] StartSprites;
    public Sprite[] EndSprites;
    public Sprite[] CentralSprites;


    public int startCount;
    public int maxCountPlatformOnScene;
    public int countPartsOfPlatform;
    public int countBoxColiders;
    public float maxRangeBetweenPlatforms;
    public int maxCountPartOfOnePlatform;
    public int sizeOfStartPlatform;


    private List<GameObject> PoolBooksPlatform;
    private List<GameObject> PoolBoxColliderPlatform;
    private List<float> xPotions;

    private GameObject Platforms, Parts, BoxColiders;

    private float sizeX;

    private bool startPlatformCreated;

    private float BoxSize;

    void Start()
    {
        startPlatformCreated = false;
        BoxSize = BoxColliderPlatform.GetComponent<BoxCollider2D>().size.x;

        PoolBooksPlatform = new List<GameObject>();
        PoolBoxColliderPlatform = new List<GameObject>();
        xPotions = new List<float>();

        Platforms = new GameObject();
        Parts = new GameObject();
        BoxColiders = new GameObject();
        
        Platforms.name = "Platforms";
        Parts.name = "Parts";
        BoxColiders.name = "BoxColiders";

        CreateDisabledPlatform();

        sizeX = SampleBooksPlatform.GetComponent<SpriteRenderer>().bounds.size.x;

        CreateStartEnabledPlatform(sizeOfStartPlatform);

        xPotions.Clear();

        startPlatformCreated = true;
    }

    void Update()
    {
        CreateEnabledFullPlatform();
    }

    //Условие на создание плтаформ и прыжок между ними
    private void CreateEnabledFullPlatform()
    {
        if (transform.position.x < GeneretingPoint.transform.position.x)
        {
            CreateOneEnabledPlatform();
            JumpBetweenPlatforms();
        }
    }

    //Создание платформы на старте
    private void CreateStartEnabledPlatform(int countNumber)
    {
        CreatePlatform(countNumber);
        JumpBetweenPlatforms();
    }


    //Установка 1 полной платформы
    private void CreateOneEnabledPlatform()
    {
        int countPatrs = FindCountOfPlatforms();
        CreatePlatform(countPatrs);

    }

    //Создание 1 полной платформы
    private void CreatePlatform(int countPatrs)
    {
        //Стартовый X платформы
        float CurentX = transform.position.x;

        SetOnePart("Start");

        for (int i = 0; i < countPatrs - 2; i++)
        {
            SetOnePart("Central");
        }

        //Вычесление Х середины платформы 
        float boxColiderX = ((CurentX + transform.position.x) / 2);

        SetOnePart("End");


        SetBoxColider(boxColiderX, countPatrs);

        //Если стартовая платформа уже была создана
        if (startPlatformCreated == true)
        {
            //Cоздание собирательных страниц на платформах
            GeneratorPages.GetComponent<PapersGenerator>().SimplSetPoolPapers(xPotions, transform.position.y + (sizeX) + plusPositionYForPages);
            xPotions.Clear();
        }
    }

        //Создание 1 части платформы (Старт,центр,конец)
        private void SetOnePart(string namePlatform)
    {
        for (int i = 0; i < PoolBooksPlatform.Count; i++)
        {
            if (!PoolBooksPlatform[i].activeInHierarchy)
            {
                switch (namePlatform)
                {
                    case "Start":
                        {
                            PoolBooksPlatform[i].GetComponent<SpriteRenderer>().sprite = StartSprites[UnityEngine.Random.Range(0, StartSprites.Length)];
                            break;
                        }
                    case "Central":
                        {
                            PoolBooksPlatform[i].GetComponent<SpriteRenderer>().sprite = CentralSprites[UnityEngine.Random.Range(0, CentralSprites.Length)];
                            break;
                        }
                    case "End":
                        {
                            PoolBooksPlatform[i].GetComponent<SpriteRenderer>().sprite = EndSprites[UnityEngine.Random.Range(0, EndSprites.Length)];
                            break;
                        }
                }

                PoolBooksPlatform[i].transform.position = transform.position;
                xPotions.Add(PoolBooksPlatform[i].transform.position.x);
                PoolBooksPlatform[i].SetActive(true);
                MoveYourSelf(sizeX);
                break;
            }
        }

    }


    //Создания единого BoxColider
    private void SetBoxColider(float boxColiderX, int countPatrs)
    {
        for (int i = 0; i < PoolBoxColliderPlatform.Count; i++)
        {
            if (!PoolBoxColliderPlatform[i].activeInHierarchy)
            {
                PoolBoxColliderPlatform[i].transform.position = new Vector3(boxColiderX, transform.position.y);
                PoolBoxColliderPlatform[i].GetComponent<BoxCollider2D>().size = new Vector2(countPatrs * BoxSize, PoolBoxColliderPlatform[i].GetComponent<BoxCollider2D>().size.y);
                PoolBoxColliderPlatform[i].SetActive(true);
                break;
            }
        }
    }


    //Возвращает true если все созданные платформы задезайблены
    private bool AllPlatformDisabled()
    {

        for (int j = 0; j < PoolBooksPlatform.Count; j++)
        {
            int countEnabledPlatform = 0;

            if (!PoolBooksPlatform[j].activeInHierarchy)
                countEnabledPlatform++;
            if (countEnabledPlatform == PoolBooksPlatform.Count)
            {
                return true;                
            }
        }
        return false;
    }

    
    //Определение кол-во элементов в 1 платформе
    private int FindCountOfPlatforms()
    {
        int countOfDisabledElevents = 0;

        for (int i = 0; i < PoolBooksPlatform.Count; i++)
        {
            if (!PoolBooksPlatform[i].activeInHierarchy)
            {
                countOfDisabledElevents++;
                if (countOfDisabledElevents > maxCountPartOfOnePlatform)
                {
                    countOfDisabledElevents = maxCountPartOfOnePlatform;
                    break;
                }
            }
        }

        return UnityEngine.Random.Range(2, countOfDisabledElevents);
    }



    //Создание элементов платформы при старте сцены
    private void CreateDisabledPlatform()
    {
        Parts.transform.SetParent(Platforms.transform);
        BoxColiders.transform.SetParent(Platforms.transform);

        for (int i = 0; i < countPartsOfPlatform; i++)
        {
            PoolBooksPlatform.Add(CreateGameObjectOnScene("Part"));
        }

        for (int i = 0; i < countBoxColiders; i++)
        {
            PoolBoxColliderPlatform.Add(CreateGameObjectOnScene("Box"));
        }
    }

    private GameObject CreateGameObjectOnScene(string NameElement)
    {
        switch (NameElement)
        {
            case "Part":
                {
                    GameObject Element = (GameObject)Instantiate(SampleBooksPlatform);
                    Element.SetActive(false);
                    Element.transform.SetParent(Parts.transform);
                    return Element;
                }
            case "Box":
                {
                    GameObject Element = (GameObject)Instantiate(BoxColliderPlatform);
                    Element.SetActive(false);
                    Element.transform.SetParent(BoxColiders.transform);
                    return Element;
                }
        }

        return Platforms;
    }




    //Передвижение точки генерации
    private void JumpBetweenPlatforms()
    {
        MoveYourSelf((sizeX*2) + UnityEngine.Random.Range(0, maxRangeBetweenPlatforms));
    }
    private void MoveYourSelf(float moveSize)
    {
        transform.position = new Vector3(transform.position.x + moveSize, transform.position.y, transform.position.z);
    }

}
