using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DarkInteractions : ElementalInteractions
{
    [SerializeField] private GameObject _wispToSpawn;
    [SerializeField] private ScriptableSpellList _fireSpellList;
    // [SerializeField] private ScriptableSpellList _darkSpellList;
    public bool IsAbleToInteract = true;
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Activated OnTriggerEnter2D: " + gameObject.name + " entered " + collision.name, gameObject);
        switch ( collision.gameObject.layer ){
            case 6: // на время написания кода layer 6 -- это слой Characters
                // DealDamage(collision);
                break;   
            case 7: // на время написания кода layer 7 -- это слой лёд
                // InitiateSelfDestruction( collision.gameObject );
                break;           
            case 8: // на время написания кода layer 8 -- это слой огонь
                DarkWithFire();
                // InitiateSelfDestruction( collision.gameObject );
                break;
            case 9: // на время напиания кода layer 9 -- этой слой свет
                // Debug.Log("Entered case 9" , this.gameObject);
                _spellComponent.InitiateSelfDestruction( collision.gameObject );
                break;
            case 10: // на время напиания кода layer 9 -- этой слой тьма
                if ( IsAbleToInteract && collision.GetComponent<DarkInteractions>() != null ){
                    collision.GetComponent<DarkInteractions>().IsAbleToInteract = false;
                    // отправляю здесь в функцию позицию точки на периметре коллайдера, которая является ближайшей между коллайдером одного объекта и центром другого
                    DarkWithDark( collision.ClosestPoint( this.transform.position ) );
                }
                else
                    IsAbleToInteract = true;
                break;
            default:
                Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
                break;
            }
    }

    void DarkWithDark( Vector3 spawnPosition ){

        Instantiate( _wispToSpawn, spawnPosition , new Quaternion() );
        // GameObject spawnedArrow = Instantiate( _wispToSpawn, spawnPosition , new Quaternion() );
        // код ниже срабатывает раньше, чем Awake() у объекта, который спавнится строкой выше

        // turn off interaction
        // Debug.Log("About to turn off interactions for this object", spawnedArrow );
        // Destroy( spawnedArrow.GetComponent<DarkInteractions>() );

        // change direction
        // switch ( UnityEngine.Random.Range( 0, 2 ) ){
        //     case 0:
        //         break;
        //     case 1:
        //         spawnedArrow.transform.Rotate( Vector3.up, 180f );
        //         break;
        // }

        // change scale
        // spawnedArrow.transform.localScale = new Vector3( 0.5f, 0.5f );

        // change damage and speed
        // spawnedArrow.GetComponent<ArrowSpell>().HalveSpeedAndDamage();

        /* 
        // change damage
        _spawnedArrow.GetComponent<DamagingSpell>().DirectDamage = (int)math.round( _spawnedArrow.GetComponent<DamagingSpell>().DirectDamage * 0.5f );

        // change speed
        // spawnedArrow.GetComponent<Rigidbody2D>().velocity = spawnedArrow.GetComponent<Rigidbody2D>().velocity * 0.5f;
        _spawnedArrow.GetComponent<ArrowSpell>().ArrowSpellSpeed *= 0.5f;
        // Debug.Log( "Object's x velocity: " + spawnedArrow.GetComponent<Rigidbody2D>().velocity.x, spawnedArrow );
        */
    }

    void DarkWithFire(){

        string newFireSpellName = this.gameObject.name.Replace("тьмы", "огня");

        foreach (GameObject spell in _fireSpellList.spellPrefabs)
        {
            // наверное, не самая хорошая практика сравнивать строки с помощью операндов,
            // так как результат таких операций часто не совпадают с интуитивным представлением,
            // а функция операции труднее читается
            // if ( spell.name <= newFireSpellName )

            if ( newFireSpellName.Contains( spell.name ) )
            {
                // Instantiate( spell, new Vector3( transform.position.x, transform.position.y + 1f ), this.transform.rotation);
                switch ( spell.GetComponent<Spell>().spellCharacteristics ){
                    case Spell.SpellCharacteristics.Standalone:
                        Instantiate( spell, this.transform.position , this.transform.rotation);
                        break;
                    case Spell.SpellCharacteristics.AsChild:
                        Instantiate( spell, this.transform.parent );
                        break;
                    default:
                        Debug.Log("Could not retrive valid Spell.SpellCharacteristics for " + spell.name, spell );
                        break;
                }
                // GameObject newSpell = Instantiate(spell, darkSpellToReplace.transform.position, darkSpellToReplace.transform.rotation);
                // newSpell.layer = 8;
                _spellComponent.InitiateSelfDestruction();
                break;
            }
        }
    }

}
