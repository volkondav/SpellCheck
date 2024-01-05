using System;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    // на данный момент существуют три типа характеристик для создания заклинания:
    // 1. (InFront) заклинание появляется перед персонажем
    // 2. (AtCharacter) заклинание появляется в точке персонажа
    // 3. (WithParent) заклинание появляется в точке персонажа и становится дочерним ему объектом
    public enum SpellCharacteristics {
        // InFront, AtCharacter, WithParent
        Standalone, AsChild
    }

    public SpellCharacteristics spellCharacteristics;

}
