using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] public Vector2 SpawnPosition;
    [SerializeField] public int damage;
}
