using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform CounterTopPoint;
    [SerializeField] private ClearCounter secondClearCounter;
    [SerializeField] private bool testing;

    private KitchenObject kitchenObject;

    private void Update() {
        if (testing && Input.GetKeyDown(KeyCode.T)) {
            if (kitchenObject != null) {
                kitchenObject.SetClearCounter(secondClearCounter);
                
            }
        }
    }

    public void Interact(Player player) {
        if (kitchenObject == null) {
            Transform kitchenObjectTransfrom = Instantiate(kitchenObjectSO.prefab, CounterTopPoint);
            kitchenObjectTransfrom.GetComponent<KitchenObject>().SetClearCounter(this);

        } else {
            //give object to player
            kitchenObject.SetClearCounter(player);
        }
        
    }
    public Transform GetKitchenObjectFollowTransform() {
        return CounterTopPoint;
    }

    public void SetKitchenObject (KitchenObject kitchenObject) {
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
