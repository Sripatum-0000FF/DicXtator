using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GlassTube : Entity
{
    [SerializeField] private Transform holdPoint;
    [SerializeField] private Transform restPoint;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject glassTube;
    private bool _isHolding = true;
    private bool _isResting = false;
    private void Awake()
    {
        _isHolding = true;
        animator = gameObject.GetComponent<Animator>();
        holdPoint =  GameObject.FindGameObjectWithTag("hold").transform;
        restPoint = GameObject.FindGameObjectWithTag("rest").transform;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    public override void Interact(GameObject obj)
    {
        if (_isResting)
        {
            _isResting = false;
            gameObject.transform.position = holdPoint.position;
            gameObject.transform.rotation = holdPoint.rotation;
            StartCoroutine(WaitPacking());
        }
        
        if(!_isHolding) return;
        
        _isHolding = false;
        rb.useGravity = false;
        gameObject.transform.position = holdPoint.position;
        gameObject.transform.rotation = holdPoint.rotation;
        StartCoroutine(WaitForAnim());
    }

    public IEnumerator WaitPacking()
    {
        GameManager.Instance.YeetPaper();
        animator.SetTrigger("Close");
        paper.SetActive(true);
        yield return new WaitForSeconds(1f);
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        gameObject.transform.position = restPoint.position;
        gameObject.transform.rotation = restPoint.rotation;
        animator.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        rb.AddForce(Vector3.up * 2, ForceMode.Impulse);
        yield return new WaitForSeconds(3f);
        GameManager.Instance.InstantiateGlassTube();
        Destroy(gameObject);
    }
    
    public IEnumerator WaitForAnim()
    {
        animator.SetTrigger("IsOpen");
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(1);
        paper.SetActive(false);
        glassTube.SetActive(false);
        ObjectToRestPoint();
    }
    
    private void ObjectToRestPoint()
    {
        gameObject.transform.position = restPoint.position;
        gameObject.transform.rotation = restPoint.rotation;
        glassTube.SetActive(true);
        animator.SetTrigger("FadeIn");
        GameManager.Instance.GetPaper();
        StartCoroutine(WaitForRest());
    }

    public IEnumerator WaitForRest()
    {
        yield return new WaitForSeconds(1);
        _isResting =  true;
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("ContactPoint"))
        {
            print("Contact");
            SoundManager.Instance.PlaySFX("GlassTubeFalling", 0.8f,1.2f);
        }
    }
}
