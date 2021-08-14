using UnityEngine;
using TMPro;

public class TextSelector : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;

    public void ChangeSelection(int start, int end, int adjustValue)
    {
        _inputField.selectionAnchorPosition = start - adjustValue + 1;
        _inputField.selectionFocusPosition = end - adjustValue;
    }
}
