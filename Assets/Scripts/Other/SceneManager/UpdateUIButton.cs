using UnityEngine;

public class UpdateUIButton : MonoBehaviour
{
    [SerializeField] private SceneType sceneType;
    
    private UISceneLoader _uiSceneLoader;   

    private void Start()
    {
        _uiSceneLoader = UISceneLoader.Instance;
    }

    public void PushButton()
    {
        _uiSceneLoader.UpdateUI(sceneType);
    }
}