using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpell : Spell
{
    [SerializeField] private float _durationTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WallActive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WallActive(){
        yield return new WaitForSeconds(_durationTime);
        Destroy(gameObject);
    }
}
