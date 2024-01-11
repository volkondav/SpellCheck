using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

abstract public class ElementalInteractions : MonoBehaviour
{
    protected Spell _spellComponent;

    void Awake(){
        _spellComponent = GetComponent<Spell>();
    }

    void OnTriggerEnter2D( Collider2D collision ){
        // Debug.Log("Activated OnTriggerEnter2D: " + gameObject.name + " entered " + collision.name, gameObject);
        switch ( collision.gameObject.layer ){
            case 3: // на время написания кода layer 3 -- это Background, в том числе и Platforms
                WithPlatform( collision );
                break;
            case 6: // на время написания кода layer 6 -- это слой Characters
                WithCharacter( collision );
                break;   
            case 7: // на время написания кода layer 7 -- это слой лёд
                WithIce( collision );
                break;           
            case 8: // на время написания кода layer 8 -- это слой огонь
                WithFire( collision );
                break;
            case 9: // на время напиания кода layer 9 -- этой слой свет
                WithLight( collision );
                break;
            case 10: // на время напиания кода layer 9 -- этой слой тьма
                WithDark( collision );
                break;
            case 11: case 12: case 13: case 14: break; // все эти слои -- это ауры
            default:
                Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
                break;
            }
    }

    virtual protected void WithPlatform( Collider2D collision ){}
    virtual protected void WithCharacter( Collider2D collision ){}
    abstract protected void WithIce( Collider2D collision );
    abstract protected void WithFire( Collider2D collision );
    abstract protected void WithLight( Collider2D collision );
    abstract protected void WithDark( Collider2D collision );
        
}