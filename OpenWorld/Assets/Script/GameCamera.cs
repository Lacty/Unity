
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
  }
	
  void Update() {
    SeekDirection();
    Move();
    SetLookAt();
  }
	
  void Move() {
    Vector3 offset = new Vector3(0, _offsetY, 0);
    Vector3 translate = _player.transform.position - _player.GetComponent<Player>().LastPos;
    //transform.position += translate;
    transform.position = _player.transform.position + offset - _direction * 6;
    _player.GetComponent<Player>().LastPos = _player.transform.position;
  }
	
  void SeekDirection() {
    if (!_player.GetComponent<Player>().IsTarget()) return;
    Vector3 offset = new Vector3(0, _offsetY, 0);
    _direction = _player.GetComponent<Player>().GetTargetPos() - _player.transform.position + offset;
    _direction.Normalize();
  }
	
  void SetLookAt() {
    if (!_player.GetComponent<Player>().IsTarget()) return;
    transform.LookAt(_player.GetComponent<Player>().GetTargetPos());
  }
}
