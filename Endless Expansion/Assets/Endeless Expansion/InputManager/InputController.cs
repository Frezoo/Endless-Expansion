using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    private bool isOpen = false;
    public UnityEvent OpenSettings;
    public UnityEvent CloseSettings;

    public void OnOpenCloseSettings(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Нажато");
            isOpen = !isOpen;
            if (isOpen == false)
            {
                CloseSettings?.Invoke();
                Debug.Log("Закрыты настройки");
            }
            else
            {
                OpenSettings?.Invoke();
                Debug.Log("Открыты настройки");
            }
        }
    }
}