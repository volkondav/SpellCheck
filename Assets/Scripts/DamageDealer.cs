using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    private int _directDamage;
    private int _damageOT;
    private int _dotTimes;


    void Awake()
    {
        _directDamage = GetComponent<DamagingSpell>().DirectDamage;
        _damageOT = GetComponent<DamagingSpell>().DamageOT;
        _dotTimes = GetComponent<DamagingSpell>().DOTTimes;
    }

    void OnTriggerEnter2D(Collider2D collision){
        if ( collision.TryGetComponent<HealthManager>(out HealthManager healthManager) )
            DealDamage(healthManager);
    }

    public void DealDamage(HealthManager healthManager){
        healthManager.TakeDirectDamage(_directDamage);
        healthManager.ApplyDOT(_damageOT, _dotTimes);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
