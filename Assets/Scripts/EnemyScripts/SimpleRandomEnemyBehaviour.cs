using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRandomEnemyBehaviour : CharacterBasics
{
    private ScriptableSpellList enemySpellList;
    private SpellCaster enemySpellCaster;
    private GameObject currentSpellToCast;
    public float TimeForOneLetter;

    void Awake()
    {
        enemySpellList = GetComponent<EnemySpellBook>().enemySpellBook[0];
        enemySpellCaster = GetComponent<SpellCaster>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // StartCasting();
        StartCoroutine( StartCasting() );
    }

    IEnumerator StartCasting()
    {
        if ( IsAbleToMove ){
            switch ( transform.position.y ){
                case 1.5f:
                    transform.Translate( new Vector3( 0, -2, 0) );
                    break;
                case -0.5f:
                    if ( Random.Range( 0 , 2 ) == 1 )
                        transform.Translate( new Vector3( 0, 2, 0) );
                    else
                        transform.Translate( new Vector3( 0, -2, 0) );
                    break;
                case -2.5f:
                    transform.Translate( new Vector3( 0, 2, 0) );
                    break;
                default:
                    Debug.Log("Something terrible happened, the object \"" + transform.name + "\" is not in a predicted position. Current position y-axis: " + transform.position.y, transform.gameObject );
                    break;
            }
        }

        currentSpellToCast = enemySpellList.spellPrefabs[ Random.Range( 0, enemySpellList.spellPrefabs.Count ) ];
        // StartCoroutine( EnemyStartedCasting( currentSpellToCast.name.Length ) );
        yield return new WaitForSeconds( currentSpellToCast.name.Length * TimeForOneLetter );
        enemySpellCaster.CastASpell( currentSpellToCast, -1 );
        yield return new WaitForSeconds( 0.3f );
        StartCoroutine( StartCasting() );
        // print("Couroutine terminated");
    }

    IEnumerator EnemyStartedCasting( int castDuration )
    {

        yield return new WaitForSeconds(castDuration);
    }

}
