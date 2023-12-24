using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PlayerMovement : MonoBehaviour
{
    
    public void Up(InputAction.CallbackContext context){
        if ( context.performed )
            if ( transform.position.y < 1.5f )
                transform.Translate(0,2f,0);
    }

    public void Down(InputAction.CallbackContext context){
        if ( context.performed )
            if ( transform.position.y > -2.5f )
                transform.Translate(0,-2f,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
