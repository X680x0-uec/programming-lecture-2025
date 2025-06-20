using UnityEngine;

public class Rotate1 : MonoBehaviour
{
    [SerializeField] Vector3 rotationVector; // 回転量を指定するための変数
    void Update()
    {
        // 回転を実行
        transform.rotation *= Quaternion.Euler(rotationVector * Time.deltaTime);
        // Quaternion.Eulerは、オイラー角をQuaternionに変換するメソッド
    }
}
