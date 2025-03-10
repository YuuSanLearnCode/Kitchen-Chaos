using System;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public event EventHandler OnInteractAction;

    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        //Debug.Log("e"); ?.invoke is used to check if the event is null
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>(); ;

        inputVector = inputVector.normalized;

        return inputVector;
    }
}