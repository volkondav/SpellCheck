using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOTDamageDealer : DamageDealer
{
    public int DamageOT, DOTTimes;
    public Color TargetFireColor;
    public float FutureDOT;

    override protected void Awake(){
        base.Awake();
        FutureDOT = DamageOT;
    }

    override protected void FixedUpdate(){
        base.FixedUpdate();
        if ( (int)Mathf.Round( FutureDOT ) > DamageOT ){
            // _spellSprite.color = new Color( _spellSprite.color.r * 0.75f, _spellSprite.color.g * 0.5f, _spellSprite.color.b * 0.5f, _spellSprite.color.a );
            base._spellSprite.color *= TargetFireColor;
            DamageOT = (int)Mathf.Round( FutureDOT );
        }
    }

    public override void DealDamage(HealthManager healthManager)
    {
        base.DealDamage(healthManager);
        healthManager.ApplyDOT(DamageOT, DOTTimes);
    }

}
