using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PointerEvent : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler 
{
    [SerializeField] private Color normalColor = Color.white;
    [SerializeField] private Color enterColor = Color.white;
    [SerializeField] private Color downColor = Color.white;
    [SerializeField] private UnityEvent OnClick = new UnityEvent();
    
    public int numOfsteps = 0;
    public Animator anim;
    private bool relesed = true;

    private MeshRenderer meshRenderer = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        meshRenderer.material.color = enterColor;
        print("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        meshRenderer.material.color = normalColor;
        print("Exit");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (relesed)
        {
            relesed = false;
            int temp = anim.GetInteger("state");
            temp++;
            anim.SetInteger("state", temp);
            if (anim.GetInteger("state") >= numOfsteps && SceneManager.GetActiveScene().name == "SampleScene")
            {
                //anim.SetInteger("state", 0);
                //anim.ResetTrigger("state");
                SceneManager.LoadScene("part2");
            }
            print(anim.GetInteger("state"));
        }

        meshRenderer.material.color = downColor;
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        relesed = true;
        meshRenderer.material.color = enterColor;
        print("Up");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        OnClick.Invoke();
        print("Click");
    }
}
