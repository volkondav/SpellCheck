using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteractions : ElementalInteractions
{
    [SerializeField] private GameObject _smallExplosion, _fireLine;

    override protected void WithIce( Collider2D collision ){

        _spellComponent.InitiateSelfDestruction( collision.gameObject );
    }

    override protected void WithFire( Collider2D collision ){

        if ( this.gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 )
            Instantiate( _fireLine, new Vector3( collision.ClosestPoint( this.transform.position ).x + _fireLine.transform.position.x , this.transform.position.y ), new Quaternion( 0, this.transform.rotation.eulerAngles.y , 0, 0) );
    }

    override protected void WithLight( Collider2D collision ){

        _spellComponent.InitiateSelfDestruction( collision.gameObject );
    }

    override protected void WithDark( Collider2D collision ){
        
        Instantiate( _smallExplosion, collision.ClosestPoint( this.transform.position ) , new Quaternion() );
    }

}
