using UnityEngine;

public class PlayerSound : MonoBehaviour {
    private Player player;
    private float footstepTimer;
    private float footstepTimerMax = 0.1f;

    private void Awake() {
        player = GetComponent<Player>();
    }

    private void Update() {
        if (player.IsWalking()) {
            footstepTimer -= Time.deltaTime;
            if (footstepTimer <= 0) {
                footstepTimer += footstepTimerMax;

                if (player.IsWalking()) {
                    float volume = 1f;
                    SoundManager.Instance.PlayFootstepSound(player.transform.position, volume);
                }
            }
        }
    }
}