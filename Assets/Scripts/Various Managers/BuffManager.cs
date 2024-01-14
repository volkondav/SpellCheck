using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private GameObject _currentBuff;
    private int[] emptyBuffValues = { 0, 0 };
    private HealthManager healthManager;
    // private ShieldSpell shieldSpell;

    void Awake(){
        healthManager = GetComponent<HealthManager>();
    }

    void Update()
    {
        if ( _currentBuff == null )
            ForgetBuff();
    }

    public void RememberBuff( GameObject buff, int[] damageReductionValues ){
        if ( _currentBuff )
            Destroy(_currentBuff);
        _currentBuff = buff;
        // print("The buff is refreshed");
        // shieldSpell = buff.GetComponent<ShieldSpell>();
        // healthManager.UpdateDamageReduction( shieldSpell.RequestDamageReductionValues() );
        healthManager.UpdateDamageReductionValues( damageReductionValues );
    }

    public void ForgetBuff(){
        _currentBuff = null;
        // shieldSpell = null;
        healthManager.UpdateDamageReductionValues( emptyBuffValues );
    }

}
