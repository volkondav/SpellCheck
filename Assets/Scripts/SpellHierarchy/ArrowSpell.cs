using UnityEngine;

public class ArrowSpell : DamagingSpell
{
    // [SerializeField] private ScriptableArrowSpell _spellAttribute;
    public float ArrowSpellSpeed;
    private Rigidbody2D _spellBody;
    private float spellXPosition;

    void Awake()
    {
        _spellBody = GetComponent<Rigidbody2D>();
        // _spellSpeed = _spellAttribute.spellSpeed;
        // damage = _spellAttribute.damage;
        transform.Translate( 0, UnityEngine.Random.Range( -1f, 0 ), 0 );
    }
    void Start()
    {   
        // spellBody.velocity = new Vector2(_spellSpeed,0);
        switch ( transform.eulerAngles.y ){
            case 0:
                _spellBody.velocity = new Vector2(ArrowSpellSpeed, 0);
                break;
            case 180:
                _spellBody.velocity = new Vector2(ArrowSpellSpeed * -1, 0);
                break;
            default:
                Debug.Log("This object \"" + transform.name + "\" has unpredicted euler angles: " + transform.eulerAngles.y, transform.gameObject );
                break;
        }
    }

    void FixedUpdate()
    {
        // spellXPosition = transform.position.x;
        // print(spellXPosition);
        CheckForFinalPosition();
    }

    public void CheckForFinalPosition(){
        switch ( transform.eulerAngles.y ){
            case 0:
                if ( transform.position.x > 11 )
                    InitiateDeath();
                break;
            case 180:
                if ( transform.position.x < -11 )
                    InitiateDeath();
                break;
            default:
                Debug.Log("This object \"" + transform.name + "\" has unpredicted euler angles: " + transform.eulerAngles.y, transform.gameObject );
                break;
        }
        // if ( transform.position.x > 11 ){
        //     Destroy(gameObject);
        //     // print("Entered if");
        // }

    }

    // важно, чтобы скрипт ArrowSpell стоял после скриптов DamageDealer и ElementalInteractions
    void OnTriggerEnter2D(Collider2D collision){
        if ( collision.gameObject.layer == 6 )
            InitiateDeath();
    }

    void InitiateDeath(){
        Destroy(gameObject);
    }

    public void HalveSpeedAndDamage()
    {
        ArrowSpellSpeed /= 2;
        DirectDamage /= 2;
    }
}
