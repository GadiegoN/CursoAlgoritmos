using UnityEngine;

public enum EnemyState
{
    Idle,
    Chase,
    Attack,
    Flee
}

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    public float speed = 1.5f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public float fleeRange = 0.5f;

    public EnemyState currentState;

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

        DecideState(distance);

        ExecuteState();
    }

    void DecideState(float distance)
    {
        if (distance <= fleeRange)
        {
            currentState = EnemyState.Flee;
        }
        else if (distance <= attackRange)
        {
            currentState = EnemyState.Attack;
        }

        else if (distance <= detectionRange)
        {
            currentState = EnemyState.Chase;
        }
        else
        {
            currentState = EnemyState.Idle;
        }
    }

    void ExecuteState()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                Idle();
                break;

            case EnemyState.Flee:
                Flee();
                break;

            case EnemyState.Chase:
                Chase();
                break;

            case EnemyState.Attack:
                Attack();
                break;
        }
    }

    void Chase()
    {
        Vector3 direction = target.position - transform.position;

        direction = direction.normalized;

        transform.position += direction * speed * Time.deltaTime;
    }

    void Flee()
    {
        Vector3 direction = target.position - transform.position;

        direction = direction.normalized;

        transform.position -= direction * speed * Time.deltaTime;
    }

    void Idle()
    {
        Debug.Log("Idle");
    }

    void Attack()
    {
        Debug.Log("Attack");
    }
}
