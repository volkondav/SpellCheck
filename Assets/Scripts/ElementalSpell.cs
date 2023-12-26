using System.Collections;
using UnityEngine;

public class ElementalSpell : Spell
{
    // [SerializeField] private ScriptableElementalSpell _spellAttribute;
    [SerializeField] private float _spellSpeed;
    [SerializeField] private float _explosionTime;

    private Transform Explosion;
    private Rigidbody2D spellBody;
    private float spellXPosition;

    // Start is called before the first frame update
    void Awake(){
        spellBody = GetComponent<Rigidbody2D>();
        Explosion = this.gameObject.transform.GetChild(0);

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
        spellXPosition = transform.position.x;
        // print(spellXPosition);
        if ( spellXPosition >= 4.5f ){
            StartCoroutine(ExplosionActive());
        }
    }

    IEnumerator ExplosionActive(){
        // print("entered");
        spellBody.velocity = new Vector2(0,0);
        Explosion.gameObject.SetActive(true);
        yield return new WaitForSeconds(_explosionTime);
        Destroy(gameObject);
    }
}
