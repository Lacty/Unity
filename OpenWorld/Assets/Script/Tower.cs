
using UnityEngine;
using System.Collections;


public class Tower : MonoBehaviour {

  [SerializeField]
  private int _life;
  public int Life {
    get { return _life; }
    set { _life = value; }
  }

  void Start() {}
	
  void Update() {}
  
  void OnCollisionEnter(Collision collision) {
    var enemy = collision.gameObject.GetComponent<Enemy>();
    if (enemy == null) return;
    
    enemy.Hide();
    _life--;
  }
}
