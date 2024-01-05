using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteractions : MonoBehaviour
{
    private Rigidbody2D spellBody;
    private SpriteRenderer spellSprite;
    private DamagingSpell spellDamageComponent;
    private float speedDecrease = 0.6f;
    private float damageIncrease = 1.2f;

    void Awake(){
        spellBody = GetComponent<Rigidbody2D>();
        spellSprite = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Activated OnTriggerEnter2D: " + gameObject.name + " entered " + collision.name, gameObject);
        switch ( collision.gameObject.layer ){
            case 6: // на время написания кода layer 6 -- это слой Characters
                // DealDamage(collision);
                break;   
            case 7: // на время написания кода layer 7 -- это слой лёд
                InitiateDeath( collision.gameObject );
                break;           
            case 8: // на время написания кода layer 8 -- это слой огонь
                // InitiateDeath( collision.gameObject );
                if ( this.gameObject.TryGetComponent<DamagingSpell>( out spellDamageComponent ) )
                    FireWithFire();
                break;
            case 9: // на время напиания кода layer 9 -- этой слой свет
                // Debug.Log("Entered case 9" , this.gameObject);
                break;
            case 10: // на время напиания кода layer 9 -- этой слой тьма
                InitiateDeath( collision.gameObject );
                break;

            default:
                Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
                break;
            }
        // if ( collision.gameObject.layer == 8 ) // на время написания кода layer 8 -- это слой Player
        //     DealDamage(collision);
    }
    public void InitiateDeath( GameObject collisionGameObject ){
        // print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
        // Debug.Log(this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
        Destroy(gameObject);
    }

    void FireWithFire(){
        spellSprite.color = new Color( spellSprite.color.r * 0.75f, spellSprite.color.g * 0.5f, spellSprite.color.b * 0.5f, spellSprite.color.a );
        spellDamageComponent.DamageOT = (int)Math.Round( spellDamageComponent.DamageOT * damageIncrease );
        spellBody.velocity = new Vector2( spellBody.velocity.x * speedDecrease , 0 );
        // Debug.Log("Object's DamageOT: " + spellDamageComponent.DamageOT, this.gameObject);
        // Debug.Log("Object's x velocity: " + spellBody.velocity.x, this.gameObject);
    }
}
