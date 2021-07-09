using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyProgression : MonoBehaviour
{
   [SerializeField] LevelConfiguration[] ProgressionList; 
   [SerializeField] int CurrentIndex = 0;

   public int GetCurrentIndex() => CurrentIndex;
   public void SetCurrentIndex(int newIndex) => CurrentIndex = newIndex;
   public bool HasNextLevel(int index, out LevelConfiguration level)
   {
     Debug.Log("ProgressionList.Length: " + ProgressionList.Length);
     if(index >= ProgressionList.Length || index < 0)
     {
       level = null;
       return false;
     }
     level = ProgressionList[index];
     return true;
   }
}
