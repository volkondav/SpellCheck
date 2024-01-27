using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterBasics : NetworkBehaviour
{
    public GameObject CurrentPlatform;
    public bool IsAbleToMove;

    void OnTriggerEnter2D(Collider2D collision){
        if ( collision.gameObject.layer ==  3)
            CurrentPlatform = collision.gameObject;
    }

}
