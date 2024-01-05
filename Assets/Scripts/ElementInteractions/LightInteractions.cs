using System.Collections.Generic;
using UnityEngine;

public class LightInteractions : MonoBehaviour
{
    [SerializeField] private GameObject _lightRing;

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
                break;
            case 8: // Fire
                FireInteraction(collision);
                InitiateDeath();
                break;
            case 9: // Light

                break;
            case 10: // Dark

                break;
            default:
                Debug.Log("Could not retrieve a valid layer for: " + collision.name, collision.gameObject);
                break;
        }
    }
    public void InitiateDeath()
    {
        Destroy(gameObject);
    }

    public void FireInteraction(Collider2D collision)
    {
        Vector3 contactPoint = gameObject.GetComponent<Collider2D>().ClosestPoint(collision.transform.position);
        GameObject lightRing = Instantiate(_lightRing, contactPoint, new Quaternion());
        lightRing.layer = 0;
    }
}
