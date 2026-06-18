using UnityEngine;

public class Entity_AnimationEvents : MonoBehaviour
{
    private Entity Entity;

    private void Awake()
    {
        Entity = GetComponentInParent<Entity>();
    }

    public void DamageTargets() => Entity.DamageTargets();
    private void DisableMovementAndJump() => Entity.EnableMovement(false);
    private void EnableMovementAndJump() => Entity.EnableMovement(true);
}
