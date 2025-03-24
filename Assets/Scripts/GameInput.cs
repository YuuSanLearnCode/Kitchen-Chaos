using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour {

    private const string PLAYER_PREFS_BINDING = "InputBinding";
    public static GameInput Instance { get; private set; }

    public event EventHandler OnInteractAction;

    public event EventHandler OnInteractAlternateAction;

    public event EventHandler OnPauseAction;

    public enum Binding {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        Interact,
        Interact_Alternative,
        Pause
    }

    private PlayerInputActions playerInputActions;

    private void Awake() {
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
        playerInputActions.Player.InteractAlternative.performed += InteractAlternative_performed;
        playerInputActions.Player.Pause.performed += Pause_performed;
        Debug.Log(GetBindingText(Binding.Interact));
        Debug.Log(GetBindingText(Binding.Move_Up));
    }

    private void OnDestroy() {
        playerInputActions.Player.Interact.performed -= Interact_performed;
        playerInputActions.Player.InteractAlternative.performed -= InteractAlternative_performed;
        playerInputActions.Player.Pause.performed -= Pause_performed;

        playerInputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternative_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
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

    public string GetBindingText(Binding binding) {
        switch (binding) {
            case Binding.Move_Up:
                return playerInputActions.Player.Move.bindings[1].ToDisplayString();

            case Binding.Move_Down:
                return playerInputActions.Player.Move.bindings[2].ToDisplayString();

            case Binding.Move_Left:
                return playerInputActions.Player.Move.bindings[3].ToDisplayString();

            case Binding.Move_Right:
                return playerInputActions.Player.Move.bindings[4].ToDisplayString();

            case Binding.Interact:
                return playerInputActions.Player.Interact.bindings[0].ToDisplayString();

            case Binding.Interact_Alternative:
                return playerInputActions.Player.InteractAlternative.bindings[0].ToDisplayString();

            case Binding.Pause:
                return playerInputActions.Player.Pause.bindings[0].ToDisplayString();
                ;
            default:
                return "Unbound";
        }
    }

    public void RebindBinding(Binding binding, Action onActionRebound) {
        playerInputActions.Player.Disable();
        InputAction inputAction;
        int bindingIndex;
        switch (binding) {
            default:
            case Binding.Move_Up:
                inputAction = playerInputActions.Player.Move;
                bindingIndex = 1;
                break;
                case Binding.Move_Down:
                inputAction = playerInputActions.Player.Move;
                bindingIndex = 2;
                break;
            case Binding.Move_Left:
                inputAction = playerInputActions.Player.Move;
                bindingIndex = 3;
                break;
            case Binding.Move_Right:
                inputAction = playerInputActions.Player.Move;
                bindingIndex = 4;
                break;
            case Binding.Interact:
                inputAction = playerInputActions.Player.Interact;
                bindingIndex = 0;
                break;
            case Binding.Interact_Alternative:
                inputAction = playerInputActions.Player.InteractAlternative;
                bindingIndex = 0;
                break;
            case Binding.Pause:
                inputAction = playerInputActions.Player.Pause;
                bindingIndex = 0;
                break;


        }
        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback => {
                callback.Dispose();
                playerInputActions.Player.Enable();
                onActionRebound();

                // save the new binding
                PlayerPrefs.SetString(PLAYER_PREFS_BINDING, playerInputActions.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();
            })
        .Start();
    }
}