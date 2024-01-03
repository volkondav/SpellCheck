using UnityEngine;
using System.Collections.Generic;
using System;


[CreateAssetMenu(menuName = "Spell List")]
public class ScriptableSpellList : ScriptableObject
{
    public List<GameObject> spellPrefabs;
    // public Dictionary<GameObject,ScriptableObject> spellDictionary;
    // Unity не позволяет сериализировать dictionary, есть только обходные пути
}
