using System.Collections;
using UnityEngine;

abstract public class Spell : MonoBehaviour
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

    // дополнительно добавить сюда имплементацию скрипта GetAnimationClipLength,
    // как только будут готовы анимации и понятная общая структура их реализации

    virtual public void InitiateSelfDestruction(){
        Destroy( this.gameObject );
    }

    virtual public void InitiateSelfDestruction( string causeOfDeath ){
        print("The cause of death is: " + causeOfDeath);
        Destroy( this.gameObject );
    }

    virtual public void InitiateSelfDestruction( GameObject collisionGameObject ){

        // print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
        // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
        // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, this.gameObject );
        Destroy( this.gameObject );
    }

    // этот метод нужно вызывать, если необходимо, чтобы сначала отработали все заходы в OnTriggerEnter, а затем уже объект уничожился
    public IEnumerator DelayedSelfDestruction(){
        yield return new WaitForFixedUpdate();
        // print("DelayedSelfDestruction finished");
        Destroy( this.gameObject );
    }
    public IEnumerator DelayedSelfDestruction( GameObject collisionGameObject ){
        
        // print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
        // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
        // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, this.gameObject );
        yield return new WaitForFixedUpdate();
        // print("DelayedSelfDestruction finished");
        Destroy( this.gameObject );
    }

}
