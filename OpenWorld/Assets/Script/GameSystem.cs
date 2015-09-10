
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameSystem : MonoBehaviour {

  [SerializeField]
  Tower _tower;
  
  [SerializeField]
  Canvas _finish;
  
  [SerializeField]
  Text _score_text;
  
  [SerializeField]
  Player _player;

  void Start () {}
	
  void Update () {
    _score_text.GetComponent<Text>().text = _player.GetComponent<Player>().GetScore().ToString();
    
    if (!_tower.IsDead()) return;
    
    _finish.GetComponent<Canvas>().enabled = true;
    
    if (Input.anyKeyDown) {
      Application.LoadLevel(0);
      _finish.GetComponent<Canvas>().enabled = false;
    }
  }
}
