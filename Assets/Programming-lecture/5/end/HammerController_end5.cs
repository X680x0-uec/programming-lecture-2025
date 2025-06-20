using UnityEngine;
using System.Collections; // コルーチンを使用するために必要な名前空間

public class HammerController_end5 : MonoBehaviour
{
    public float delaySec; // ハンマーを破壊するまでの遅延時間（秒） EnemyControllerから値が設定される

    void OnCollisionEnter2D(Collision2D other) // なにか他のものに触れたとき
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Ground")) // 接触したオブジェクトが"Player"または"Ground"のタグを持つ場合
        {
            StartCoroutine(DestroyHammerCoroutine()); // delaySec秒後にハンマーを破壊するコルーチンを開始
        }
    }
    
    IEnumerator DestroyHammerCoroutine() // ハンマーを破壊するコルーチン
    {
        yield return new WaitForSeconds(delaySec); //delaySec秒待機
        Destroy(gameObject); // ハンマーを破壊
    }
}
