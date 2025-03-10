using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent {
    
    [SerializeField] private Transform CounterTopPoint;

    private KitchenObject kitchenObject;
    public virtual void Interact(Player player) {
        Debug.Log("Interacting with base counter");
    }

    public Transform GetKitchenObjectFollowTransform() {
        return CounterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }
}