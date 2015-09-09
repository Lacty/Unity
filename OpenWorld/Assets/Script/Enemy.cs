using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

  [SerializeField]
  GameObject _tower;
  
  [SerializeField]
  Vector3 _speed;
  
  [SerializeField]
  int _effect_life;
  bool _is_dead;

  void Awake() {
    GetComponent<ParticleSystem>().Stop();
  }

  void Start () {
    Vector3 target = new Vector3(_tower.transform.position.x,
                                 0.5f,
                                 _tower.transform.position.z);
    transform.LookAt(target);
  }
	
  void Update () {
    if (!_is_dead) {
      transform.Translate(_speed);
    }
    
    if (!_is_dead) return;
    _effect_life--;
    
    if (_effect_life > 0) return;
    GameObject.Destroy(gameObject);
  }
  
  public void Hide() {
    _is_dead = true;
    GetComponent<ParticleSystem>().Play();
  }
}
