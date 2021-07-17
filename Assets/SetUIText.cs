using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetUIText : MonoBehaviour
{
    public TMP_Text label;

    public void SetLabel(string value) => label.text = value;
}
