using System.Collections;
using UnityEngine;
using TMPro;

public class TextSelector : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    public void ChangeSelection(int start, int end, int adjustValue)
    {
        _inputField.selectionAnchorPosition = start - adjustValue;
        _inputField.selectionFocusPosition = end - adjustValue;
        _inputField.DeactivateInputField();
    }

    public IEnumerator Select(int start, int end, int adjustValue)
    {
        if (end - start <= 1)
        {
            start = 0;
            end = 0;
        }
        _inputField.ActivateInputField();
        yield return new WaitForSeconds(0.1f);
        ChangeSelection(start, end, adjustValue);
    }
}
