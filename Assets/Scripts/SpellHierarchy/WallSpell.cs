using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpell : Spell
{
    [SerializeField] private float _durationTime;

    void Start()
    {
        this.transform.parent.GetComponent<CharacterBasics>().CurrentPlatform.GetComponent<WallManager>().RememberWall( this.gameObject );
        this.transform.parent = null;
        StartCoroutine( WallActive() );
    }

    // void OnTriggerEnter2D( Collider2D collision )
    // {
    //     if ( collision.gameObject.layer == 3 )
    //     {
    //         collision.gameObject.GetComponent<WallManager>().RememberWall( this.gameObject );
    //     }
    // }

    IEnumerator WallActive()
    {
        yield return new WaitForSeconds(_durationTime);
        InitiateSelfDestruction();
    }
}
