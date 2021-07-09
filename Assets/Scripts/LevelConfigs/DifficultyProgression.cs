using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyProgression : MonoBehaviour
{
   [SerializeField] LevelConfiguration[] ProgressionList; 
   [SerializeField] int CurrentIndex = 0;

   public int GetCurrentIndex() => CurrentIndex;
   public void SetCurrentIndex(int newIndex) => CurrentIndex = newIndex;
}
