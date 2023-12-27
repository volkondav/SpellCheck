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
        // DealDamage(collision, _directDamage); если честно, я плохо понимаю, зачем отдельно передавать урон в виде переменной, которая и так доступна в скрипте
        int layer = collision.gameObject.layer;
        switch ( layer ){
            case 8: // на время написания кода layer 8 -- это слой Characters
                // DealDamage(collision);
                break;   
            case 6: // на время написания кода layer 6 -- это слой Ice
                InitiateDeath();
                break;           
            case 7: // на время написания кода layer 7 -- это слой Fire
                InitiateDeath();
                break;
            default:
                print("Could not retrieve a valid layer for: " + collision.name );
                break;
            }
        // if ( collision.gameObject.layer == 8 ) // на время написания кода layer 8 -- это слой Player
        //     DealDamage(collision);
    }
    public void InitiateDeath(){
        Destroy(gameObject);
    }
        
}