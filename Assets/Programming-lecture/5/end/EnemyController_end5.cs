using UnityEngine;
using System.Collections; // コルーチンを使用するために必要な名前空間

public class EnemyController_end5 : MonoBehaviour
{
    [SerializeField] GameObject hammer; // ハンマーのGameObjectを参照するための変数
    [SerializeField] private float throwIntervalSec; // ハンマーを投げる間隔（秒）
    [SerializeField] private float throwForce; // ハンマーを投げる力
    [SerializeField] private float throwAngleDeg; // ハンマーを投げる角度（度）
    [SerializeField] private float hammerSize; // ハンマーのサイズ
    [SerializeField] private float destroyDelaySec = 0.03f; // ハンマーが着弾してから破壊されるまでの遅延時間（秒）

    void Start()
    {
        // ハンマーを投げるコルーチンを開始
        StartCoroutine(ThrowHammerCoroutine());
    }

    IEnumerator ThrowHammerCoroutine()
    {
        while (true) // 無限ループ
        {
            
            // ハンマーを投げる力を計算
            float throwAngleRad = throwAngleDeg * Mathf.Deg2Rad; // 角度をラジアンに変換
            Vector3 throwDirection = new Vector3(Mathf.Cos(throwAngleRad), Mathf.Sin(throwAngleRad),0); // 投げる方向を計算

            // ハンマーを生成 Instantiateは指定したプレハブをシーンに生成するためのメソッドで、第一引数に生成するプレハブ、第二引数に生成位置、第三引数に生成時の回転(クオータニオン)を指定します。今回は第二引数をtransform.position、第三引数をQuaternion.identityに設定して、敵の位置に回転なし(0,0,0)で生成します。生成したオブジェクトへの参照がhammerInstanceに格納されます。
            GameObject hammerInstance = Instantiate(hammer, transform.position, Quaternion.identity);
            // 生成したハンマーのRigidbody2Dコンポーネントを取得
            Rigidbody2D rb = hammerInstance.GetComponent<Rigidbody2D>();
            if (rb != null) // hammerにRigidbody2Dコンポーネントが存在する場合
            {
                // ハンマーに力を加える
                rb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
            }
            else // hammerにRigidbody2Dコンポーネントが存在しない場合
            {
                Debug.LogError("ハンマーに Rigidbody2D コンポーネントが見つかりません。");
            }

            // ハンマーのサイズを設定
            hammerInstance.transform.localScale = new Vector3(hammerSize, hammerSize, 1);

            // ハンマーについているHammerControllerコンポーネントを取得
            HammerController_end5 hc = hammerInstance.GetComponent<HammerController_end5>();
            if (hc != null) // hammerにHammerControllerコンポーネントが存在する場合
            {
                hc.delaySec = destroyDelaySec; // ハンマーの破壊までの遅延時間を設定
            }
            else // hammerにHammerControllerコンポーネントが存在しない場合
            {
                Debug.LogError("ハンマーに HammerController コンポーネントが見つかりません。");
            }

            // 指定した間隔だけ待機
            yield return new WaitForSeconds(throwIntervalSec);
        }
    }
}
