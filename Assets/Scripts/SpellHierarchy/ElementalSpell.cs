using System.Collections;
using UnityEngine;

public class ElementalSpell : Spell
{
    [SerializeField] private float _spellSpeed;
    [SerializeField] private float _explosionTime;
    [SerializeField] private GameObject _explosionNova;
    private Rigidbody2D spellBody;

    void Awake(){
        spellBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        switch ( transform.eulerAngles.y ){
            case 0:
                spellBody.velocity = new Vector2(_spellSpeed, 0);
                break;
            case 180:
                spellBody.velocity = new Vector2(_spellSpeed * -1, 0);
                break;
            default:
                Debug.Log("This object \"" + transform.name + "\" has unpredicted euler angles: " + transform.eulerAngles.y, transform.gameObject );
                break;
        }
    }

    void FixedUpdate()
    {
        CheckForFinalPosition();
    }

    public void CheckForFinalPosition(){
        if ( Mathf.Abs( transform.position.x ) >= 4.5f && spellBody.velocity.x != 0 ){
            StartCoroutine(ExplosionActive());
        }
    }

    IEnumerator ExplosionActive(){
        spellBody.velocity = new Vector2(0,0);
        Instantiate(_explosionNova, this.gameObject.transform );
        yield return new WaitForSeconds(_explosionTime);
        InitiateSelfDestruction();
    }

}
