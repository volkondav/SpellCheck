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

    [SerializeField] private ScriptableSpellList interactionSpellList;

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
                    case 6: // Characters
                        // DealDamage(collision);   
                        break;
                    case 7: // Ice
                        IceIce();
                        InitiateDeath(collision.gameObject);
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
                    case 6: // Characters
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
                    case 6: // Characters
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
                    case 6: // Characters
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
                Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
                break;


        // // Debug.Log("Activated OnTriggerEnter2D: " + gameObject.name + " entered " + collision.name, gameObject);
        // // DealDamage(collision, _directDamage); если честно, я плохо понимаю, зачем отдельно передавать урон в виде переменной, которая и так доступна в скрипте
        // int layer = collision.gameObject.layer;
        // switch ( layer ){
        //     case 6: // на время написания кода layer 6 -- это слой Characters
        //         // DealDamage(collision);
        //         break;   
        //     case 7: // на время написания кода layer 7 -- это слой Ice
        //         InitiateDeath( collision.gameObject );
        //         break;           
        //     case 8: // на время написания кода layer 8 -- это слой Fire
        //         InitiateDeath( collision.gameObject );
        //         break;
        //     default:
        //         // print("Could not retrieve a valid layer for: " + collision.name );
        //         Debug.Log( "Could not retrieve a valid layer for: " + collision.name, collision.gameObject );
        //         break;
        // }
        }
    }
    public void InitiateDeath( GameObject collisionGameObject ){
        // print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
        Debug.Log(this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
        Destroy(gameObject);
    }

    public void IceIce()
    {
        int directDamage = GetComponent<DamagingSpell>().DirectDamage;
        Vector2 spellSpeed = GetComponent<Rigidbody2D>().velocity;

        GameObject miniArrow = interactionSpellList.spellPrefabs[0];
        var positions = new List<float> { 1.5f, -0.5f, -2.5f };

        positions.Remove(transform.position.y);
        float randomPosition = positions[Random.Range(0, positions.Count - 1)];
        Vector3 spawnPosition = new Vector3(transform.position.x, randomPosition);

        miniArrow = Instantiate(miniArrow, spawnPosition, new Quaternion());
        miniArrow.GetComponent<DamagingSpell>().DirectDamage = directDamage / 2;
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