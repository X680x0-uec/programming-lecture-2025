using UnityEngine; //このスクリプトはUnityEngineの機能を使用します。

public class CubeMover : MonoBehaviour //このスクリプトはCubeMoverというクラスを定義します。(クラスについてはもっと後の講座で説明します)
{
    [SerializeField] float speed = 2f; //変数speedをUnityエディタから設定できるようにします。初期値は2です。

    void Start() //以下の処理は最初の一回だけ実行されます。
    {
        transform.position = new Vector3(0, 0, 0); //オブジェクトの初期位置を(0, 0, 0)に設定します。
    }

    void Update() //以下の処理を毎フレーム実行します。
    {
        float x = Mathf.Sin(Time.time * speed); // Sin関数を使って、時間に基づいてx座標を計算します。
        transform.position = new Vector3(x, transform.position.y, transform.position.z); // 計算したx座標を使って、オブジェクトの位置を更新します。
    }
}
