using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSpell : Spell
{
    [SerializeField] private float _durationTime;

    void Start()
    {
        StartCoroutine( AuraActive() );
    }

    IEnumerator AuraActive(){
        // print("NovaActive started");
        yield return new WaitForSeconds(_durationTime);
        InitiateSelfDestruction();
    }
}
