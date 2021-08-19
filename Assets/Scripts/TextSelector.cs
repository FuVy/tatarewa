using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSelector : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    [SerializeField]

    public void ChangeSelection(int start, int end)
    {
        _inputField.selectionStringAnchorPosition = start;
        _inputField.selectionStringFocusPosition = end;
        _inputField.ActivateInputField();
        _inputField.DeactivateInputField();
    }

    public IEnumerator Select(int start, int end)
    {
        if (end - start < 1)
        {
            start = 0;
            end = 0;
        }
        yield return new WaitForEndOfFrame();
        ChangeSelection(start, end);
    }
}
