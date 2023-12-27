using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellHealing : Spell
{
    [SerializeField] private int HealingValue;

    // private HealthManager _healthManager;

    // void OnTriggerEnter2D(Collider2D collision){
    //     if ( collision.TryGetComponent<HealthManager>(out HealthManager healthManager) )
    //         DealDamage(healthManager);
    // }



    // Start is called before the first frame update
    void Start()
    {
        GetComponentInParent<HealthManager>().IncreaseHealth(HealingValue);
        InitiateDeath();
    }

    public void InitiateDeath(){
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
