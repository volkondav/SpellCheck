using UnityEngine;

public class TestSpellsDictionary : MonoBehaviour
{
    [SerializeField] private ScriptableSpellslDictionary spellsDictionary;

    private void Start()
    {
        foreach(GameObject spell in spellsDictionary.spellPrefabs)
        {
            //print(spell.name.ToLower());
        }
    }
}
