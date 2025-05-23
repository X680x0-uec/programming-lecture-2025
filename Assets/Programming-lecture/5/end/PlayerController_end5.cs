using UnityEngine;
using System.Collections; // コルーチンを使用するために必要な名前空間
using UnityEngine.UI; // UI要素を使用するために必要な名前空間

public class PlayerController_end5 : MonoBehaviour
{
    //SerializeField属性は変数をUnityのInspectorウィンドウから設定できるようにするためのものです。
    //これにより、Inspectorウィンドウからspeedの値を変更できるようになります。
    [SerializeField] private float speed = 5f; // プレイヤーの移動速度
    [SerializeField] private float jumpForce = 10f; // ジャンプ力
    [SerializeField] private int jumpCount = 0; // ジャンプ回数
    [SerializeField] private int maxJumpCount = 2; // 最大ジャンプ回数

    [SerializeField] private int maxHitPoint = 3; // 最大HP (part5で追加)
    [SerializeField] private int hitPoint = 3; // 現在のHP (part5で追加)
    [SerializeField] private float hitIntervalSec = 1f; // 無敵時間 (part5で追加)
    [SerializeField] private bool isInvincible = false; // 無敵状態かどうか (part5で追加)

    [SerializeField] private SpriteRenderer playerSpriteRenderer; // スプライトレンダラーの参照
    [SerializeField] private Rigidbody2D playerRigidbody; // リジッドボディの参照
    [SerializeField] private Collider2D floorDetector; // 接地判定のコライダーの参照
    [SerializeField] private Slider HPBar; // HPバーの参照 (part5で追加)

    void OnTriggerEnter2D(Collider2D other) // なにか他のものに触れたとき
    {
        if (other.gameObject.CompareTag("ground")) // 接触したオブジェクトが"ground"タグを持つ場合 (part5で追加)
        {
            jumpCount = 0; // ジャンプ回数を0に設定
        }
    }

    void OnCollisionStay2D(Collision2D other) // なにか他のものに触れているとき (part5で追加)
    {
        if (other.gameObject.CompareTag("damage") && !isInvincible) // 接触したオブジェクトが"spike"タグを持ち、無敵でない場合
        {
            hitPoint--; // HPを1減少
            if (hitPoint <= 0) // HPが0以下になった場合
            {
                Destroy(this.gameObject); // プレイヤーを破壊
            }
            HPBar.value = (float)hitPoint / maxHitPoint; // HPバーを更新
            
            isInvincible = true; // 無敵状態にする
            playerSpriteRenderer.color = new Color(1, 0, 0, 0.9f); // スプライトの色を赤の半透明にする
            StartCoroutine(InvincibleCoroutine()); // 無敵時間を管理するコルーチンを開始
        }
    }

    IEnumerator InvincibleCoroutine() // 無敵時間を管理するコルーチン (part5で追加)
    {
        yield return new WaitForSeconds(hitIntervalSec); // 指定した秒数待機
        isInvincible = false; // 無敵状態を解除
        playerSpriteRenderer.color = new Color(1, 1, 1, 1); // スプライトの色を元に戻す
    }

    void OnTriggerExit2D(Collider2D other) // 地面から離れたとき
    {
        if (other.gameObject.CompareTag("ground")) // 接触していたオブジェクトが"ground"タグを持つ場合 (part5で追加)
        {
            jumpCount = 1; // ジャンプ回数を1に設定
        }
    }

    // Start関数はUnityにおいて事前に定義された関数で、ゲームオブジェクトが生成されたときに一度だけ呼び出されます。
    // ゲームの1フレーム目に呼び出されるので、初期化処理などに使用されます。
    void Start() // (part5で追加)
    {
        HPBar.value = (float)hitPoint / maxHitPoint; // HPバーを初期化
        playerSpriteRenderer.color = new Color(1, 1, 1, 1); // スプライトの色を元に戻す
        isInvincible = false; // 無敵状態を解除
    }

    // Update関数はUnityにおいて事前に定義された関数で、毎フレーム呼び出されます。
    // ゲームの進行に合わせて、オブジェクトの状態を更新するために使用されます。
    // 例えば、プレイヤーの入力を受け取ってキャラクターを動かす処理などに使用されます。
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftShift)) // Aキーが押されているとき
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // 左に移動
            playerSpriteRenderer.flipX = true; // 画像を左右反転
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftShift)) // Dキーが押されているとき
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); // 右に移動
            playerSpriteRenderer.flipX = false; // 画像を元に戻す
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) // AキーとShiftキーが押されているとき
        {
            transform.Translate(Vector3.left * speed * 2 * Time.deltaTime); // 左に二倍の速度で移動
            playerSpriteRenderer.flipX = true; // 画像を左右反転
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift)) // DキーとShiftキーが押されているとき
        {
            transform.Translate(Vector3.right * speed * 2 * Time.deltaTime); // 右に二倍の速度で移動
            playerSpriteRenderer.flipX = false; // 画像を元に戻す
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumpCount) // スペースキーが押されたとき
        {
            playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, jumpForce); // 上にジャンプ
            jumpCount++; // ジャンプ回数を増加
        }
    }

}
