using UnityEngine;
public class CombatSystem : MonoBehaviour
{
    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private PlayerController player;
    [SerializeField] private float punchRange = 4f;
    [SerializeField] private int punchDamage = 50;
    [SerializeField] private float shootRange = 50f;
    [SerializeField] private int shootDamage = 100;
    private void Start()
    {
        if (inputSystem == null) inputSystem = FindFirstObjectByType<InputSystem>();
        if (player == null) player = GetComponent<PlayerController>();
        if (inputSystem != null) inputSystem.OnActionPerformed += HandleAction;
    }
    private void OnDestroy() { if (inputSystem != null) inputSystem.OnActionPerformed -= HandleAction; }
    private void HandleAction(ActionType action, bool success)
    {
        if (!success) return;
        switch (action)
        {
            case ActionType.leftShoot: PerforLeftShoot(); break;
            case ActionType.rightShoot: PerforRightShoot(); break;
        }
    }

    
    private void PerforLeftShoot()
    {
        if (player == null || !player.UseAmmo()) return;
       
    }

    private void PerforRightShoot()
    {
        if (player == null || !player.UseAmmo()) return;
    }
}