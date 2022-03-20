using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController thePlayer;

    private Vector3 LastPlayerPosition;
    private float distanceToMove;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        LastPlayerPosition = thePlayer.transform.position;
    }

    void Update()
    {
        distanceToMove = thePlayer.transform.position.x - LastPlayerPosition.x;

        transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

        LastPlayerPosition = thePlayer.transform.position;
    }
}
