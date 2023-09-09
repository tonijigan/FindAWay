using UnityEngine;
using UnityEngine.UI;

public class ButtonsDynamic : MonoBehaviour
{
    [SerializeField] private Button _buttonPickUp, _buttonPutDown;
    [SerializeField] private InteractionWithObjects _interactionWithObjects;

    private GameObject _currentObject;

    private void Awake() => DisableButtons();

    private void OnEnable()
    {
        _interactionWithObjects.HitInteractionObject += OnEnableButtons;
        _interactionWithObjects.HitButton += OnEnableButtons;
        _buttonPickUp.onClick.AddListener(ClickPickUp);
        _buttonPutDown.onClick.AddListener(ClickPutDown);
    }

    private void OnDisable()
    {
        _interactionWithObjects.HitInteractionObject -= OnEnableButtons;
        _interactionWithObjects.HitButton -= OnEnableButtons;
        _buttonPickUp.onClick.RemoveListener(ClickPickUp);
        _buttonPutDown.onClick.RemoveListener(ClickPutDown);
    }

    public void Init(GameObject currentObject) => _currentObject = currentObject;

    public void DisableButtons()
    {
        _buttonPickUp.gameObject.SetActive(false);
        _buttonPutDown.gameObject.SetActive(false);
    }

    private void OnEnableButtons()
    {
        if (_interactionWithObjects.IsDragging == false)
            _buttonPickUp.gameObject.SetActive(true);
        else if (_interactionWithObjects.DragableObject.TryGetComponent(out Key key) == false)
            _buttonPutDown.gameObject.SetActive(true);
    }

    private void ClickPickUp()
    {
        _currentObject.TryGetComponent(out InteractionObject interactionObject);
        _interactionWithObjects.TryPickUp(interactionObject);
    }

    private void ClickPutDown()
    {
        _currentObject.TryGetComponent(out ButtonObject buttonObject);
        _interactionWithObjects.PutDown(buttonObject.BoxPoint);
        DisableButtons();
    }
}