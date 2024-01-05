using UnityEngine;

public class DarkInteractions : MonoBehaviour
{
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
                Destroy(gameObject);
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
}
