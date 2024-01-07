using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInteractions : ElementalInteractions
{
    [SerializeField] private GameObject _lightRay; // _ (нижнее подчёркивание) в именах переменных использовать для приватных переменных в определении класса; основная задача -- различать приватные переменные из класса и из функицй / методов
    [SerializeField] private GameObject _lightRing;
    private Rigidbody2D _spellBody;
    private SpriteRenderer _spellSprite;
    private float _speedIncrease = 1.5f;

    void Awake(){
        _spellBody = GetComponent<Rigidbody2D>();
        _spellSprite = GetComponent<SpriteRenderer>();
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
                // InitiateSelfDestruction( collision.gameObject );
                StartCoroutine( DelayedSelfDestruction( collision.gameObject ) );
                LightWithFire( collision );
                break;
            case 9: // на время напиания кода layer 9 -- этой слой свет
                // Debug.Log("Entered case 9" , this.gameObject);
                if ( _spellBody.velocity.x != 0 )
                    LightWithLight();
                break;
            case 10: // на время напиания кода layer 9 -- этой слой тьма
                InitiateSelfDestruction( collision.gameObject );
                break;

            default:
                Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
                break;
            }
    }

    void LightWithIce( Vector3 spawnPosition ){
        Instantiate( _lightRay, spawnPosition , new Quaternion() );
    }

    void LightWithLight(){
        _spellSprite.color = new Color( _spellSprite.color.r, _spellSprite.color.g * 0.8f, _spellSprite.color.b * 0.5f, _spellSprite.color.a );
        _spellBody.velocity = new Vector2( _spellBody.velocity.x * _speedIncrease , 0 );
        // Debug.Log("Object's x velocity: " + _spellBody.velocity.x, this.gameObject);
    }
    public void LightWithFire( Collider2D collision )
    {
        Vector3 contactPoint = gameObject.GetComponent<Collider2D>().ClosestPoint( collision.transform.position );
        // GameObject lightRing = Instantiate(_lightRing, contactPoint, new Quaternion());
        Instantiate(_lightRing, contactPoint, new Quaternion());
        // Destroy( lightRing.GetComponent<LightInteractions>() );
        // lightRing.layer = 0;
    }
}
