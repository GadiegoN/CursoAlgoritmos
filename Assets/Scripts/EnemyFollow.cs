using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(
            transform.position,
            target.position
        );

        if (distance < 5 && distance > .5)
        {
            Vector3 direction = target.position - transform.position;
            direction = direction.normalized;

            transform.position += direction * speed * Time.deltaTime;
        }

    }
}
