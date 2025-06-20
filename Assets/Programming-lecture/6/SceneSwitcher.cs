using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理のために必要
public class SceneSwitcher : MonoBehaviour
{
    public string nextSceneName; // シーン名を指定するための変数
    public void LoadSceneByName()
    {
        SceneManager.LoadScene(nextSceneName); // 指定されたシーンを読み込む
    }
}