using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    private int _damage;

    private void Awake()
    {
        _damage = GetComponentInParent<Spell>().damage; // Research this
    }

    private void DealDamage(Collider2D targetCollider, int damage)
    {
        if (targetCollider.TryGetComponent<Health>(out Health health))
        {
            health.TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision, _damage);
    }
}
