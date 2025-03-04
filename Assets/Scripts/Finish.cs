using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelComplete = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.name == "Player" && !levelComplete ){
            finishSound.Play();
            levelComplete = true;
            Invoke("CompleteLevel",2f);
        }
    }

    private void CompleteLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
