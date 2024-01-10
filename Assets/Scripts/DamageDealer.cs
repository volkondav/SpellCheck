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

    // крайне важно, чтобы в префабе спеллов, которые наносят урон,
    //                  компонент DamageDealer стоял выше, чем соответствующий компонент с взаимодействиями
    // это нужно для того, чтобы урон обрабатывался раньше, чем взаимодействия,
    //                  так как при взаимодействиях объект может уничтожиться
    void OnTriggerEnter2D(Collider2D collision){
        if ( collision.TryGetComponent<HealthManager>(out HealthManager healthManager) )
            DealDamage(healthManager);
    }

    public void DealDamage(HealthManager healthManager){
        healthManager.TakeDirectDamage(_directDamage);
        healthManager.ApplyDOT(_damageOT, _dotTimes);
    }
    
}
