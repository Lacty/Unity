
using UnityEngine;
using System.Collections;


public class Tower : MonoBehaviour {

  [SerializeField]
  int _life_max;
  int _life;

  void Awake() {
    _life = _life_max;
  }

  void Start() {}
	
  void Update() {}
  
  void OnCollisionEnter(Collision collision) {
    var enemy = collision.gameObject.GetComponent<Enemy>();
    if (enemy == null) return;
    
    enemy.Hide();
    _life--;
    
    Color color = GetComponent<Renderer>().material.color;
    color.r -= 1.0f / _life_max;
    color.g -= 1.0f / _life_max;
    color.b -= 1.0f / _life_max;
    GetComponent<Renderer>().material.color = color;
  }
  
  public bool IsDead() {
    return _life <= 0;
  }
}
