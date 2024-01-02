using System.Collections;
using UnityEngine;

public class ElementalSpell : Spell
{
    // [SerializeField] private ScriptableElementalSpell _spellAttribute;
    [SerializeField] private float _spellSpeed;
    [SerializeField] private float _explosionTime;
    [SerializeField] private GameObject _explosionNova;

    // private Transform Explosion;
    private Rigidbody2D spellBody;
    private float spellXPosition;

    // Start is called before the first frame update
    void Awake(){
        spellBody = GetComponent<Rigidbody2D>();

        // Explosion = this.gameObject.transform.GetChild(0);
        // damage = _spellAttribute.damage;
        // _spellSpeed = _spellAttribute.spellSpeed;
        // _explosionTime = _spellAttribute.explosionTime;
    }
    void Start()
    {
        spellBody.velocity = new Vector2(_spellSpeed,0);
    }

    void FixedUpdate()
    {
        // spellXPosition = transform.position.x;
        // print(spellXPosition);
        CheckForFinalPosition();
    }

    public void CheckForFinalPosition(){
        // if ( spellXPosition >= 4.5f ){
        if ( transform.position.x >= 4.5f && spellBody.velocity.x != 0 ){
            StartCoroutine(ExplosionActive());
        }

    }

    IEnumerator ExplosionActive(){
        // print("entered");
        spellBody.velocity = new Vector2(0,0);
        // Explosion.gameObject.SetActive(true);
        Instantiate(_explosionNova, this.gameObject.transform );
        yield return new WaitForSeconds(_explosionTime);
        Destroy( this.gameObject );
    }
}
