
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
  
  bool _is_play_se = false;

  void Start () {}
	
  void Update () {
    _score_text.GetComponent<Text>().text = _player.GetComponent<Player>().GetScore().ToString();
    
    if (!_tower.IsDead()) return;
    
    if (!_is_play_se) {
      GetComponent<AudioSource>().Play();
      _is_play_se = true;
    }
    
    _finish.GetComponent<Canvas>().enabled = true;
    
    if (Input.GetKeyDown(KeyCode.Return)) {
      Application.LoadLevel(0);
      _finish.GetComponent<Canvas>().enabled = false;
    }
  }
}
