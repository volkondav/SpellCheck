using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class DarkInteractions : ElementalInteractions
{
    [SerializeField] private GameObject _wispToSpawn;
    [SerializeField] private ScriptableSpellList _fireSpellList;
    public bool IsAbleToInteract = true;

    override protected void WithIce( Collider2D collision ) { /* there is no interaction */ }

    override protected void WithFire( Collider2D collision ){

        // string newFireSpellName = this.gameObject.name.Replace("тьмы", "огня");

        // foreach (GameObject spell in _fireSpellList.spellPrefabs)
        // {
        //     // наверное, не самая хорошая практика сравнивать строки с помощью операндов,
        //     // так как результат таких операций часто не совпадают с интуитивным представлением,
        //     // а функция операции труднее читается
        //     // if ( spell.name <= newFireSpellName )

        //     if ( newFireSpellName.Contains( spell.name ) )
        //     {
        //         // Instantiate( spell, new Vector3( transform.position.x, transform.position.y + 1f ), this.transform.rotation);
        //         switch ( spell.GetComponent<Spell>().spellCharacteristics ){
        //             case Spell.SpellCharacteristics.Standalone:
        //                 Instantiate( spell, this.transform.position , this.transform.rotation);
        //                 break;
        //             case Spell.SpellCharacteristics.AsChild:
        //                 Instantiate( spell, this.transform.parent );
        //                 break;
        //             default:
        //                 Debug.Log("Could not retrive valid Spell.SpellCharacteristics for " + spell.name, spell );
        //                 break;
        //         }
        //         // GameObject newSpell = Instantiate(spell, darkSpellToReplace.transform.position, darkSpellToReplace.transform.rotation);
        //         // newSpell.layer = 8;
        //         _spellComponent.InitiateSelfDestruction();
        //         break;
        //     }
        // }
    }

    override protected void WithLight( Collider2D collision ){

        _spellComponent.InitiateSelfDestruction( collision.gameObject );
    }

    override protected void WithDark( Collider2D collision ){

        if ( IsAbleToInteract && collision.GetComponent<DarkInteractions>() != null ){
            collision.GetComponent<DarkInteractions>().IsAbleToInteract = false;
            // отправляю здесь в функцию позицию точки на периметре коллайдера, которая является ближайшей между коллайдером одного объекта и центром другого
            Instantiate( _wispToSpawn, collision.ClosestPoint( this.transform.position ) , new Quaternion() );
        }
        else
            IsAbleToInteract = true;
    }

}
