
using UnityEngine;
using System.Collections;


public class GameCamera : MonoBehaviour {

  [SerializeField]
  GameObject _player;
  
  [SerializeField]
  float _offsetY;
	
  Vector3 _direction;

  void Awake() {}

  void Start() {
    transform.LookAt(_player.GetComponent<Player>().GetTargetPos());
    SeekDirection();
  }
	
  void Update() {
    Move();
    Rotate();
    if (!_player.GetComponent<Player>().IsTarget()) return;
    SeekDirection();
    SetLookAt();
  }
	
  void Move() {
    Vector3 offset = new Vector3(0, _offsetY, 0);
    Vector3 dir = _player.transform.forward;
    transform.position = _player.transform.position + offset - dir * 6;
  }
	
  void SeekDirection() {
    Vector3 offset = new Vector3(0, _offsetY, 0);
    _direction = _player.GetComponent<Player>().GetTargetPos() - _player.transform.position + offset;
    _direction.Normalize();
  }
	
  void SetLookAt() {
    transform.LookAt(_player.GetComponent<Player>().GetTargetPos());
  }
  
  void Rotate() {
    Vector3 offset = new Vector3(0, 1, 0);
    Vector3 dir = (_player.transform.position + offset) - transform.position;
    transform.forward = dir;
  }
}
