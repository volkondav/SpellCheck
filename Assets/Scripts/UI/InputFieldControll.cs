using TMPro;
using UnityEngine;

public class InputFieldControll : MonoBehaviour
{
    [SerializeField] private TMP_InputField myInputField;

    private void Update()
    {
        myInputField.Select();
        myInputField.ActivateInputField();
    }
}
