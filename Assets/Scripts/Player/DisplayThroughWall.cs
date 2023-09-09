using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline), typeof(PlayerMovement))]
public class DisplayThroughWall : MonoBehaviour
{
    private Outline _outline;
    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _outline = GetComponent<Outline>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _playerMovement.RenderFall += EnableOutline;
        _playerMovement.NoRenderFall += DisableOutline;
    }

    private void OnDisable()
    {
        _playerMovement.RenderFall -= EnableOutline;
        _playerMovement.NoRenderFall -= DisableOutline;
    }

    private void EnableOutline() => _outline.enabled = true;

    private void DisableOutline() => _outline.enabled = false;

}
