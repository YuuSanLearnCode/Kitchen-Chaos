using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour {
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;

    private void Awake() {
        //Click play
        playButton.onClick.AddListener(() => {
            //Click play
            Loader.Load(Loader.Scene.GameScene);
        });
        quitButton.onClick.AddListener(() => {
            //Click quit
            Application.Quit();
        });
        Time.timeScale = 1f;
    }
    
}