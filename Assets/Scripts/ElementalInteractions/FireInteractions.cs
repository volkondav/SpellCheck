using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInteractions : ElementalInteractions
{
    // [SerializeField] private ScriptableSpellList _darkSpellList;
    // [SerializeField] private ScriptableSpellList _fireSpellList;
    [SerializeField] private GameObject _smallExplosion, _fireLine;
    // private Rigidbody2D _spellBody;
    // private SpriteRenderer _spellSprite;
    // private DamagingSpell spellDamageComponent;
    // private float _speedDecrease = 0.6f;
    // private float _damageIncrease = 1.2f;

    // void Awake(){
    //     _spellBody = GetComponent<Rigidbody2D>();
    //     _spellSprite = GetComponent<SpriteRenderer>();
    // }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Activated OnTriggerEnter2D: " + gameObject.name + " entered " + collision.name, gameObject);
        switch ( collision.gameObject.layer ){
            case 6: // на время написания кода layer 6 -- это слой Characters
                // DealDamage(collision);
                break;   
            case 7: // на время написания кода layer 7 -- это слой лёд
                _spellComponent.InitiateSelfDestruction( collision.gameObject );
                break;           
            case 8: // на время написания кода layer 8 -- это слой огонь
                // InitiateDeath( collision.gameObject );
                // if ( this.gameObject.TryGetComponent<DamagingSpell>( out spellDamageComponent ) )
                if ( this.gameObject.GetComponent<Rigidbody2D>().velocity.x != 0 )
                    FireWithFire( collision.ClosestPoint( this.transform.position ) );
                break;
            case 9: // на время напиания кода layer 9 -- этой слой свет
                // Debug.Log("Entered case 9" , this.gameObject);
                _spellComponent.InitiateSelfDestruction( collision.gameObject );
                break;
            case 10: // на время напиания кода layer 9 -- этой слой тьма
                FireWithDark( collision.ClosestPoint( this.transform.position ) );
                break;
            default:
                Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
                break;
            }
    }

    void FireWithFire( Vector3 spawnPosition){
        Instantiate( _fireLine, new Vector3( spawnPosition.x + _fireLine.transform.position.x , this.transform.position.y ), new Quaternion( 0, this.transform.rotation.eulerAngles.y , 0, 0) );

    }

    // void FireWithFire(){
    //     _spellSprite.color = new Color( _spellSprite.color.r * 0.75f, _spellSprite.color.g * 0.5f, _spellSprite.color.b * 0.5f, _spellSprite.color.a );
    //     spellDamageComponent.DamageOT = (int)Math.Round( spellDamageComponent.DamageOT * _damageIncrease );
    //     _spellBody.velocity = new Vector2( _spellBody.velocity.x * _speedDecrease , 0 );
    //     // Debug.Log("Object's DamageOT: " + spellDamageComponent.DamageOT, this.gameObject);
    //     // Debug.Log("Object's x velocity: " + spellBody.velocity.x, this.gameObject);        
    // }

    void FireWithDark( Vector3 spawnPosition ){
        Instantiate( _smallExplosion, spawnPosition , new Quaternion() );
    }

    // private void FireWithDark( Collider2D darkSpellToReplace )
    // {
    //     // string darkSpellName = darkSpellToReplace.gameObject.name;
    //     string newFireSpellName = darkSpellToReplace.gameObject.name.Replace("тьмы", "огня");

        
    //     foreach (GameObject spell in _fireSpellList.spellPrefabs)
    //     {
    //         // наверное, не самая хорошая практика сравнивать строки с помощью операндов, так как результат таких операций часто не совпадают с интуитивным представлением, а функция операции труднее читается
    //         // if ( spell.name <= newFireSpellName )

    //         if ( newFireSpellName.Contains( spell.name ) )
    //         {
    //             Instantiate(spell, darkSpellToReplace.transform.position, darkSpellToReplace.transform.rotation);
    //             // GameObject newSpell = Instantiate(spell, darkSpellToReplace.transform.position, darkSpellToReplace.transform.rotation);
    //             // newSpell.layer = 8;
    //         }
    //     }
    // }
}
