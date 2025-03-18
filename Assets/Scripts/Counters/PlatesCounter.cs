using System;
using UnityEngine;

public class PlatesCounter : BaseCounter {

    public event EventHandler OnPlateSpawned;

    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    private float spawnPlateTime;
    private float spawnPlateTimerMax = 4f;
    private int platesSpawnAmount;
    private int platesSpawnAmountMax = 4;

    private void Update() {
        spawnPlateTime += Time.deltaTime;
        if (spawnPlateTime > spawnPlateTimerMax) {
            spawnPlateTime = 0f;
            if (platesSpawnAmount < platesSpawnAmountMax) {
                platesSpawnAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player) {
        if (!player.HasKitchenObject()) {
            //player is empty handed
            if (platesSpawnAmount > 0) {
                //there at least one plate to pick up
                platesSpawnAmount--;

                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}