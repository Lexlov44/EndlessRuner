using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public GameObject OneCoin;

    public int coinCount;

    private List<GameObject> CoinStack;

    private float sizeCoin;

    void Start()
    {
        CoinStack = new List<GameObject>();
        CreateCoinStack();
        sizeCoin = OneCoin.GetComponent<BoxCollider2D>().size.x;
    }

    void Update()
    {

    }

    private void CreateCoinStack()
    {
        for (int i = 0; i < coinCount; i++)
        {
            GameObject NewObj = (GameObject)Instantiate(OneCoin);
            NewObj.SetActive(false);
            CoinStack.Add(NewObj);
        }
    }

    public void SetCoinStuck(int coinInLine, Vector2 StartPositionCoin)
    {
        for (int i = 0; i < coinInLine; i++)
        {
            float curentPositonCointX, curentPositonCointY = 0;

            curentPositonCointX = StartPositionCoin.x;


            StartPositionCoin = new Vector2(curentPositonCointX, curentPositonCointY);
            CreateOneCoin(StartPositionCoin);
        }
    }

    public void CreateOneCoin(Vector2 positionCoin)
    {
        for (int i = 0; i < CoinStack.Count; i++)
        {
            if (!CoinStack[i].activeInHierarchy)
            {
                CoinStack[i].transform.position = positionCoin;
            }
        }
    }

    public float PositionCoinY(float positionCurenCoin, int heightOption)
    {
        float PositionCoinY = 0;

        switch (heightOption)
        {
            case 1:
                {
                    break;
                }
            default:
                {
                    PositionCoinY = 0;
                    break;
                }
        }

        return PositionCoinY;
    }
}
