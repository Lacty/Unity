
using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

  bool _is_target;
	
  Vector3 _target;
	
  [SerializeField]
  Vector3 _speed;
  Vector3 _velocity;
  
  [SerializeField]
  float _sensitivity;
  
  void Awake() {
    _is_target = false;
    _target = Vector3.zero;
  }

  void Start() {}
	
  void Update() {
    Move();
    MouseDrag();
  }
	
  void Move() {
    if (Input.GetKey(KeyCode.A)) {
      _velocity.x -= _speed.x;
    }
    if (Input.GetKey(KeyCode.D)) {
      _velocity.x += _speed.x;
    }
    if (Input.GetKey(KeyCode.S)) {
      _velocity.z -= _speed.z;
    }
    if (Input.GetKey(KeyCode.W)) {
      _velocity.z += _speed.z;
    }
		
    _velocity *= 0.94f;
    transform.Translate(_velocity);
    
    if (!_is_target) return;
    transform.LookAt(_target);
  }
  
  void MouseDrag() {
    if (!Input.GetMouseButton(1)) return;
    float mouse_move_x = Input.GetAxis("Mouse X") * _sensitivity;
    transform.Rotate(0, mouse_move_x, 0);
  }
	
  public Vector3 GetTargetPos() {
    return _target;
  }
	
  public bool IsTarget() {
    return _is_target;
  }
}
