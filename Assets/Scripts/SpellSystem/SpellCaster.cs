using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCaster : MonoBehaviour
{
    [SerializeField] private ScriptableSpellsDictionary spellsDictionary;
    [SerializeField] private TMP_InputField inputComponent;
    [SerializeField] private Image image;
    private void Awake()
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
                switch (spellValues.SpellCharacteristics){
                    case "attack":
                        Instantiate(spell, new Vector3( gameObject.transform.position.x + 1.5f, gameObject.transform.position.y + 0f ), new Quaternion());
                        break;
                    case "buff":
                        Instantiate(spell, this.gameObject.transform );
                        break;
                    default:
                        print("Could not retrieve valid SpellCharacteristics of: " + spell.name );
                        break;
                }
                inputComponent.text = "";
                break;
                // Instantiate(spell, new Vector3( gameObject.transform.position.x + spellValues.SpawnPosition.x, gameObject.transform.position.y + spellValues.SpawnPosition.y), new Quaternion());
            }

            // На самом деле, очень странная проблема. Если использовать image.CrossFadeColor(), то изначально надо поставить цвет через image.canvasRenderer.SetColor()
            // Просто image.color = new Color не работает, нужно задавать почему-то именно из canvasRenderer
            // Подробнее тут: https://discussions.unity.com/t/text-crossfadealpha-not-working/143419

            // image.color = Color.HSVToRGB( 0, 1, 1);
            // print("Image Colour: " + image.color);

            image.canvasRenderer.SetColor( Color.HSVToRGB( 0, 1, 1) );
            image.CrossFadeColor( Color.HSVToRGB(0, 0, 1), 0.35f, false, false); // поставил ignoreTimeScale = false, так как было бы полезно во время паузы останавливать анимацию подсветки

            // StartCoroutine(HighlightMisspell());
            // print(spell.name.ToLower()); // пример
        }

    }

    // public IEnumerator HighlightMisspell(){
    //     for ( int colourSwitch = 100; colourSwitch >= 0; colourSwitch-- ){
    //         image.CrossFadeColor()
    //     }
    // }
}
