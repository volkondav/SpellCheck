using UnityEngine;

public class FireInteractions : MonoBehaviour
{
    [SerializeField] private ScriptableSpellList _darkSpellList;
    [SerializeField] private ScriptableSpellList _fireSpellList;

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
                break;
            case 9: // Light
                InitiateDeath();
                break;
            case 10: // Dark
                DarkInteraction(collision);
                break;
            default:
                //Debug.Log("Could not retrieve a valid layer for: " + collision.name, collision.gameObject);
                break;
        }
    }
    public void InitiateDeath()
    {
        Destroy(gameObject);
    }

    private void DarkInteraction(Collider2D collision)
    {
        string darkSpellName = collision.gameObject.name;
        string newFireSpell = darkSpellName.Replace("тьмы", "огня");

        
        foreach (GameObject spell in _fireSpellList.spellPrefabs)
        {
            if (spell.name == newFireSpell)
            {
                GameObject newSpell = Instantiate(spell, collision.transform.position, collision.transform.rotation);
                newSpell.layer = 8;
            }
        }

    }
}
