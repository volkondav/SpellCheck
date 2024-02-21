using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private GameObject _currentWall;
    
    void Update()
    {
        if ( _currentWall == null )
            ForgetWall();
    }

    public void RememberWall( GameObject wall ){
        if ( _currentWall )
            Destroy(_currentWall);
        _currentWall = wall;
    }

    public void ForgetWall(){
        _currentWall = null;
    }

}
