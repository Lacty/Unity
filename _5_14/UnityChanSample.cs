using UnityEngine;
using System.Collections;

public class UnityChanSample : MonoBehaviour {
  private Animator _animator;
  private int _restHash = Animator.StringToHash("Rest"); // Hash化
  private int _speedHash = Animator.StringToHash("Speed");
  private int _jumpHash = Animator.StringToHash("Jump");
  private int _timer = 0;

  void Start() {
    _animator = GetComponent<Animator>();
    //animator.SetFloat("Speed", -0.2f);
    //_animator.SetBool(_restHash, true); // Rest開始
  }

  void Update() {
    if (Input.GetKey(KeyCode.UpArrow)) // 上キーが押されていたら
    {
      _animator.SetFloat(_speedHash, 0.6f);
      transform.Translate(0, 0, 0.03f); // 前
    } else if (Input.GetKey(KeyCode.DownArrow)) // 下キーが押されていたら
    {
      _animator.SetFloat(_speedHash, -0.3f);
      transform.Translate(0, 0, -0.01f); // 後
    }

    if (Input.GetKey(KeyCode.RightArrow)) // 右キーが押されていたら
    {
      transform.Rotate(0, 1.6f, 0); // 右回転
    }
    if (Input.GetKey(KeyCode.LeftArrow)) // 左キーが押されていたら
    {
      transform.Rotate(0, -1.6f, 0); // 左回転
    }

    if (Input.GetKey(KeyCode.Space)) // スペースキーを押したら
    {
      _animator.SetBool(_jumpHash, true);
    }

    AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
    if (info.shortNameHash == _jumpHash) {
      _animator.SetBool(_jumpHash, false);
    }

    // モーションを止める処理
    // キーが離されたら
    if (Input.GetKeyUp(KeyCode.UpArrow)) {
      _animator.SetFloat(_speedHash, 0.0f);
    } else if (Input.GetKeyUp(KeyCode.DownArrow)) {
      _animator.SetFloat(_speedHash, 0.0f);
    }

    if (Input.anyKey) {
      _timer = 0;
    } else {
      _animator.SetBool(_jumpHash, false);
    }

    if (info.shortNameHash != _speedHash) {
      _timer++;
      if (_timer >= 180) {
        _animator.SetBool(_restHash, true);
        _timer = 0;
      }
    }

    if (info.shortNameHash == _restHash) // Animatorの状態がRestかどうか
    {
      _animator.SetBool(_restHash, false); // Rest終了
      _animator.SetBool(_jumpHash, false); // Jump終了
    }

    //AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
    // if (info.IsName("Rest"))
    //if (info.shortNameHash == _restHash) // Animatorの状態がRestかどうか
    //{
    //  _animator.SetBool(_restHash, false); // Rest終了
    //}

    //transform.Translate(0.01f, 0, 0); // X方向に移動
    //transform.Translate(0, 0.01f, 0); // Y方向に移動
    //transform.Translate(0, 0, 0.01f); // Z方向に移動
    //transform.Rotate(0, 1, 0); // Y軸の回転
    //transform.Rotate(1, 0, 0); // X軸で回転
    //transform.Rotate(0, 0, 1); // Z軸で回転
  }
}
