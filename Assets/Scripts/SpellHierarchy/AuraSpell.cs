using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraSpell : DamagingSpell
{
    [SerializeField] private float _durationTime;
    // [SerializeField] private float _speed;

    // Start is called before the first frame update
    new void Start()
    {
        StartCoroutine(AuraActive());
        // GetComponent<Rigidbody2D>().velocity = new Vector2( _speed, 0);
    }

    IEnumerator AuraActive(){
        // print("NovaActive started");
        yield return new WaitForSeconds(_durationTime);
        Destroy(gameObject);
    }
}
