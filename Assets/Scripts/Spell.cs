using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] public Vector2 SpawnPosition;
    [SerializeField] public int DirectDamage;
    [SerializeField] public int DamageOT;
    [SerializeField] public int DOTTimes;

}
