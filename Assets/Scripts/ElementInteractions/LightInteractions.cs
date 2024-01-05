using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteractions : MonoBehaviour
{
    [SerializeField] private GameObject _lightRay; // _ (нижнее подчёркивание) в именах переменных использовать для приватных переменных в определении класса; основная задача -- различать приватные переменные из класса и из функицй / методов
    [SerializeField] private GameObject _lightRing;
    private Rigidbody2D spellBody;
    private SpriteRenderer spellSprite;
    private float speedIncrease = 1.5f;

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
                // отправляю здесь в функцию позицию точки на периметре коллайдера, которая является ближайшей между коллайдером одного объекта и центром другого
                LightWithIce( collision.ClosestPoint( this.transform.position ) );
                break;           
            case 8: // на время написания кода layer 8 -- это слой огонь
                LightWithFire( collision );
                InitiateDeath( collision.gameObject );
                break;
            case 9: // на время напиания кода layer 9 -- этой слой свет
                // Debug.Log("Entered case 9" , this.gameObject);
                if ( spellBody.velocity.x != 0 )
                    LightWithLight();
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
        Debug.Log(this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
        Destroy(gameObject);
    }

    void LightWithIce( Vector3 spawnPosition ){
        Instantiate( _lightRay, spawnPosition , new Quaternion() );
    }

    void LightWithLight(){
        spellSprite.color = new Color( spellSprite.color.r, spellSprite.color.g * 0.8f, spellSprite.color.b * 0.5f, spellSprite.color.a );
        spellBody.velocity = new Vector2( spellBody.velocity.x * speedIncrease , 0 );
        // Debug.Log("Object's x velocity: " + spellBody.velocity.x, this.gameObject);
    }
    public void LightWithFire( Collider2D collision )
    {
        Vector3 contactPoint = gameObject.GetComponent<Collider2D>().ClosestPoint( collision.transform.position );
        GameObject lightRing = Instantiate(_lightRing, contactPoint, new Quaternion());
        lightRing.layer = 0;
    }
}
