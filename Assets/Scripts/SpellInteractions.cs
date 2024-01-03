using Unity.VisualScripting;
using UnityEngine;

public class SpellInteractions : MonoBehaviour
{
    // нанесение урона перенесно в скрипт DamageDealer
    // этот скрипт отвечает за взаимодействиями между заклинаниями разных стихий

    // private int _directDamage;
    // private int _damageOT;
    // private int _dotTimes;


    // private void Awake()
    // {
    //     _directDamage = GetComponent<Spell>().DirectDamage;
    //     _damageOT = GetComponent<Spell>().DamageOT;
    //     _dotTimes = GetComponent<Spell>().DOTTimes;
    // }

    // private void DealDamage(Collider2D targetCollider)
    // {
    //     if (targetCollider.TryGetComponent<HealthManager>(out HealthManager healthManager))
    //     {
    //         healthManager.TakeDirectDamage(_directDamage);
    //         healthManager.ApplyDOT(_damageOT, _dotTimes);
    //     }
    // }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Activated OnTriggerEnter2D: " + gameObject.name + " entered " + collision.name, gameObject);
        // DealDamage(collision, _directDamage); если честно, я плохо понимаю, зачем отдельно передавать урон в виде переменной, которая и так доступна в скрипте
        int layer = collision.gameObject.layer;
        switch ( layer ){
            case 6: // на время написания кода layer 6 -- это слой Characters
                // DealDamage(collision);
                break;   
            case 7: // на время написания кода layer 7 -- это слой Ice
                InitiateDeath( collision.gameObject );
                break;           
            case 8: // на время написания кода layer 8 -- это слой Fire
                InitiateDeath( collision.gameObject );
                break;
            default:
                // print("Could not retrieve a valid layer for: " + collision.name );
                Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
                break;
            }
        // if ( collision.gameObject.layer == 8 ) // на время написания кода layer 8 -- это слой Player
        //     DealDamage(collision);
    }
    public void InitiateDeath( GameObject collisionGameObject ){
        // print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
        Debug.Log(this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
        Destroy(gameObject);
    }
        
}