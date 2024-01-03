using UnityEngine;

public class ArrowSpell : Spell
{
    // [SerializeField] private ScriptableArrowSpell _spellAttribute;
    [SerializeField] public float _spellSpeed;
    private Rigidbody2D spellBody;
    private float spellXPosition;

    void Awake()
    {
        spellBody = GetComponent<Rigidbody2D>();
        // _spellSpeed = _spellAttribute.spellSpeed;
        // damage = _spellAttribute.damage;
        spellBody.velocity = new Vector2(_spellSpeed, 0);
    }
    void Start()
    {
    }

    void FixedUpdate()
    {
        // spellXPosition = transform.position.x;
        // print(spellXPosition);
        CheckForFinalPosition();
    }

    public void CheckForFinalPosition(){
        // if ( spellXPosition > 11 ){
        if ( transform.position.x > 11 ){
            Destroy(gameObject);
            // print("Entered if");
        }

    }
}
