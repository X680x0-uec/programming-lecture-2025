using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //SerializeField属性は変数をUnityのInspectorウィンドウから設定できるようにするためのものです。
    //これにより、Inspectorウィンドウからspeedの値を変更できるようになります。
    [SerializeField] private float speed = 5f; // プレイヤーの移動速度

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
        if (Input.GetKey(KeyCode.A)) // Aキーが押されているとき
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime); // 左に移動
        }
        if (Input.GetKey(KeyCode.D)) // Dキーが押されているとき
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime); // 右に移動
        }
    }
}
