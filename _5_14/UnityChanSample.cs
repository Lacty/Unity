using UnityEngine;
using System.Collections;

public class UnityChanSample : MonoBehaviour {

  private Animator _animator;
  private int _restHash  = Animator.StringToHash("Rest");
  private int _speedHash = Animator.StringToHash("Speed");
  private int _jumpHash  = Animator.StringToHash("Jump");
  private int _timer = 0; /* 待機モーションに入るまでのカウント
                             180フレームを超えるとモーション開始 */

  void Start() {
    _animator = GetComponent<Animator>();
  }

  void Update() {
    Mover();
    Rotator();
    Jumper();
    AnimMgr();
  }

  void Mover() {
    const float Move_Speed = 0.03f;

    if (Input.GetKey(KeyCode.UpArrow)) {
      transform.Translate(0, 0, Move_Speed);
    } else
      if (Input.GetKey(KeyCode.DownArrow)) {
        transform.Translate(0, 0, -Move_Speed * 0.5f);
      }
  }

  void Rotator() {
    const float Rotate_Speed = 1.6f;

    if (Input.GetKey(KeyCode.RightArrow)) {
      transform.Rotate(0, Rotate_Speed, 0);
    } else
      if (Input.GetKey(KeyCode.LeftArrow)) {
        transform.Rotate(0, -Rotate_Speed, 0);
      }
  }

  void Jumper() {
    if (Input.GetKey(KeyCode.Space)) {
      _animator.SetBool(_jumpHash, true); // Jump開始
    }
  }

  void AnimMgr() {
    AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);
    const float Anim_Speed = 0.8f;

    // ジャンプしたらfalseに戻す
    if (info.shortNameHash == _jumpHash) {
      _animator.SetBool(_jumpHash, false); // Jump停止
    }

    // 移動中のモーション
    if (Input.GetKey(KeyCode.UpArrow)) {
      _animator.SetFloat(_speedHash, Anim_Speed);
    }
    else if (Input.GetKeyUp(KeyCode.UpArrow)) {
      _animator.SetFloat(_speedHash, 0.0f); // Anim停止
    }
    if (Input.GetKey(KeyCode.DownArrow)) {
      _animator.SetFloat(_speedHash, -Anim_Speed * 0.5f);
    }
    else if (Input.GetKeyUp(KeyCode.DownArrow)) {
      _animator.SetFloat(_speedHash, 0.0f); // Anim停止
    }

    // 何かKeyが押されていたら
    if (Input.anyKey) {
      _timer = 0;
    }
    else {
      _animator.SetBool(_jumpHash, false); // Jump停止

      _timer++;
      if (_timer >= 180) {
        _animator.SetBool(_restHash, true); // 待機モーション開始
        _timer = 0;
      }
    }

    if (info.shortNameHash == _restHash) {
      _animator.SetBool(_restHash, false); // 待機モーション停止
    }
  }
}