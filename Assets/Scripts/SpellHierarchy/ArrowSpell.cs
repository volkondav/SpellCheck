using System;
using UnityEngine;

public class ArrowSpell : Spell
{
    public float SpellSpeed;
    private Rigidbody2D _spellBody;
    private float MinimalSpeed { get; } = 0.5f;

    void Awake()
    {
        _spellBody = GetComponent<Rigidbody2D>();
        // transform.Translate( 0, UnityEngine.Random.Range( -1f, 0 ), 0 );
    }
    virtual protected void Start()
    {
        // важное замечание: разворот объекта на 180 градусов вокруг оси y не изменяет направление его скорости
        // таким образом, если нужно поменять направление движения объекта, то нужно менять и знак скорости
        switch ( transform.eulerAngles.y ){
            case 0:
                _spellBody.velocity = new Vector2(SpellSpeed, 0);
                break;
            case 180:
                _spellBody.velocity = new Vector2(SpellSpeed * -1, 0);
                break;
            default:
                Debug.Log("This object \"" + transform.name + "\" has unpredicted euler angles: " + transform.eulerAngles.y, transform.gameObject );
                break;
        }
    }

    void FixedUpdate()
    {
        CheckForMinimalSpeed();
        CheckForFinalPosition();
    }

    public void CheckForMinimalSpeed(){
        if ( Mathf.Abs( GetComponent<Rigidbody2D>().velocity.x ) < MinimalSpeed )
            InitiateSelfDestruction("minimal speed");
    }

    public void CheckForFinalPosition(){
        if ( Mathf.Abs( transform.position.x ) > 11 )
            InitiateSelfDestruction("final position");
    }

    void OnTriggerEnter2D(Collider2D collision){
        if ( collision.gameObject.layer == 6 )
            StartCoroutine ( DelayedSelfDestruction() );
    }
    
}
