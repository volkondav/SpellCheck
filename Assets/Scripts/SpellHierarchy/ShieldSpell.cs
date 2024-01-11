using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpell : Spell
{
    [SerializeField] private int shieldDuration;
    [SerializeField] private int remainingShieldDuration;
    [SerializeField] private int[] damageReductionValues = new int[2];
    // private BuffManager buffManager;

    public int[] RequestDamageReductionValues(){
        return damageReductionValues;
    }

    public IEnumerator DestroyCountdown(){
        for ( remainingShieldDuration = shieldDuration ; remainingShieldDuration > 0 ; remainingShieldDuration-- )
            yield return new WaitForSeconds(1);
        InitiateSelfDestruction();
    }

    // void Awake(){
    //     Debug.Log("Awake: " + this.gameObject.name, this.gameObject);
    //     buffManager = GetComponentInParent<BuffManager>();
    // }

    virtual protected void Start(){
        GetComponentInParent<BuffManager>().RememberBuff( this.gameObject, damageReductionValues );
        StartCoroutine( DestroyCountdown() );
        // buffManager.RememberBuff( this.gameObject , damageReductionValues );
        // Destroy(gameObject, shieldDuration);
    }

    // void OnDestroy(){
    //     print("The buff is destroyed");
    //     GetComponentInParent<BuffManager>().ForgetBuff() ;
    // }
}
