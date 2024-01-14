using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpellRenderer : MonoBehaviour
{
    [SerializeField] private string _currentString;
    private RectTransform _inputTransform;
    private TMP_InputField _inputComponent;
    private CanvasGroup _canvasgroupComponent;
    private PlayerMovement _playerMovement;

    // [SerializeField] private RectTransform _inputTransform;
    // [SerializeField] private TMP_InputField _inputComponent;
    // [SerializeField] private CanvasGroup _canvasgroupComponent;
    // [SerializeField] private PlayerSpellEvents _playerSpellEvents;

    // private int timesTextChanged = -1;
    // private int myCaretPosition = 0;

    // [SerializeField] private TextMeshProUGUI textComponent;

    // Start is called before the first frame update
    void Awake()
    {
        // inputTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
        _playerMovement = GetComponent<PlayerMovement>();

        _inputTransform = this.transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
        Assert.IsNotNull( _inputTransform, "Component reference for RectTransform from InputField is missing, check hierarchy structure");

        _inputComponent = GetComponentInChildren<TMP_InputField>();
        Assert.IsNotNull( _inputComponent, "Component reference for TMP_InputField from InputField is missing, check hierarchy structure");

        _canvasgroupComponent = this.transform.GetChild(0).GetChild(1).GetComponent<CanvasGroup>();
        Assert.IsNotNull( _canvasgroupComponent, "Component reference for CanvasGroup from InputField is missing, check hierarchy structure");

    }

    // Update is called once per frame
    void Update()
    {
        _inputComponent.ActivateInputField();
        UpdateCaretPosition();
        // print(inputComponent.caretPosition);
        if ( _currentString == "" )
            // inputTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0); создаёт неприятные ошибки в расчёте всех окон
            _canvasgroupComponent.alpha = 0;
        else
            _canvasgroupComponent.alpha = 1;
            
    }
        // вот что я понял:
        // 1. (inputComponent.text = s) снова вызывает ивент TextChanged, но при этом не передаёт новую позицию каретки
        // 2. ивент TextChanged обновляет позицию каретки сркытно в самом конце
    public void UpdateCaretPosition(){
        if ( _playerMovement.newSideCaretPosition != -1 ){
             _inputComponent.caretPosition = _playerMovement.newSideCaretPosition;
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
        _inputComponent.text = s;

        // print("End modifications: " + inputComponent.caretPosition + " " + timesTextChanged);
        // inputComponent.caretPosition = inputComponent.caretPosition - timesTextChanged;
        // inputComponent.caretPosition -= timesTextChanged;
        // print("End event: " + inputComponent.caretPosition + " " + timesTextChanged);
        // if ( timesTextChanged > 0 )
        //     myCaretPosition--;
        // timesTextChanged--;

        _currentString = s;
        _inputComponent.ForceLabelUpdate(); // обязательный форс апдейт, без него не учитывается длина текста в inputComponent.preferredWidth
        // textComponent.ForceMeshUpdate(); наверное, необязательный форс апдейт, но если будут ошибки, то можно включить
        // print("After force: " + inputComponent.caretPosition + " " + timesTextChanged);

        if ( s.EndsWith(' ') )
            _inputTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 22f + _inputComponent.preferredWidth );
        else
            _inputTransform.SetSizeWithCurrentAnchors( RectTransform.Axis.Horizontal, 6f + _inputComponent.preferredWidth );

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
        _currentString = s;
        // print("From SubmitSpell: " + s);
        // inputComponent.text = ""; очистка текста происходит в SpellCaster.cs при успешном соотвествии заклинания
        // playerSpellEvents.Invoke("PlayerCastsASpell", 0);
        // _playerSpellEvents.PlayerCastsASpell.Invoke(s);
        PlayerSpellEvents.PlayerSpellEventsReference.PlayerCastsASpell.Invoke(s);
    }


}
