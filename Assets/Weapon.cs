using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Material mat;
    [SerializeField] Rigidbody rb;
    [SerializeField] Collider col;
    public IEnumerator coroutine;

    private void Start()
    {
        coroutine = Chuck();
        mat = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            StartCoroutine(Chuck());
    }
    IEnumerator Chuck()
    {
        rb.useGravity = true;
        transform.SetParent(null);

        rb.AddForce(Vector3.up*5,ForceMode.Impulse);

        bool isGround = false;
        while (!isGround)
        {
            isGround = Physics.Raycast(transform.position, Vector3.down, 1 << 7);
            yield return null;
        }
        col.isTrigger = false;
        yield return new WaitForSeconds(3f);

        rb.useGravity = false;
        while (mat.GetFloat("_Value") < 0.99f)
        {
            mat.SetFloat("_Value", Mathf.Lerp(mat.GetFloat("_Value"), 1f, 0.5f));
            yield return new WaitForSeconds(0.05f);
        }
        PoolManager.instance.Push(this.gameObject);
    }
}
