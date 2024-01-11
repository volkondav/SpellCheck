using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteractions : ElementalInteractions
{
    // _ (нижнее подчёркивание) в именах переменных использовать для приватных переменных в определении класса; основная задача -- различать приватные переменные из класса и из функицй / методов
    [SerializeField] private GameObject _lightRay, _lightRing, _lightPoint;
    public bool IsAbleToInteract;

    override protected void WithIce( Collider2D collision ){

        Instantiate( _lightRay, collision.ClosestPoint( this.transform.position ) , new Quaternion() );
    }

    override protected void WithFire( Collider2D collision ){

        StartCoroutine( _spellComponent.DelayedSelfDestruction( collision.gameObject ) );
        Instantiate(_lightRing, collision.ClosestPoint( this.transform.position ) , new Quaternion());
    }

    override protected void WithLight( Collider2D collision ){

        if ( IsAbleToInteract && collision.GetComponent<LightInteractions>() != null ){
            collision.GetComponent<LightInteractions>().IsAbleToInteract = false;
            // отправляю здесь в функцию позицию точки на периметре коллайдера, которая является ближайшей между коллайдером одного объекта и центром другого
            Instantiate( _lightPoint, new Vector3( 0, collision.ClosestPoint( this.transform.position ).y ) , new Quaternion() );
            }
        else
            IsAbleToInteract = true;
    }

    override protected void WithDark( Collider2D collision ){

        _spellComponent.InitiateSelfDestruction( collision.gameObject );
    }

}
