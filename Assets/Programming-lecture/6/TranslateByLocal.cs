using UnityEngine;
public class TranslateByLocal : MonoBehaviour
{
    [SerializeField] Vector3 translationVector; // ローカル座標系での移動量を指定するための変数
    void Update()
    {
        // ローカル座標系での移動を実行
        transform.localPosition += translationVector * Time.deltaTime; // translationVectorに基づいてオブジェクトを移動
    }
}
