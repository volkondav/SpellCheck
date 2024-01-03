using System.Collections.Generic;
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

    [SerializeField] private ScriptableSpellsDictionary interactionSpellsDictionary;

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * Debug.Log("Activated OnTriggerEnter2D: " + gameObject.name + " entered " + collision.name, gameObject);
         * DealDamage(collision, _directDamage); если честно, я плохо понимаю, 
         *  зачем отдельно передавать урон в виде переменной, которая и так доступна в скрипте
         * Layers:
         *  6 - Characrters
         *  7 - Ice
         *  8 - Fire
         *  9 - Dark
         *  10 - Light
         */
        int thisLayer = gameObject.layer; 
        int otherLayer = collision.gameObject.layer;
        switch (thisLayer)
        {
            case 7: // Ice
                switch (otherLayer)
                {
                    case 6: // Characrters
                        // DealDamage(collision);   
                        break;
                    case 7: // Ice
                        IceIce();
                        InitiateDeath(collision.gameObject);
                        InitiateDeath(gameObject);
                        break;
                    case 8: // Fire
                        break;
                    case 9: // Dark
                        break;
                    case 10: // Light
                        break;
                    default:
                        print("Could not retrieve a valid layer for: " + collision.name);
                        break;
                }
                break;
            case 8: // Fire
                switch (otherLayer)
                {
                    case 6: // Characrters
                        // DealDamage(collision);   
                        break;
                    case 7: // Ice
                        break;
                    case 8: // Fire
                        break;
                    case 9: // Dark
                        break;
                    case 10: // Light
                        break;
                    default:
                        print("Could not retrieve a valid layer for: " + collision.name);
                        break;
                }
                break;
            case 9: // Dark
                switch (otherLayer)
                {
                    case 6: // Characrters
                        // DealDamage(collision);   
                        break;
                    case 7: // Ice
                        break;
                    case 8: // Fire
                        break;
                    case 9: // Dark
                        break;
                    case 10: // Light
                        break;
                    default:
                        print("Could not retrieve a valid layer for: " + collision.name);
                        break;
                }
                break;
            case 10: // Light
                switch (otherLayer)
                {
                    case 6: // Characrters
                        // DealDamage(collision);   
                        break;
                    case 7: // Ice
                        break;
                    case 8: // Fire
                        break;
                    case 9: // Dark
                        break;
                    case 10: // Light
                        break;
                    default:
                        print("Could not retrieve a valid layer for: " + collision.name);
                        break;
                }
                break;
            default:
                print("Could not retrieve a valid layer for: " + gameObject.name);
                break;
        }
    }
    public void InitiateDeath(GameObject gameObject)
    {
        Destroy(gameObject);
    }

    public void IceIce()
    {
        int directDamage = GetComponent<Spell>().DirectDamage;
        Vector2 spellSpeed = GetComponent<Rigidbody2D>().velocity;

        GameObject miniArrow = interactionSpellsDictionary.spellPrefabs[0];
        var positions = new List<float> { 1.5f, -0.5f, -2.5f };

        positions.Remove(transform.position.y);
        float randomPosition = positions[Random.Range(0, positions.Count - 1)];
        Vector3 spawnPosition = new Vector3(transform.position.x, randomPosition);

        miniArrow = Instantiate(miniArrow, spawnPosition, new Quaternion());
        miniArrow.GetComponent<Spell>().DirectDamage = directDamage / 2;
        miniArrow.GetComponent<Rigidbody2D>().velocity = spellSpeed / 2;
        miniArrow.transform.rotation = transform.rotation;


        //positions.Remove(randomPosition);
        //randomPosition = positions[Random.Range(0, positions.Count - 1)];
        //spawnPosition = new Vector3(transform.position.x, randomPosition);
        //Instantiate(miniArrow, spawnPosition, new Quaternion());
    }

    public void LightLight()
    {
        
    }
}