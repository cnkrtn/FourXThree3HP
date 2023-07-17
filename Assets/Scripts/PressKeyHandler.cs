using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressKeyHandler : MonoBehaviour
{
  public KeyCode key;

  private Button _button;
  
  private AudioManager _audioManager;
  private GameManager _gameManager;
  public List<AudioClip> list;

  private void Awake()
  {
    _button = GetComponent<Button>();
    _audioManager = FindObjectOfType<AudioManager>();
    _gameManager = FindObjectOfType<GameManager>();
  }

  private void Update()
  {
    if (Input.GetKeyDown((key)))
    {
      ColorChangeOnPress(_button.colors.pressedColor);
      _button.onClick?.Invoke();
    }
    else if (Input.GetKeyUp(key))
    {
      ColorChangeOnPress(_button.colors.normalColor);
    }
  }

  private void ColorChangeOnPress(Color color)
  {
    Graphic graphic = GetComponent<Graphic>();
    graphic.CrossFadeColor(color,_button.colors.fadeDuration,true,true);
  }

  public void OnButtonPressedGroup1(int index)
  {
    _audioManager.StopSound();
    _audioManager.PlaySound(list[index]);
  }
  
  public void OnButtonPressedGroup2(int index)
  {
    _audioManager.StopSound2();
    _audioManager.PlaySound2(list[index]);
  }
  
  public void OnButtonPressedGroup3(int index)
  {
    _audioManager.StopSound3();
    _audioManager.PlaySound3(list[index]);
  }
}
