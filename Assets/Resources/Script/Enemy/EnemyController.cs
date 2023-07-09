using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    public EnemyBaseState currentState { get; private set; }
    public delegate void OnStateChangeHandler(EnemyBaseState state);
    public event OnStateChangeHandler OnStateHandler;

    public delegate void OnDeathHandler();
    public static event OnDeathHandler OnDeath;

    [SerializeField] float health;
    [SerializeField]bool isChasing;
    [SerializeField] Color color;

    [SerializeField]Transform target;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed;
    public EnemyChasingState enemyChasingState = new EnemyChasingState();

    AudioSource audioSource;

    [SerializeField]float distance;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        OnStateHandler += OnEnemyChangeState;
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

        SetState(enemyChasingState);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void SetState(EnemyBaseState state)
    {
        currentState = state;
        currentState.OnEnterState(this);

    }
    void Update()
    {
        var targetPos = new Vector3(target.position.x,target.position.y, transform.position.z);
        distance = Vector3.Distance(transform.position, targetPos);
        if (distance > 0.75f)
        {
            rb.transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), speed * Time.deltaTime);

        }
        else
        {
        }
    }

    void OnEnemyChangeState(EnemyBaseState state)
    {
        switch (state)
        {
            case EnemyChasingState :
                break;
        }
    }
    public void OnChangeState()
    {
        OnStateHandler?.Invoke(currentState);
    }

    public void OnDamage(float attackPower)
    {
        health -= attackPower;
        if (health <= 0f)
        {
            OnDeath?.Invoke();
            Destroy(this.gameObject);
        }
    }
}


public abstract class EnemyBaseState
{
    public abstract void OnEnterState(EnemyController state);

    public abstract void OnExit(EnemyController state);

}

public  class EnemyChasingState : EnemyBaseState
{
    public override void OnEnterState(EnemyController state)
    {
        state.OnChangeState();


    }
    public override void OnExit(EnemyController state)
    {

    }

}