using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField]float health;

    public event EventHandler OnDeath;

    public delegate void OnDamageHandler(float attackPower, Color color);
    public event OnDamageHandler OnDamageEvent;

    [SerializeField] Color color;

    Rigidbody2D rb;
    InputActionAsset actions;
    Vector2 movementInput;
    Vector2 movement;
    InputAction moveAction;

    public int Speed;
    Animator animator;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        actions = InputManager.Instance.Actions;
        moveAction = actions.FindActionMap("Action").FindAction("Movement");
        actions.FindActionMap("Action").FindAction("Attack").performed += OnAttack;
        actions.FindActionMap("Action").FindAction("Skill 1").performed += OnSkill1;
    }

    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
        movementInput = new Vector2(movement.x, movement.y);
        OnMove();
    }
   
    private void OnMove()
    {
        if (movementInput.x != 0 || movementInput.y != 0)
        {
            animator.SetBool("IsMoving", true);

        }
        else
        {
            animator.SetBool("IsMoving", false);
            return;
        }

        rb.transform.position = rb.transform.position + new Vector3(movementInput.x * Speed * Time.deltaTime, movementInput.y * Speed * Time.deltaTime, rb.transform.position.z);
        animator.SetFloat("AxisX", movementInput.x);
        animator.SetFloat("AxisY", movementInput.y);
        
    }
    private void OnAttack(InputAction.CallbackContext context)
    {
        animator.SetBool("IsAttacking", true);
        if (context.canceled)
        {
           animator.SetBool("UseSkill", false);
        }
    }
    private void OnSkill1(InputAction.CallbackContext context)
    {
        animator.SetBool("UseSkill", true);
        if (context.canceled)
        {
           animator.SetBool("UseSkill", false);

        }
    }

    public void OnDamage(float attackPower)
    {
        health -= attackPower;
        OnDamageEvent?.Invoke(attackPower, color);
        if (health <= 0f)
        {
            animator.SetBool("IsDead", true);
            OnDeath?.Invoke(this, null);
        }
    }

}
