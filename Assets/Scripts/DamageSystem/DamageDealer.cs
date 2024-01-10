using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    protected SpriteRenderer _spellSprite;
    public int DirectDamage;
    public Color TargetDarkColor;
    public float FutureDirectDamage;

    // крайне важно, чтобы в префабе спеллов, которые наносят урон,
    //                  компонент DamageDealer стоял выше, чем соответствующий компонент с взаимодействиями
    // это нужно для того, чтобы урон обрабатывался раньше, чем взаимодействия,
    //                  так как при взаимодействиях объект может уничтожиться

    virtual protected void Awake(){
        _spellSprite = GetComponent<SpriteRenderer>();
        FutureDirectDamage = DirectDamage;
    }

    virtual protected void FixedUpdate(){
        
        if ( (int)Mathf.Round( FutureDirectDamage ) > DirectDamage ){
            // _spellSprite.color = new Color( _spellSprite.color.r * 0.75f, _spellSprite.color.g * 0.5f, _spellSprite.color.b * 0.5f, _spellSprite.color.a );
            _spellSprite.color *= TargetDarkColor;
            DirectDamage = (int)Mathf.Round( FutureDirectDamage );
        }

    }

    void OnTriggerEnter2D( Collider2D collision ){
        if ( collision.TryGetComponent<HealthManager>(out HealthManager healthManager) )
            DealDamage(healthManager);
    }

    virtual public void DealDamage( HealthManager healthManager ){
        healthManager.TakeDirectDamage( DirectDamage );
    }
    
}
