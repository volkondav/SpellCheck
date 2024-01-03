using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellChecker : MonoBehaviour
{
    [SerializeField] private ScriptableSpellList spellListIce;
    [SerializeField] private ScriptableSpellList spellListFire;
    [SerializeField] private ScriptableSpellList spellListLight;
    [SerializeField] private ScriptableSpellList spellListDark;
    [SerializeField] private TMP_InputField inputComponent;
    [SerializeField] private Image image;
    private SpellCaster spellCaster;
    
    private void Awake()
    {
        spellCaster = GetComponent<SpellCaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSpellName(string spellName){
        // print("From CreateSpell: " + spell);
        if ( CheckInList(spellName, spellListIce) )
            return;
        if ( CheckInList(spellName, spellListFire) )
            return;
        if ( CheckInList(spellName, spellListLight) )
            return;
        if ( CheckInList(spellName, spellListDark) )
            return;
        HighlightMisspell();
    }

    public bool CheckInList( string spellName, ScriptableSpellList spellList ){
        foreach(GameObject spell in spellList.spellPrefabs)
        {
            if ( spell.name == spellName ){

                /* весь код ниже был перенесён в SpellCaster.cs
                Spell spellValues = GetComponent<Spell>();
                // spellToCast.TryGetComponent<Spell>(out spellValues); // по факту почти то же самое, что и команда выше, только ещё проверяет на наличие компонента; такую конструкцию можно использовать только с TryGetComponent<>()
                switch ( spellValues.spellCharacteristics ){
                    case Spell.SpellCharacteristics.Standalone:
                        // Instantiate(spell, new Vector3( gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 0f ), new Quaternion());
                        // print(spell.transform.position.x);
                        Instantiate(spell, new Vector3( gameObject.transform.position.x + spell.transform.position.x , gameObject.transform.position.y + spell.transform.position.y ), new Quaternion() );
                        break;
                    case Spell.SpellCharacteristics.AsChild:
                        Instantiate(spell, new Vector3( gameObject.transform.position.x + spell.transform.position.x , gameObject.transform.position.y + spell.transform.position.y ), new Quaternion(), this.gameObject.transform );
                        break;
                    // case Spell.SpellCharacteristics.AtCharacter:
                    //     Instantiate(spell, new Vector3( gameObject.transform.position.x, gameObject.transform.position.y - 0.4f ), new Quaternion());
                    //     break;
                    default:
                        print("Could not retrieve valid SpellCharacteristics of: " + spell.name );
                        break;
                } */

                spellCaster.CastASpell( spell, 1 );
                inputComponent.text = "";
                return true;
                // Instantiate(spell, new Vector3( gameObject.transform.position.x + spellValues.SpawnPosition.x, gameObject.transform.position.y + spellValues.SpawnPosition.y), new Quaternion());
            }
            // StartCoroutine(HighlightMisspell());
            // print(spell.name.ToLower()); // пример
        }
        return false;
    }

    public void HighlightMisspell(){

            // На самом деле, очень странная проблема. Если использовать image.CrossFadeColor(), то изначально надо поставить цвет через image.canvasRenderer.SetColor()
            // Просто image.color = new Color не работает, нужно задавать почему-то именно из canvasRenderer
            // Подробнее тут: https://discussions.unity.com/t/text-crossfadealpha-not-working/143419

            // image.color = Color.HSVToRGB( 0, 1, 1);
            // print("Image Colour: " + image.color);
            image.canvasRenderer.SetColor( Color.HSVToRGB( 0, 1, 1) );
            image.CrossFadeColor( Color.HSVToRGB(0, 0, 1), 0.35f, false, false); // поставил ignoreTimeScale = false, так как было бы полезно во время паузы останавливать анимацию подсветки
    }

    // public IEnumerator HighlightMisspell(){
    //     for ( int colourSwitch = 100; colourSwitch >= 0; colourSwitch-- ){
    //         image.CrossFadeColor()
    //     }
    // }
}
