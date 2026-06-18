using UnityEngine;

public class Girl : Entity
{
    private Transform warrior;
    protected override void Awake()
    {
        base.Awake();
        warrior = FindFirstObjectByType<Player>().transform;
    }
    protected override void Update()
    {
        HandleFlip();
    }

    protected override void HandleFlip()
    {
        if (warrior == null) 
            return;


        if (warrior.transform.position.x > transform.position.x && facingRight == false)
            flip();
        else if (warrior.transform.position.x < transform.position.x && facingRight == true)
            flip();
    }

    protected override void Die()
    {
        base.Die();
        UI.instance.EnableGameOverUI();
    }
}
