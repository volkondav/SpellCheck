using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour
{
    [SerializeField] private GameObject _currentZone;
    
    public void RememberZone( GameObject zone )
    {
        if ( _currentZone )
            Destroy(_currentZone);
        _currentZone = zone;
    }

    public void SpawnDarkExplosion( GameObject explosion ){
        if ( _currentZone != null )
            Instantiate( explosion, _currentZone.transform );
    }
}
