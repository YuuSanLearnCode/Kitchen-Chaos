using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO() {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter) {
        if (this.clearCounter != null) {
            this.clearCounter.ClearKitchenObject(); //xoa  kitchen object cu tren counter
            
        }

        this.clearCounter = clearCounter;

        if(clearCounter.HasKitchenObject()) {
            Debug.LogError("Trying to set kitchen object on a counter that already has one");
        }

        clearCounter.SetKitchenObject(this); //tao kitchen object moi tren counter

        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetClearCounter() {
        return clearCounter;
    }
}