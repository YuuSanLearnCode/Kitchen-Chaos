using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter {

    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    public event EventHandler OnPlayerGrabbedObject;

    
    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            Transform kitchenObjectTransfrom = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransfrom.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        } 
    }

}