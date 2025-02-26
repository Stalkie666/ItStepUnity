using UnityEngine;

public class StickyPlarform : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.name == "Player" ){
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if( collision.gameObject.name == "Player" ){
            collision.gameObject.transform.SetParent(null);
        }
    }
}
