using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

  GameObject _tower;
  
  [SerializeField]
  Vector3 _speed;
  
  [SerializeField]
  int _effect_life;
  int _effect_count;
  bool _is_dead;

  void Awake() {
    GetComponent<ParticleSystem>().Stop();
  }

  void Start () {
    _tower = GameObject.Find("Tower");
    _effect_count = _effect_life;
  }
	
  void Update () {
    if (!_is_dead) {
      Vector3 target = new Vector3(_tower.transform.position.x,
                                 0.5f,
                                 _tower.transform.position.z);
      transform.LookAt(target);
      transform.Translate(_speed);
      
      if (_tower.GetComponent<Tower>().IsDead()) {
        Hide();
      }
    }
    
    if (!_is_dead) return;
    _effect_count--;
    if (_effect_count < _effect_life * 0.6) {
      GetComponent<ParticleSystem>().Stop();
    }
    if (_effect_count > 0) return;
    GameObject.Destroy(gameObject);
  }
  
  public void Hide() {
    _is_dead = true;
    GetComponent<ParticleSystem>().Play();
  }
}
