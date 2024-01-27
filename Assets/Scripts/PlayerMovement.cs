using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro;
using System.Diagnostics;
using UnityEngine.Assertions;

public class PlayerMovement : CharacterBasics
{
    private TMP_InputField _inputComponent;
    // [SerializeField] private TMP_InputField _inputComponent;
    // public int newSideCaretPosition = -1;
    // public InputActionMap movementActionMap;
    
    // важное замечание: ивент Up или Down с контекстом started или performed срабатывают раньше, чем каретка в InputField перемещается в начало строки
    // таким образом возможно запомнить расположение каретки при нажатии стрелки вверх или стрелки вниз прежде, чем она переместится
    
    void Awake(){
        // movementActionMap = GetComponent<PlayerInput>().currentActionMap;

        _inputComponent = GetComponentInChildren<TMP_InputField>();
        Assert.IsNotNull( _inputComponent, "Component reference for TMP_InputField from InputField is missing, check hierarchy structure");

    }

    // необходимо работать с ActionMaps через объект, на котором добавлен компонент PlayerInput
    // это необходимо, так как если пытаться обратиться к определённой карте инпутов из другого скрипта,
    //              то такое обращение будет не как к референсу, а как к копии компонента, а потому не повлияет на желаемый объект
    // public void DisableMovement(){
    //     movementActionMap.Disable();
    // }
    // public void EnableMovement(){
    //     movementActionMap.Enable();
    // }

    public void Up(InputAction.CallbackContext context){
        // print(inputComponent.caretPosition + "" + context);
        if ( context.performed ){
            if (isLocalPlayer)
            {
                // newSideCaretPosition = _inputComponent.caretPosition;
                if ( IsAbleToMove && transform.position.y < 1.5f )
                    transform.Translate(0,2f,0);
            }
        }
    }

    public void Down(InputAction.CallbackContext context){
        // print(inputComponent.caretPosition + "" + context);
        if ( context.performed ){
            if (isLocalPlayer)
            {
                // newSideCaretPosition = _inputComponent.caretPosition;
                if ( IsAbleToMove && transform.position.y > -2.5f )
                transform.Translate(0,-2f,0);
            }
        }
    }

    // public void TestEvent(){
    //     print("From TestEvent");
    // }

}
