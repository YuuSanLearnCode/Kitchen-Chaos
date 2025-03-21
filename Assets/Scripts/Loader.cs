using UnityEngine.SceneManagement;

public static class Loader {

    public enum Scene {
        MainMenuScene,
        GameScene,
        LoadingScene,
    }

    private static Scene targetScene;

    public static void Load(Scene targetScene) {
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString()); // Load the loading scene
    }

    public static void LoaderCallBack() {
        // Start the target scene
        SceneManager.LoadScene(targetScene.ToString()); // Load the target scene bang string
    }
}