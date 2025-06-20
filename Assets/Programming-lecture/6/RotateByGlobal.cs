using UnityEngine;
public class RotateByGlobal : MonoBehaviour
{
    [SerializeField] Vector3 rotationVector; // 回転量を指定するための変数
    void Update()
    {
        // 回転を実行
        transform.Rotate(rotationVector * Time.deltaTime, Space.World);
        // Quaternion.Eulerは、オイラー角をQuaternionに変換するメソッド
    }
}
