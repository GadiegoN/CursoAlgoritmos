using UnityEngine;

public class EnemyCoward : MonoBehaviour
{
    public Transform target;
    public float speed = 2.5f;

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
            Debug.Log("Assassino detectado em: " + distance);

            Vector3 direction = target.position - transform.position;
            direction = direction.normalized;

            transform.position -= direction * speed * Time.deltaTime;

        }
        else
        {
            Debug.Log("Procurando assassino em: " + distance);
        }
    }
}
