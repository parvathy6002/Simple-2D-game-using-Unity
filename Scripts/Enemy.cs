
using UnityEngine;

public class Enemy : Entity
{
    private bool warriorDetected;

    [Header("Movement Details")]
    [SerializeField] protected float moveSpeed = 3.5f;
    protected override void Update()
    {
       base.Update();
        HandleAttack();
    }
    protected override void HandleAttack()
    {
        if (warriorDetected)
            anim.SetTrigger("Attack");
    }
    protected override void HandleMovement()
    {
        if (canMove)
            rb.linearVelocity = new Vector2(facingDir * moveSpeed, rb.linearVelocity.y);
        else
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }
    protected override void HandleCollision()
    {
        base.HandleCollision();
        warriorDetected = Physics2D.OverlapCircle(attackPoint.position, attackRadius, whatIsTarget);
    }

    protected override void Die()
    {
        UI.instance.AddKillCount();
        base.Die();
    }
}

