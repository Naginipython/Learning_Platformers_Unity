using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        //alternatively, could have done other.gameObject.name == "Player"
        if (other.CompareTag("Player")) {
            Debug.Log(SceneManager.GetActiveScene().name+" Complete!");
            //When we go into File > Build Settings we can list the scenes in the build. Here, we simply add the next.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
