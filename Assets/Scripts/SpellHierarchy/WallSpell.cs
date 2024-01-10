using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpell : Spell
{
    [SerializeField] private float _durationTime;

    void Start()
    {
        StartCoroutine( WallActive() );
    }

    IEnumerator WallActive(){
        yield return new WaitForSeconds(_durationTime);
        InitiateSelfDestruction();
    }
}
