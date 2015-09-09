
using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {

  bool _is_target;
	
  Vector3 _target;
  Vector3 _direction;
	
  [SerializeField]
  Vector3 _speed;
  Vector3 _velocity;
  
  void Awake() {
    _is_target = true;
    _target = Vector3.zero;
    _direction = _target - transform.position;
  }

  void Start() {
    
  }
	
  void Update() {
    Move();
  }
	
  void Move() {
    _direction = _target - transform.position;
    transform.LookAt(_target);
		
    if (Input.GetKey(KeyCode.A)) {
      _velocity.x -= _speed.x;
    }
    if (Input.GetKey(KeyCode.D)) {
      _velocity.x += _speed.x;
    }
		
    _velocity *= 0.95f;
    transform.Translate(_velocity);
  }
	
  public Vector3 GetTargetPos() {
    return _target;
  }
	
  public bool IsTarget() {
    return _is_target;
  }
}
