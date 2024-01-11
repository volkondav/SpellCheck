using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpell : Spell
{
    [SerializeField] private float _durationTime;

    void Awake()
    {
        this.transform.parent.GetComponent<PlayerMovement>().CurrentPlatform.GetComponent<WallManager>().RememberWall( this.gameObject );
    }

    void Start()
    {
        StartCoroutine( WallActive() );
        this.transform.parent = null;
    }

    IEnumerator WallActive()
    {
        yield return new WaitForSeconds(_durationTime);
        InitiateSelfDestruction();
    }
}
