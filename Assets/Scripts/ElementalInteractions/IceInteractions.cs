using System.Collections.Generic;
using UnityEngine;

// этот скрипт отвечает за взаимодействие заклинаний стихии льда с другими стихиями
public class IceInteractions : ElementalInteractions
{
    // [SerializeField] private GameObject _miniIceArrow;
    [SerializeField] private GameObject _iceTrap, _iceCone;

    override protected void WithCharacter( Collider2D characterCollider ){

        Instantiate( _iceTrap, characterCollider.transform );
    }

    override protected void WithIce( Collider2D collision ){

        if ( this.gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 )
            Instantiate( _iceCone, new Vector3( collision.ClosestPoint( this.transform.position ).x, this.transform.position.y), new Quaternion( 0, this.transform.rotation.eulerAngles.y , 0, 0) );
        // код ниже срабатывает раньше, чем Awake() у объекта, который спавнится строкой выше
        _spellComponent.InitiateSelfDestruction( collision.gameObject );
    }

    override protected void WithFire( Collider2D collision ){

        StartCoroutine( _spellComponent.DelayedSelfDestruction() );
    }

    override protected void WithLight( Collider2D collision ) { /* the interaction commences on the Light's object side */ }

    override protected void WithDark( Collider2D collision ) { /* there is no interaction */ }

    // public void IceWithIce()
    // {
    //     var positions = new List<float> { 1.5f, -0.5f, -2.5f };

    //     switch ( this.transform.position.y ){
    //         case float row when ( row <= 1.5f && row >= 0.5f ):
    //             positions.RemoveAt( 2 );
    //             break;
    //         case float row when ( row <= -0.5f && row >= -1.5f ):
    //             positions.RemoveAt( Random.Range( 0, 3 ) );
    //             break;
    //         case float row when ( row <= -2.5f && row >= -3.5f ):
    //             positions.RemoveAt( 0 );
    //             break;
    //     }

    //     // positions.Remove(transform.position.y);
    //     float randomPosition = positions[ Random.Range( 0, positions.Count ) ];
    //     Vector3 spawnPosition = new Vector3(transform.position.x, randomPosition);
    //     GameObject miniArrow = Instantiate(_miniIceArrow, spawnPosition, transform.rotation);
    //     miniArrow.GetComponent<ArrowSpell>().HalveSpeedAndDamage();
    //     positions.Remove( randomPosition ); // если требуется, чтобы мини стрелы от одной обычной стрелы, не спавнились на одной линии
        
    //     randomPosition = positions[Random.Range(0, positions.Count)];
    //     spawnPosition = new Vector3(transform.position.x, randomPosition);
    //     miniArrow = Instantiate(_miniIceArrow, spawnPosition, transform.rotation);
    //     miniArrow.GetComponent<ArrowSpell>().HalveSpeedAndDamage();
    // }

}
