using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField]private Text cherriesText;
    [SerializeField]private AudioSource collectSoundSource;

    private void OnTriggerEnter2D(Collider2D collision) {
        if( collision.gameObject.CompareTag("Cherry") ){
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "Cherries: " + cherries;
            collectSoundSource.Play();
        }
    }
}