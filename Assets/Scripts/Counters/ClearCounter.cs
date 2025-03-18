using UnityEngine;

public class ClearCounter : BaseCounter {
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player) {
        if (!HasKitchenObject()) {
            //there is no kitchen object on the counter
            if (player.GetKitchenObject() != null) {
                //player is holding a kitchen object
                player.GetKitchenObject().SetKitchenObjectParent(this);
            } else {
                //player is not holding a kitchen object
            }
        } else {
            //there is a kitchen object on the counter
            if (player.HasKitchenObject()) {
                //player is carrying something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                    //player is holding the plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO())) {
                        GetKitchenObject().DestroySelf();
                    }
                } else {
                    //player is carrying something that is not a plate
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject)) {
                        //there is a plate on the counter
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            } else {
                //player is not carrying anything
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}