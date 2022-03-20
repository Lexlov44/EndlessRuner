using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapersGenerator : MonoBehaviour
{
    public GameObject PaperObj;
    public GameObject PartisPapers;

    public int CountPagesOnScene;

    public int probabilityOfOccurrence;

    private GameObject CollectinonItems;
    private List<GameObject> PoolPapers;
    private List<GameObject> Partiscl;

    private float sizeX, sizeY;

    void Start()
    {
        PoolPapers = new List<GameObject>();
        Partiscl = new List<GameObject>();


        CollectinonItems = new GameObject();
        CollectinonItems.name = "CollectItems";
        CreatePagesElemets();
    }

    void Update()
    {
        
    }

    private void CreatePagesElemets()
    {
        for (int i = 0; i < CountPagesOnScene; i++)
        {
            GameObject Element = (GameObject)Instantiate(PaperObj);
            Element.SetActive(false);
            Element.transform.SetParent(CollectinonItems.transform);
            PoolPapers.Add(Element);

            GameObject partObj = (GameObject)Instantiate(PartisPapers);
            partObj.SetActive(false);
            Partiscl.Add(partObj);
            partObj.transform.SetParent(PoolPapers[i].transform);
        }

        sizeX = PoolPapers[0].GetComponent<BoxCollider2D>().size.x;
        sizeY = PoolPapers[0].GetComponent<BoxCollider2D>().size.y;
    }

    public void SimplSetPoolPapers(List<float> posX, float posY)
    {
        if (UnityEngine.Random.Range(0, probabilityOfOccurrence) == 0)
        {
            for (int i = 0; i < posX.Count; i++)
            {
                SetOnePage(posX[i], posY);
            }
        }
    }

    private void SetOnePage(float xPosition, float yPosition)
    {
        for (int k = 0; k < PoolPapers.Count; k++)
        {
            if (!PoolPapers[k].activeInHierarchy)
            {
                PoolPapers[k].transform.position = new Vector3(xPosition, yPosition);
                PoolPapers[k].SetActive(true);
                Partiscl[k].SetActive(true);
                Partiscl[k].transform.position = new Vector3(xPosition, yPosition - (PoolPapers[k].GetComponent<SpriteRenderer>().bounds.size.y / 2.5f));
                break;
            }
        }
    }
}
