using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBasics : MonoBehaviour
{
    public GameObject CurrentPlatform;
    public bool IsAbleToMove;

    void OnTriggerEnter2D(Collider2D collision){
        if ( collision.gameObject.layer ==  3)
            CurrentPlatform = collision.gameObject;
    }

}
