using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Arrow")]
public class ScriptableArrowSpell : ScriptableObject
{
    public Vector2 SpawnPosition;
    public int damage;
    public float spellSpeed;
}
