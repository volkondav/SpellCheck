using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHealing : Spell
{
    [SerializeField] private int HealingValue;

    void Start()
    {
        GetComponentInParent<HealthManager>().IncreaseHealth(HealingValue);
        InitiateSelfDestruction();
    }

    override public void InitiateSelfDestruction(){
        transform.parent = null;
        // Debug.Break();
        Destroy(gameObject, GetComponent<GetAnimationClipLength>().GetClipInfo() );
    }
    
}
