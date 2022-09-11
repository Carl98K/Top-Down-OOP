using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlashFx : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float flashDuration;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
    private Coroutine flashRoutine;

    void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();   
        originalMaterial = spriteRenderer.material; 
    }

    public void Flash()
    {
        if(flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }

        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;

        yield return new WaitForSeconds(flashDuration);

        spriteRenderer.material = originalMaterial;

        flashRoutine = null;
    }
}
