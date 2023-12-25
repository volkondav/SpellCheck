using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(menuName = "Spells Dictionary")]
public class ScriptableSpellslDictionary : ScriptableObject
{
    public List<GameObject> spellPrefabs;
}
