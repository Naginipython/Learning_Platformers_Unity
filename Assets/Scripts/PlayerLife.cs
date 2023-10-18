using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour {
    [SerializeField] float respawnTime = 1.3f;
    [SerializeField] float voidHeight = -2.5f;
    bool dead = false;

    [SerializeField] AudioSource deathSound;

    void Update() {
        if (transform.position.y < voidHeight && !dead) {
            dead = true;
            Debug.Log("Player fell into void");
            Die();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Enemy Body")) {
            Debug.Log("Enemy Hit Player");
            Die();
        }
    }

    void Die() {
        deathSound.Play();
        //Removes capsuleCollider, so the enemy can continue walking
        GetComponent<CapsuleCollider>().enabled = false;
        //removes meshRenderer, so you can't see me
        GetComponent<MeshRenderer>().enabled = false;
        //removes Rigidbody's kinematic, idk why
        GetComponent<Rigidbody>().isKinematic = true;
        //removes PlayerController, so I can't move afterwards
        GetComponent<PlayerController>().enabled = false;
        //This simply delays a function call, here being ReloadLevel()
        Invoke(nameof(ReloadLevel), respawnTime);
    }

    void ReloadLevel() {
        //using SceneManagement. We then Load the current Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
