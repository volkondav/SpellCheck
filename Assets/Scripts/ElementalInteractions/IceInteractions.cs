using System.Collections.Generic;
using UnityEngine;

// этот скрипт отвечает за взаимодействие заклинаний стихии льда с другими стихиями
public class IceInteractions : ElementalInteractions
{
    // [SerializeField] private GameObject _miniIceArrow;
    [SerializeField] private GameObject _iceTrap, _iceCone;

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch ( collision.gameObject.layer )
        {
            case 6: // Characters
                CreateIceTrap( collision );
                // InitiateSelfDestruction(collision.gameObject);
                break;
            case 7: // лёд / ice
                if ( this.gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 )
                    IceWithIce( collision.ClosestPoint( this.transform.position ) );
                _spellComponent.InitiateSelfDestruction( collision.gameObject );
                break;
            case 8: // огонь / fire
                // _spellComponent.InitiateSelfDestruction( collision.gameObject );
                StartCoroutine( _spellComponent.DelayedSelfDestruction() );
                break;
            case 9: // свет / light
                // взаимодействие происходит на стороне света
                break;
            case 10: // тьма / dark
                // взаимодействие отсутствует
                break;
            default:
                //Debug.Log("Could not retrieve a valid layer for: " + collision.name, collision.gameObject);
                break;
        }
    }

    public void CreateIceTrap( Collider2D characterCollider ){
        Instantiate( _iceTrap, characterCollider.transform );
    }

    public void IceWithIce( Vector3 spawnPosition ){
        Instantiate( _iceCone, new Vector3( spawnPosition.x, this.transform.position.y), new Quaternion( 0, this.transform.rotation.eulerAngles.y , 0, 0) );
    }

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
