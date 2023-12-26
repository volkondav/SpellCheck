using UnityEngine;
using System.Collections.Generic;
using System;


[CreateAssetMenu(menuName = "Spells Dictionary")]
public class ScriptableSpellsDictionary : ScriptableObject
{
    public List<GameObject> spellPrefabs;
    // public Dictionary<GameObject,ScriptableObject> spellDictionary;
    // Unity не позволяет сериализировать dictionary, есть только обходные пути
}
