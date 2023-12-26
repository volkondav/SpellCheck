using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalSpell : MonoBehaviour
{
    [SerializeField] private float SpellSpeed;
    [SerializeField] private float ExplosionTime;
    private Transform Explosion;
    private Rigidbody2D spellBody;
    private float spellXPosition;

    // Start is called before the first frame update
    void Awake(){
        spellBody = GetComponent<Rigidbody2D>();
        Explosion = this.gameObject.transform.GetChild(0);
    }
    void Start()
    {
        spellBody.velocity = new Vector2(SpellSpeed,0);
        
    }

    // Update is called once per frame
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
        yield return new WaitForSeconds(ExplosionTime);
        Destroy(gameObject);
    }
}
