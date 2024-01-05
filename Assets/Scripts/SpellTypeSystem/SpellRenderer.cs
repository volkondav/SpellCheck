using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpellRenderer : MonoBehaviour
{
    [SerializeField] private string currentString;
    [SerializeField] private RectTransform inputTransform;
    [SerializeField] private TMP_InputField inputComponent;
    [SerializeField] private CanvasGroup canvasgroupComponent;
    [SerializeField] private PlayerSpellEvents playerSpellEvents;

    private PlayerMovement _playerMovement;
    // private int timesTextChanged = -1;
    // private int myCaretPosition = 0;

    // [SerializeField] private TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Awake()
    {
        // inputTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        inputComponent.ActivateInputField();
        UpdateCaretPosition();
        // print(inputComponent.caretPosition);
        if ( currentString == "" )
            // inputTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0); создаёт неприятные ошибки в расчёте всех окон
            canvasgroupComponent.alpha = 0;
        else
            canvasgroupComponent.alpha = 1;
            
    }
        // вот что я понял:
        // 1. (inputComponent.text = s) снова вызывает ивент TextChanged, но при этом не передаёт новую позицию каретки
        // 2. ивент TextChanged обновляет позицию каретки сркытно в самом конце
    public void UpdateCaretPosition(){
        if ( _playerMovement.newSideCaretPosition != -1 ){
             inputComponent.caretPosition = _playerMovement.newSideCaretPosition;
            _playerMovement.newSideCaretPosition = -1;
        }
        // print("Updating caret position: " + inputComponent.caretPosition + "" + timesTextChanged);
        // if ( timesTextChanged > 0 ){
        //     inputComponent.caretPosition--;
        //     timesTextChanged--;
        // }
    }
    public void TextChanged(string s){
        // if (timesTextChanged == -1 )
        //     myCaretPosition = inputComponent.caretPosition;
        // print("Start event: " + inputComponent.caretPosition);
        // timesTextChanged++;
        // s = s.TrimStart();
        // s = s.RemoveConsecutiveCharacters(' ');

        if ( s.EndsWith("  "))
            s = s.Remove( s.Length - 1 );
        inputComponent.text = s;

        // print("End modifications: " + inputComponent.caretPosition + " " + timesTextChanged);
        // inputComponent.caretPosition = inputComponent.caretPosition - timesTextChanged;
        // inputComponent.caretPosition -= timesTextChanged;
        // print("End event: " + inputComponent.caretPosition + " " + timesTextChanged);
        // if ( timesTextChanged > 0 )
        //     myCaretPosition--;
        // timesTextChanged--;

        currentString = s;
        inputComponent.ForceLabelUpdate(); // обязательный форс апдейт, без него не учитывается длина текста в inputComponent.preferredWidth
        // textComponent.ForceMeshUpdate(); наверное, необязательный форс апдейт, но если будут ошибки, то можно включить
        // print("After force: " + inputComponent.caretPosition + " " + timesTextChanged);

        if ( s.EndsWith(' ') )
            inputTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 22f + inputComponent.preferredWidth );
        else
            inputTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 6f + inputComponent.preferredWidth );

        // inputTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 50 + textComponent.renderedWidth );

        // print("textcomponent.renderedwidth: " + textComponent.renderedWidth);
        // print("inputcomponent.preferredwidth: " + inputComponent.preferredWidth);

        // textComponent.SetText(s); не работает, так как текст меняется через TMP_InputField
        // textComponent.text = s; не работает, так как текст меняется через TMP_InputField
    }

    public void SubmitSpell(string s){
        // print("Entered SubmitSpell"); нет, заходит в ивент SubmitSpell всего один раз
        s = s.Trim();
        s = s.RemoveConsecutiveCharacters(' ');
        currentString = s;
        // print("From SubmitSpell: " + s);
        // inputComponent.text = ""; очистка текста происходит в SpellCaster.cs при успешном соотвествии заклинания
        // playerSpellEvents.Invoke("PlayerCastsASpell", 0);
        playerSpellEvents.PlayerCastsASpell.Invoke(s);
    }


}
