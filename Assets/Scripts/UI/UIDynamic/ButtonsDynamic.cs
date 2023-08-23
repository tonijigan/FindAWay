using UnityEngine;
using UnityEngine.UI;

public class ButtonsDynamic : MonoBehaviour
{
    [SerializeField] private Button _buttonPickUp, _buttonPutDown;
    [SerializeField] private InteractionWithObjects _interactionWithObjects;

    private Transform _currentTransform;

    private void Awake() => DisableButtons();

    private void OnEnable()
    {
        _interactionWithObjects.OnHitBox += EnableButtons;
        _interactionWithObjects.OnHitButton += EnableButtons;
        _buttonPickUp.onClick.AddListener(OnClickPickUp);
        _buttonPutDown.onClick.AddListener(OnClickPutDown);
    }

    private void OnDisable()
    {
        _interactionWithObjects.OnHitBox -= EnableButtons;
        _interactionWithObjects.OnHitButton -= EnableButtons;
        _buttonPickUp.onClick.RemoveListener(OnClickPickUp);
        _buttonPutDown.onClick.RemoveListener(OnClickPutDown);
    }

    public void DisableButtons()
    {
        _buttonPickUp.gameObject.SetActive(false);
        _buttonPutDown.gameObject.SetActive(false);
    }

    public Transform Init(Transform currentTransform)
    {
        return _currentTransform = currentTransform;
    }

    private void EnableButtons()
    {
        if (_interactionWithObjects.IsDragging == false)
            _buttonPickUp.gameObject.SetActive(true);
        else
            _buttonPutDown.gameObject.SetActive(true);
    }

    private void OnClickPickUp()
    {
        _currentTransform.TryGetComponent(out Box box);
        _interactionWithObjects.TryPickUp(box);
    }

    private void OnClickPutDown()
    {
        _currentTransform.TryGetComponent(out ButtonObject buttonObject);
        _interactionWithObjects.PutDown(buttonObject.BoxPoint);
        DisableButtons();
    }
}
