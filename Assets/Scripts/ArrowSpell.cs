using UnityEngine;

public class ArrowSpell : Spell
{
    [SerializeField] private ScriptableArrowSpell _spellAttribute;
    private float _spellSpeed;
    private Rigidbody2D spellBody;
    private float spellXPosition;

    void Awake()
    {
        spellBody = GetComponent<Rigidbody2D>();
        _spellSpeed = _spellAttribute.spellSpeed;
        damage = _spellAttribute.damage;
    }
    void Start()
    {
        spellBody.velocity = new Vector2(_spellSpeed, 0);
    }

    void FixedUpdate()
    {
        spellXPosition = transform.position.x;
        // print(spellXPosition);
        if ( spellXPosition > 11 ){
            Destroy(gameObject);
            // print("Entered if");
        }
    }
}
