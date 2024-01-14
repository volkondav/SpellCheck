using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSpellEvents : MonoBehaviour
{
    static public PlayerSpellEvents PlayerSpellEventsReference;
    public UnityEvent<string> PlayerCastsASpell;
    public UnityEvent<GameObject> ZoneSpawned, ActivateDarkExplosion;
    public UnityEvent DummyEvent;
    
    void Awake()
    {
        PlayerSpellEventsReference = this.gameObject.GetComponent<PlayerSpellEvents>();
    }

}
