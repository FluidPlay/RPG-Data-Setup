using UnityEngine;
using UnityEngine.UI;
using UniRx;    // Vamos usar o UniRx para criar um evento de OnChange e dispensar o Update

public class UITextFromInt : MonoBehaviour
{
    public Text Text;

    [DisplayScriptableObjectProperty]
    public IntVariable Variable;

    public bool AlwaysUpdate;
    
    private void OnEnable()
    {
        Text.text = Variable.Value + "";
    }

    private void Update()
    {
        if (AlwaysUpdate)
        {
            Text.text = Variable.Value + "";
        }
    }
}
