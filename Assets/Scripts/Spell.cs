using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    // пока вместо координат используется строка с типом заклинания, по которой уже и определяется точка создания
    // [SerializeField] public Vector2 SpawnPosition;

    // на данный момент существуют два типа характеристик заклинаний:
    // 1. (attack) Атака. Создаёт заклинание перед персонажем
    // 2. (buff) Бафф. Создаёт заклинание как дочерний объект от персонажа в точке с ним
    [SerializeField] public string SpellCharacteristics;
    [SerializeField] public int DirectDamage;
    [SerializeField] public int DamageOT;
    [SerializeField] public int DOTTimes;

}
