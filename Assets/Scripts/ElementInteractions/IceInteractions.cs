using System.Collections.Generic;
using UnityEngine;

// этот скрипт отвечает за взаимодействие заклинаний стихии льда с другими стихиями
public class IceInteractions : MonoBehaviour
{
    [SerializeField] private GameObject _miniIceArrow;

    void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * Layers:
         *  6 - Characrters
         *  7 - Ice
         *  8 - Fire
         *  9 - Light
         *  10 - Dark
         */
        int otherLayer = collision.gameObject.layer;
        switch (otherLayer)
        {
            case 6: // Characters
                break;
            case 7: // Ice
                IceInteraction();
                InitiateDeath(collision.gameObject);
                break;
            case 8: // Fire
                
                break;
            case 9: // Light

                break;
            case 10: // Dark

                break;
            default:
                //Debug.Log("Could not retrieve a valid layer for: " + collision.name, collision.gameObject);
                break;
        }
    }
    public void InitiateDeath(GameObject collisionGameObject)
    {
        //print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
        //Debug.Log(this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject);
        Destroy(gameObject);
    }

    public void IceInteraction()
    {
        var positions = new List<float> { 1.5f, -0.5f, -2.5f };

        positions.Remove(transform.position.y);
        float randomPosition = positions[Random.Range(0, positions.Count)];
        Vector3 spawnPosition = new Vector3(transform.position.x, randomPosition);

        GameObject miniArrow = Instantiate(_miniIceArrow, spawnPosition, transform.rotation);
        miniArrow.GetComponent<ArrowSpell>().HalveSpeedAndDamage();

        //positions.Remove(spawnPosition.y); // если требуется, чтобы мини стрелы от одной обычной стрелы, не спавнились на одной линии
        randomPosition = positions[Random.Range(0, positions.Count)];
        spawnPosition = new Vector3(transform.position.x, randomPosition);

        miniArrow = Instantiate(_miniIceArrow, spawnPosition, transform.rotation);
        miniArrow.GetComponent<ArrowSpell>().HalveSpeedAndDamage();
    }
}
