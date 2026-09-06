using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
