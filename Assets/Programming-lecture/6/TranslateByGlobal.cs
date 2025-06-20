using UnityEngine;
public class TranslateByGlobal : MonoBehaviour
{
    [SerializeField] Vector3 translationVector; // グローバル座標系での移動量を指定するための変数
    void Update()
    {
        // グローバル座標系での移動を実行
        transform.position += translationVector * Time.deltaTime; // translationVectorに基づいてオブジェクトを移動
    }
}
