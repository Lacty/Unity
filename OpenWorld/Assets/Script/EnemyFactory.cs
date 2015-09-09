using UnityEngine;
using System.Collections;

public class EnemyFactory : MonoBehaviour {

  [SerializeField]
  Enemy _enemy_prefab;
  
  [SerializeField]
  int PopInterval;
  int _count;

  void Start () {}
  
  void Update () {
    _count++;
    
    if (_count < PopInterval) return;
    Create();
    _count = 0;
  }
  
  void Create() {
    var enemy = GameObject.Instantiate(_enemy_prefab);
    
    Vector3 pos = new Vector3();
    switch(Random.Range(1, 4)) {
      case 1 :
        pos = new Vector3(Random.Range(-90, 90), 0.5f, Random.Range(50, 90));
      break;
      
      case 2 :
        pos = new Vector3(Random.Range(-90, 90), 0.5f, Random.Range(-50, -90));
      break;
      
      case 3 :
        pos = new Vector3(Random.Range(50, 90), 0.5f, Random.Range(-90, 90));
      break;
      
      case 4 :
        pos = new Vector3(Random.Range(-50, -90), 0.5f, Random.Range(-90, 90));
      break;
      
      default :
      break;
    }
    
    enemy.transform.position = pos;
  }
}
