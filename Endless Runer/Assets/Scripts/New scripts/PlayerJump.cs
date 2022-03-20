using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    public PlayerController Curentplayr;


    void Update()
    {
        Curentplayr.grounded = Physics2D.IsTouchingLayers(gameObject.GetComponent<Collider2D>(), Curentplayr.Grounds);
    }


}
