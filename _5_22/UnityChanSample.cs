using UnityEngine;
using System.Collections;

public class UnityChanSample : MonoBehaviour {

  private Animator _animator;
  private int _restHash  = Animator.StringToHash("Rest");
  private int _speedHash = Animator.StringToHash("Speed");
  private int _jumpHash  = Animator.StringToHash("Jump");

  // publicスペース
  public int _timer = 0; /* 待機モーションに入るまでのカウント
                             180フレームを超えるとモーション開始 */
  public int   Time_Max     = 180;
  public float Move_Speed   = 0.03f;
  public float Rotate_Speed = 1.6f;
  public float Anim_Speed   = 0.8f;

  public bool isJump = false;

  void Start() {
    _animator = GetComponent<Animator>();
  }

  void Update() {
    Move();
    Rotat();
    Jump();
    AnimMgr();
  }

  void Move() {
    if (Input.GetKey(KeyCode.UpArrow)) {
      transform.Translate(0, 0, Move_Speed);
    } else
      if (Input.GetKey(KeyCode.DownArrow)) {
        transform.Translate(0, 0, -Move_Speed * 0.5f);
      }
  }

  void Rotat() {
    if (Input.GetKey(KeyCode.RightArrow)) {
      transform.Rotate(0, Rotate_Speed, 0);
    } else
      if (Input.GetKey(KeyCode.LeftArrow)) {
        transform.Rotate(0, -Rotate_Speed, 0);
      }
  }

  void Jump() {
    if (Input.GetKeyDown(KeyCode.Space)) {
      isJump = true;
    }
    else {
      isJump = false;
    }
  }

  void AnimMgr() {
    AnimatorStateInfo info = _animator.GetCurrentAnimatorStateInfo(0);

    // ジャンプモーション
    _animator.SetBool(_jumpHash, isJump);

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
      _timer++;
      if (_timer >= Time_Max) {
        _animator.SetBool(_restHash, true); // 待機モーション開始
        _timer = 0;
      }
    }

    if (info.shortNameHash == _restHash) {
      _animator.SetBool(_restHash, false); // 待機モーション停止
    }
  }
}