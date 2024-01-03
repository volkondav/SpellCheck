using UnityEngine;

public class ArrowSpell : DamagingSpell
{
    // [SerializeField] private ScriptableArrowSpell _spellAttribute;
    [SerializeField] private float _spellSpeed;
    private Rigidbody2D spellBody;
    private float spellXPosition;

    void Awake()
    {
        spellBody = GetComponent<Rigidbody2D>();
        // _spellSpeed = _spellAttribute.spellSpeed;
        // damage = _spellAttribute.damage;
    }
    void Start()
    {   
        // spellBody.velocity = new Vector2(_spellSpeed,0);
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

    void InitiateDeath(){
        Destroy(gameObject);
    }

    public void HalveSpeedAndDamage()
    {
        _spellSpeed = _spellSpeed / 2;
        DirectDamage = DirectDamage / 2;
    }
}
