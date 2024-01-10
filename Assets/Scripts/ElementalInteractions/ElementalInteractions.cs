using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ElementalInteractions : MonoBehaviour
{
    protected Spell _spellComponent;

    void Awake(){
        _spellComponent = GetComponent<Spell>();
    }

    // public void InitiateSelfDestruction( GameObject collisionGameObject ){

    //     // print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
    //     // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
    //     // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, this.gameObject );
    //     Destroy( this.gameObject );
    // }

    // // этот метод нужно вызывать, если необходимо, чтобы сначала отработали все заходы в OnTriggerEnter, а затем уже объект уничожился
    // public IEnumerator DelayedSelfDestruction( GameObject collisionGameObject ){
        
    //     // print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
    //     // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
    //     // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, this.gameObject );
    //     yield return new WaitForFixedUpdate();
    //     // print("DelayedSelfDestruction finished");
    //     Destroy( this.gameObject );
    // }
        
}