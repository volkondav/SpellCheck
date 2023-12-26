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

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputComponent;
    public int newSideCaretPosition = -1;
    
    // важное замечание: ивент Up или Down с контекстом started или performed срабатывают раньше, чем каретка в InputField перемещается в начало строки
    // таким образом возможно запонмить расположение каретки при нажатии стрелки вверх или стрелки вниз прежде, чем она переместится
    
    void Awake(){
        
    }
    
    public void Up(InputAction.CallbackContext context){
        // print(inputComponent.caretPosition + "" + context);
        if ( context.performed ){
            newSideCaretPosition = inputComponent.caretPosition;
            if ( transform.position.y < 1.5f )
                transform.Translate(0,2f,0);
        }
    }

    public void Down(InputAction.CallbackContext context){
        // print(inputComponent.caretPosition + "" + context);
        if ( context.performed ){
            newSideCaretPosition = inputComponent.caretPosition;
            if ( transform.position.y > -2.5f )
                transform.Translate(0,-2f,0);
        }
    }

    // public void TestEvent(){
    //     print("From TestEvent");
    // }

    void Start(){

    }

    void Update()
    {
        
        // print(inputComponent.caretPosition);
    }
}
