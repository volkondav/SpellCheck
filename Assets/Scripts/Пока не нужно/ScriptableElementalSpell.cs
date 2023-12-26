using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Elemental")]
public class ScriptableElementalSpell : ScriptableObject
{
    public Vector2 SpawnPosition;
    public int damage;
    public float spellSpeed;
    public float explosionTime;
}
