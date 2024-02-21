using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class IceTrap : Spell
{
    [SerializeField] private int _trapDuration;
    private Vector3 _freezePosition;
    private Transform _frozenCharacter;
    
    // пока такой вариант работает только для игрока, но не для нпс
    // void Start(){
    //     // GetComponentInParent<PlayerInput>().enabled = false;
    //     // GetComponentInParent<PlayerInput>().currentActionMap.Disable();
    //     // GetComponentInParent<PlayerMovement>().movementActionMap.Disable();
    //     GetComponentInParent<PlayerMovement>().DisableMovement();
    //     StartCoroutine( IceTrapActive( _trapDuration ) );
    // }

    void Awake(){

        // очень странно, но тут есть нюанс с методом GetComponentInParent
        // этот метод ищет компонент сначала у себя на объекте, а потом уже начинает искать в родителях
        // _frozenCharacter = GetComponentInParent<Transform>();

        // аналогично есть this.transform.root, но он возвращает самого дальнего возможного родителя, а не ближайшего
        _frozenCharacter = this.transform.parent.GetComponent<Transform>();
        _freezePosition = _frozenCharacter.position;
    }

    void Start(){
        StartCoroutine( IceTrapActive( _trapDuration ) );
    }

    void Update(){
        _frozenCharacter.position = _freezePosition;
    }

    IEnumerator IceTrapActive( int duration ){
        while( duration > 0 ){
            duration--;

            // нужно просто для того, чтобы в инспекторе легче отслеживать оставшееся время ловушки
            _trapDuration = duration;

            yield return new WaitForSeconds( 1 );
        }
        InitiateSelfDestruction();
    }

    // void OnDestroy(){
    //     // GetComponentInParent<PlayerInput>().enabled = true;
    //     // GetComponentInParent<PlayerInput>().currentActionMap.Enable();
    //     // GetComponentInParent<PlayerMovement>().movementActionMap.Enable();
    //     GetComponentInParent<PlayerMovement>().EnableMovement();
    // }
}
