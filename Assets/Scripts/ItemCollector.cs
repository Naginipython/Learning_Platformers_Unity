using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//idk why but if I don't have this TextMeshPro doesn't work
namespace TMPro.Examples
{
    public class ItemCollector : MonoBehaviour {
        int coinCount = 0;
        [SerializeField] AudioSource collectionSound;

        public TextMeshProUGUI coinsText;
        private TextMeshPro m_textMeshPro;

        private void OnTriggerEnter(Collider other) {
            //Tutorial used other.gameObject.CompareTag()... I found I don't need it, or do I?
            if (other.CompareTag("Coin")) {
                coinCount++;
                //If I don't add .gameObject nothing happens
                Destroy(other.gameObject);
                Debug.Log("Player got Coin! Coin #"+coinCount);
                coinsText.SetText("Coins: " + coinCount);
                collectionSound.Play();
            }
        }
    }
}
