using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraInteractions : MonoBehaviour
{
    private float _iceSpeedDecreasePerSecond = 0.5f;
    private float _fireSpeedDecreasePerSecond = 0.25f;
    private float _fireDOTIncreasePerSecond = 0.25f;

    void OnTriggerStay2D( Collider2D collision ){

        switch ( this.gameObject.layer ){
            case 11: // ice (aura)
                IceAura( collision.attachedRigidbody );
                break;
            case 12: // fire (aura)
                FireAura( collision.gameObject );
                break;
        }

    }

    void IceAura( Rigidbody2D spellBody ){

        spellBody.velocity = new Vector2( spellBody.velocity.x * ( 1 - _iceSpeedDecreasePerSecond * Time.deltaTime ) , spellBody.velocity.y );
        Debug.Log("Current speed: " + spellBody.velocity, spellBody.gameObject);
    }

    void FireAura( GameObject spell ){
        float deltaTime = Time.deltaTime;
        print("Time.deltaTime = " + deltaTime);

        Rigidbody2D spellBody = spell.GetComponent<Rigidbody2D>();
        spellBody.velocity = new Vector2( spellBody.velocity.x * ( 1 - _fireSpeedDecreasePerSecond * deltaTime ) , spellBody.velocity.y );

        print("FutureDOT *= " + ( 1 + _fireDOTIncreasePerSecond * deltaTime ) );
        spell.GetComponent<DamagingSpell>().FutureDOT *= 1 + _fireDOTIncreasePerSecond * deltaTime ;

    }

}
