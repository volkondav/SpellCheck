using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraInfluence : MonoBehaviour
{
    private float _iceSpeedDecrease = 0.5f;
    private float _fireSpeedDecrease = 0.3f;
    private float _fireDOTIncrease = 0.3f;
    private float _lightSpeedIncrease = 1f;
    private float _darkDirectDamageIncrease = 1f;

    void OnTriggerStay2D( Collider2D collision ){

        switch ( this.gameObject.layer ){
            case 11: // ice (aura)
                IceAura( collision.attachedRigidbody );
                break;
            case 12: // fire (aura)
                FireAura( collision.gameObject );
                break;
            case 13: // light (aura)
                LightAura( collision. attachedRigidbody );
                break;
            case 14: // dark (aura)
                DarkAura( collision.gameObject );
                break;
        }

    }

    void IceAura( Rigidbody2D spellBody ){

        spellBody.velocity = new Vector2( spellBody.velocity.x * (1 - _iceSpeedDecrease * Time.deltaTime ) , spellBody.velocity.y );
        // Debug.Log("Current speed: " + spellBody.velocity, spellBody.gameObject);

    }

    void FireAura( GameObject spell ){

        float deltaTime = Time.deltaTime;
        // print("Time.deltaTime = " + deltaTime);

        Rigidbody2D spellBody = spell.GetComponent<Rigidbody2D>();
        spellBody.velocity = new Vector2( spellBody.velocity.x * ( 1 - _fireSpeedDecrease * deltaTime ) , spellBody.velocity.y );

        // print("FutureDOT *= " + ( 1 + _fireDOTIncreasePerSecond * deltaTime ) );
        if ( spell.TryGetComponent<DOTDamageDealer>(out DOTDamageDealer dotComponent) )
            dotComponent.FutureDOT *= 1 + _fireDOTIncrease * deltaTime;

    }

    void LightAura( Rigidbody2D spellBody ){

        spellBody.velocity = new Vector2( spellBody.velocity.x * ( 1 + _lightSpeedIncrease * Time.deltaTime ) , spellBody.velocity.y );
        // Debug.Log("Current speed: " + spellBody.velocity, spellBody.gameObject);

    }

    void DarkAura( GameObject spell ){

        if( spell.TryGetComponent<DamageDealer>(out DamageDealer damageComponent) ){
            damageComponent.FutureDirectDamage *= 1 + _darkDirectDamageIncrease * Time.deltaTime;
        }


    }

}
