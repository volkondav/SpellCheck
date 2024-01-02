using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private GameObject currentBuff;
    private int[] emptyBuffValues = { 0, 0 };
    private HealthManager healthManager;
    // private ShieldSpell shieldSpell;

    void Awake(){
        healthManager = GetComponent<HealthManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( currentBuff == null )
            ForgetBuff();
    }

    public void RememberBuff( GameObject buff, int[] damageReductionValues ){
        if ( currentBuff )
            Destroy(currentBuff);
        currentBuff = buff;
        // print("The buff is refreshed");
        // shieldSpell = buff.GetComponent<ShieldSpell>();
        // healthManager.UpdateDamageReduction( shieldSpell.RequestDamageReductionValues() );
        healthManager.UpdateDamageReduction( damageReductionValues );
    }

    public void ForgetBuff(){
        currentBuff = null;
        // shieldSpell = null;
        healthManager.UpdateDamageReduction( emptyBuffValues );
    }

}
