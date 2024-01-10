using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class DamagingSpellDeprecated : Spell
{
    public int DirectDamage;
    public int DamageOT;
    public float FutureDOT;
    public int DOTTimes;
    private SpriteRenderer _spellSprite;
    public Color TargetFireColor = new Color();

    virtual protected void Awake(){
        _spellSprite = GetComponent<SpriteRenderer>();
    }

    virtual protected void Start(){
        FutureDOT = DamageOT;
    }

    virtual protected void FixedUpdate(){
        if ( (int)Mathf.Round( FutureDOT ) > DamageOT ){
            // _spellSprite.color = new Color( _spellSprite.color.r * 0.75f, _spellSprite.color.g * 0.5f, _spellSprite.color.b * 0.5f, _spellSprite.color.a );
            _spellSprite.color *= TargetFireColor;
            DamageOT = (int)Mathf.Round( FutureDOT );
        }
    }

}
