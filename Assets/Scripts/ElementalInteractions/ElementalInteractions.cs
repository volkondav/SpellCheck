using Unity.VisualScripting;
using UnityEngine;

public class ElementalInteractions : MonoBehaviour
{
    public void InitiateSelfDestruction( GameObject collisionGameObject ){
        // print("GameObject with name \"" + gameObject.name + "\" was destroyed when colliding with layer " + layer);
        // Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, collisionGameObject );
        Debug.Log( this.gameObject.name + " was destroyed when colliding with " + collisionGameObject.name, this.gameObject );
        Destroy( this.gameObject );
    }
        
}