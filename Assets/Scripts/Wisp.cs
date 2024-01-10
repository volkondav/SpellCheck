using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wisp : ArrowSpell
{
    [SerializeField] private float _periodForOscillation;
    [SerializeField] private float _amplitude; // неточное значение -- выбирал на глаз, а не из расчётов
    // private float[] debugArray = new float[3];
    
    void Update(){
        // debugArray[0] = Time.time * _periodForOscillation;
        // debugArray[1] = MathF.Sin( Time.time * _periodForOscillation );
        // debugArray[2] = Mathf.Sin( Time.time * _periodForOscillation ) * Time.deltaTime * _amplitude;
        
        // полный период функции sin(x) равен 2*pie или примерно 6.3 секунды
        transform.Translate( 0, Mathf.Sin( Time.time * _periodForOscillation ) * Time.deltaTime * _amplitude, 0 );
    }

    void OnTriggerEnter2D( Collider2D collision ){
        // Debug.Log("OnTriggerEnter2D from Wisp with " + collision.name, collision.gameObject );
    }

}
