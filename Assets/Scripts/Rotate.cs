using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0, speed * 360 * Time.deltaTime);
    }
}
