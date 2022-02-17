using UnityEngine;

public class NumberCubeView : MonoBehaviour
{
    [SerializeField] private TextMesh _textField;
    
    public void Init(NumberCubeModel model)
    {
        model.Changed += UpdateView;
    }

    private void UpdateView(int number)
    {
        _textField.text = number.ToString();
    }
}