using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField] private UI ui = default;
    
    private void Start()
    {
        var saveLoad = new SaveLoad();
        var cModel = new CalcModel(saveLoad);
        var cView = ui.CalcView;
        var pView = ui.PopupView;

        var presenter = new ScenePresenter(cView, pView, cModel);
        presenter.Start();
    }
}