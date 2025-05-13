using UnityEngine;

public class PlayerController_end : MonoBehaviour
{
    //SerializeField属性は変数をUnityのInspectorウィンドウから設定できるようにするためのものです。
    //これにより、Inspectorウィンドウからspeedの値を変更できるようになります。
    [SerializeField] private float speed = 5f; // プレイヤーの移動速度
    [SerializeField] private float jumpForce = 10f; // ジャンプ力
    [SerializeField] private int jumpCount = 0; // ジャンプ回数
    [SerializeField] private int maxJumpCount = 2; // 最大ジャンプ回数
    [SerializeField] private SpriteRenderer playerSpriteRenderer; // スプライトレンダラーの参照
    [SerializeField] private Rigidbody2D playerRigidbody; // リジッドボディの参照
    [SerializeField] private Collider2D floorDetector; // 接地判定のコライダーの参照

    void OnTriggerEnter2D(Collider2D other) // 地面に触れたとき
    {
        jumpCount = 0; // ジャンプ回数を0に設定
    }
    void OnTriggerExit2D(Collider2D other) // 地面から離れたとき
    {
        jumpCount = 1; // ジャンプ回数を1に設定
    }

    // Start関数はUnityにおいて事前に定義された関数で、ゲームオブジェクトが生成されたときに一度だけ呼び出されます。
    // ゲームの1フレーム目に呼び出されるので、初期化処理などに使用されます。
    void Start()
    {

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
