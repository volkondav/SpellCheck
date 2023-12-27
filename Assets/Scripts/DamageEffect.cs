using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    private int _directDamage;
    private int _damageOT;
    private int _dotTimes;


    private void Awake()
    {
        _directDamage = GetComponentInParent<Spell>().DirectDamage; // Research this
        _damageOT = GetComponentInParent<Spell>().DamageOT; // Research this
        _dotTimes = GetComponentInParent<Spell>().DOTTimes; // Research this
    }

    private void DealDamage(Collider2D targetCollider)
    {
        if (targetCollider.TryGetComponent<HealthManager>(out HealthManager healthManager))
        {
            healthManager.TakeDirectDamage(_directDamage);
            healthManager.ApplyDOT(_damageOT, _dotTimes);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // DealDamage(collision, _directDamage); если честно, я плохо понимаю, зачем отдельно передавать урон в виде переменной, которая и так доступна в скрипте
        DealDamage(collision);

    }
}
