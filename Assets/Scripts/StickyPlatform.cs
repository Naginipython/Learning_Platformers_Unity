using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour {
    
    private void OnCollisionEnter(Collision collision) {
        //If the collider's name is Player, then we set the current it's parent to the gameObject this script attached to.
        if (collision.gameObject.name == "Player") {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.gameObject.name == "Player") {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
