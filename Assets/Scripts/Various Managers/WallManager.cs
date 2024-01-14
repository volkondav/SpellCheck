using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private GameObject _currentWall;
    
    public void RememberWall( GameObject wall )
    {
        if ( _currentWall )
            Destroy(_currentWall);
        _currentWall = wall;
    }

    // void Update()
    // {
    //     if ( _currentWall == null )
    //         ForgetWall();
    // }

    // public void ForgetWall()
    // {
    //     _currentWall = null;
    // }

}
