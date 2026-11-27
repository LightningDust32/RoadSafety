
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Minigame : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    public bool IsActive { get; private set; }
    public bool IsComplete { get; private set; }

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    protected virtual void OnEnable()
    {
        inputActions.Player.Interact.performed += Interact;
    }

    protected virtual void OnDisable()
    {
        inputActions.Player.Interact.performed -= Interact;
    }

    // Shared input callback
    private void Interact(InputAction.CallbackContext context)
    {
        if (!IsActive || IsComplete)
            return;

        OnInteract();
    }

    // Override in individual minigames
    protected virtual void OnInteract()
    {
    }

    // Minigame lifecycle
    public virtual void Initialise()
    {
        IsActive = false;
        IsComplete = false;
    }

    public virtual void StartMinigame()
    {
        IsActive = true;
    }

    public virtual void EndMinigame()
    {
        IsActive = false;
    }

    public virtual void CompleteMinigame()
    {
        IsActive = false;
        IsComplete = true;
    }

    public virtual void ResetMinigame()
    {
        IsActive = false;
        IsComplete = false;
    }
}
