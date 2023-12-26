using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private ScriptableSpellsDictionary spellsDictionary;
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateSpell(string spellName){
        // print("From CreateSpell: " + spell);
        foreach(GameObject spell in spellsDictionary.spellPrefabs)
        {
            if ( spell.name == spellName ){
                Spell spellValues;
                spell.TryGetComponent<Spell>(out spellValues);
                // Instantiate<GameObject>(spell);
                Instantiate(spell, new Vector3( gameObject.transform.position.x + spellValues.SpawnPosition.x, gameObject.transform.position.y + spellValues.SpawnPosition.y), new Quaternion());
            }
            // print(spell.name.ToLower()); // пример
        }

    }
}
