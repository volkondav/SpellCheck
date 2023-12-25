using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Elemental")]
public class ScriptableElementalSpell : ScriptableObject
{
    public int damage;
    public float spellSpeed;
    public float explosionTime;
}
