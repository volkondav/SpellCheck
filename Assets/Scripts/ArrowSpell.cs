using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ArrowSpell : MonoBehaviour
{
    [SerializeField] private float SpellSpeed;
    private Rigidbody2D spellBody;
    private float spellXPosition;

    // Start is called before the first frame update
    void Awake(){
        spellBody = GetComponent<Rigidbody2D>();

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
        if ( spellXPosition > 11 ){
            Destroy(gameObject);
            // print("Entered if");
        }
    }
}
