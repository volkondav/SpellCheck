using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NovaSpell : DamagingSpell
{
    [SerializeField] private float _explosionTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NovaActive());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator NovaActive(){
        yield return new WaitForSeconds(_explosionTime);
        Destroy(gameObject);
    }
}
