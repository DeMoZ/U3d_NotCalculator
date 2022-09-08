using UnityEngine;

public class ScenePresenter
{
    private CalcView _cView;
    private PopupView _pView;
    private CalcModel _cModel;
    private string _inputValue;

    public ScenePresenter(CalcView cView, PopupView pView, CalcModel cModel)
    {
        _cView = cView;
        _cModel = cModel;
        _pView = pView;

        cView.Init(OnChange, OnCheck);
        pView.Init(OnNewCallback, OnQuitCallback);
    }

    private void OnQuitCallback()
    {
        _cModel.Save(null);
        Application.Quit();
    }

    private void OnNewCallback()
    {
        _cView.Show(null);
        _cView.gameObject.SetActive(true);
        _pView.gameObject.SetActive(false);
    }

    public void Start()
    {
        _cView.Show(_cModel.Load());
        _pView.gameObject.SetActive(false);
        _cView.gameObject.SetActive(true);
    }

    private void ShowError()
    {
        _cView.gameObject.SetActive(false);
        _pView.gameObject.SetActive(true);
    }

    private void OnCheck()
    {
        var pass = _cModel.TryDivide(_inputValue, out var result);

        if (pass)
            _cView.Show(result.ToString());
        else
            ShowError();
    }

    private void OnChange(string value)
    {
        _inputValue = value;
        _cModel.Save(value);
    }
}