using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DarkInteractions : ElementalInteractions
{
    [SerializeField] private GameObject _arrowToSpawn;
    public bool isAbleToInteract = true;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Activated OnTriggerEnter2D: " + gameObject.name + " entered " + collision.name, gameObject);
        switch ( collision.gameObject.layer ){
            case 6: // на время написания кода layer 6 -- это слой Characters
                // DealDamage(collision);
                break;   
            case 7: // на время написания кода layer 7 -- это слой лёд
                InitiateSelfDestruction( collision.gameObject );
                break;           
            case 8: // на время написания кода layer 8 -- это слой огонь
                InitiateSelfDestruction( collision.gameObject );
                break;
            case 9: // на время напиания кода layer 9 -- этой слой свет
                // Debug.Log("Entered case 9" , this.gameObject);
                InitiateSelfDestruction( collision.gameObject );
                break;
            case 10: // на время напиания кода layer 9 -- этой слой тьма
                if ( isAbleToInteract && collision.GetComponent<DarkInteractions>() != null ){
                    collision.GetComponent<DarkInteractions>().isAbleToInteract = false;
                    // отправляю здесь в функцию позицию точки на периметре коллайдера, которая является ближайшей между коллайдером одного объекта и центром другого
                    DarkWithDark( collision.ClosestPoint( this.transform.position ) );
                }
                else
                    isAbleToInteract = true;
                break;
            default:
                Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
                break;
            }
    }

    void Awake(){
        // Debug.Log("Awake happened", this.gameObject );
    }

    void DarkWithDark( Vector3 spawnPosition ){

        GameObject spawnedArrow = Instantiate( _arrowToSpawn, spawnPosition , new Quaternion() );
        // код ниже срабатывает раньше, чем Awake() у стрелы, которая спавнится строкой выше

        // turn off interaction
        // Debug.Log("About to turn off interactions for this object", spawnedArrow );
        Destroy( spawnedArrow.GetComponent<DarkInteractions>() );

        // change direction
        switch ( UnityEngine.Random.Range( 0, 2 ) ){
            case 0:
                break;
            case 1:
                spawnedArrow.transform.Rotate( Vector3.up, 180f );
                break;
        }

        // change scale
        spawnedArrow.transform.localScale = new Vector3( 0.5f, 0.5f );

        // change damage and speed
        spawnedArrow.GetComponent<ArrowSpell>().HalveSpeedAndDamage();

        /* 
        // change damage
        _spawnedArrow.GetComponent<DamagingSpell>().DirectDamage = (int)math.round( _spawnedArrow.GetComponent<DamagingSpell>().DirectDamage * 0.5f );

        // change speed
        // spawnedArrow.GetComponent<Rigidbody2D>().velocity = spawnedArrow.GetComponent<Rigidbody2D>().velocity * 0.5f;
        _spawnedArrow.GetComponent<ArrowSpell>().ArrowSpellSpeed *= 0.5f;
        // Debug.Log( "Object's x velocity: " + spawnedArrow.GetComponent<Rigidbody2D>().velocity.x, spawnedArrow );
        */
    }
}
