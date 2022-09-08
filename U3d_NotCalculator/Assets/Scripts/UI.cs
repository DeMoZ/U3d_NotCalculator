using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private CalcView cView;
    [SerializeField] private PopupView pView;
    public CalcView CalcView => cView;
    public PopupView PopupView => pView;
}