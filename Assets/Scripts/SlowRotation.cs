using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRotation : MonoBehaviour
{
    [SerializeField] private float _degreesPerSecond;
    void Start()
    {
        // GetComponent<Rigidbody2D>().AddTorque( _degreesPerSecond );
        GetComponent<Rigidbody2D>().angularVelocity = _degreesPerSecond;
    }
}
