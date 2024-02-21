using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    // int direction -- это направление спелла; 1 = направлен вправо, -1 = направлен влево
    public void CastASpell( GameObject spellToCast, int direction ){
        Spell spellValues = spellToCast.GetComponent<Spell>();
        // spellToCast.TryGetComponent<Spell>(out spellValues); // по факту почти то же самое, что и команда выше, только ещё проверяет на наличие компонента; такую конструкцию можно использовать только с TryGetComponent<>()
        switch ( spellValues.spellCharacteristics ){
            case Spell.SpellCharacteristics.Standalone:
                // Instantiate(spell, new Vector3( gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 0f ), new Quaternion());
                // print(spell.transform.position.x);
                Instantiate(spellToCast, new Vector3( gameObject.transform.position.x + spellToCast.transform.position.x * direction , gameObject.transform.position.y + spellToCast.transform.position.y ), new Quaternion( 0, 90 - 90 * direction , 0, 0 ) );
                break;
            case Spell.SpellCharacteristics.AsChild:
                Instantiate(spellToCast, new Vector3( gameObject.transform.position.x + spellToCast.transform.position.x * direction , gameObject.transform.position.y + spellToCast.transform.position.y ), new Quaternion( 0, 90 - 90 * direction , 0, 0 ), this.gameObject.transform );
                break;
            // case Spell.SpellCharacteristics.AtCharacter:
            //     Instantiate(spell, new Vector3( gameObject.transform.position.x, gameObject.transform.position.y - 0.4f ), new Quaternion());
            //     break;
            default:
                print("Could not retrieve valid SpellCharacteristics of: " + spellToCast.name );
                break;
        }
    }
    
}
