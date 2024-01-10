using System.Collections;
using UnityEngine;

public class ElementalSpell : DamagingSpell
{
    // [SerializeField] private ScriptableElementalSpell _spellAttribute;
    [SerializeField] private float _spellSpeed;
    [SerializeField] private float _explosionTime;
    [SerializeField] private GameObject _explosionNova;

    // private Transform Explosion;
    private Rigidbody2D spellBody;
    private float spellXPosition;

    // Start is called before the first frame update
    override protected void Awake(){
        base.Awake();

        spellBody = GetComponent<Rigidbody2D>();

        // Explosion = this.gameObject.transform.GetChild(0);
        // damage = _spellAttribute.damage;
        // _spellSpeed = _spellAttribute.spellSpeed;
        // _explosionTime = _spellAttribute.explosionTime;
    }
    new void Start()
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

    new void FixedUpdate()
    {
        // spellXPosition = transform.position.x;
        // print(spellXPosition);
        CheckForFinalPosition();
    }

    public void CheckForFinalPosition(){
        // if ( transform.position.x >= 4.5f && spellBody.velocity.x != 0 ){
        //     StartCoroutine(ExplosionActive());
        // }
        switch ( transform.eulerAngles.y ){
            case 0:
                if ( transform.position.x >= 4.5f && spellBody.velocity.x != 0 )
                    StartCoroutine(ExplosionActive());
                break;
            case 180:
                if ( transform.position.x <= -4.5f && spellBody.velocity.x != 0 )
                    StartCoroutine(ExplosionActive());
                break;
            default:
                Debug.Log("This object \"" + transform.name + "\" has unpredicted euler angles: " + transform.eulerAngles.y, transform.gameObject );
                break;
        }
    }

    IEnumerator ExplosionActive(){
        // print("entered");
        spellBody.velocity = new Vector2(0,0);
        // Explosion.gameObject.SetActive(true);
        Instantiate(_explosionNova, this.gameObject.transform );
        yield return new WaitForSeconds(_explosionTime);
        InitiateDeath();
    }

    void InitiateDeath(){
        Destroy(gameObject);
    }
}
