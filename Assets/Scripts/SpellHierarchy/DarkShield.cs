using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DarkShield : ShieldSpell
{
    [SerializeField] private int _blinkInterval;
    [SerializeField] private int _blinkDuration;
    [SerializeField] private CanvasGroup _canvasGroupComponent;
    private SpriteRenderer _spriteComponent, _characterSpriteComponent;

    void Awake(){
        _spriteComponent = GetComponent<SpriteRenderer>();
        _characterSpriteComponent = transform.parent.GetComponent<SpriteRenderer>();
        
        Assert.IsTrue( this.transform.parent.GetChild(0).GetChild(0).TryGetComponent<CanvasGroup>(out _canvasGroupComponent),
                                "HealthPoints object was not found at the specified index of 0,0 in the hierarchy" );
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine( Blinking() );
    }

    IEnumerator Blinking(){

        yield return new WaitForSeconds( _blinkInterval );
        yield return StartCoroutine( Invisible() );
        StartCoroutine( Blinking() );
    }

    IEnumerator Invisible(){

        _spriteComponent.color -= new Color( 0, 0, 0, 1);
        _characterSpriteComponent.color -= new Color( 0, 0, 0, 1);
        _canvasGroupComponent.alpha = 0;

        yield return new WaitForSeconds( _blinkDuration );

        _spriteComponent.color += new Color( 0, 0, 0, 1);
        _characterSpriteComponent.color += new Color( 0, 0, 0, 1);
        _canvasGroupComponent.alpha = 1;
    }

}
