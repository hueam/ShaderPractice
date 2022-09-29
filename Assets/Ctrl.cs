using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ctrl : MonoBehaviour
{
    public float speed;
    Camera cm;
    [SerializeField]Material m;
    [SerializeField]Transform gunpos;
    Weapon weapon;
    void Start()
    {
        cm = Camera.main;
        WeaponSpawn();
    }

    void Update()
    {
        Vector3 dir = new Vector3(0, Input.GetAxis("Mouse X"), 0);
        transform.eulerAngles += dir * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Tab))
            WeaponSpawn();
    }
    void WeaponSpawn()
    {
        weapon = PoolManager.instance.Pop().GetComponent<Weapon>();
        m = weapon.gameObject.GetComponent<MeshRenderer>().material;
        weapon.transform.SetParent(gunpos, false);
        StartCoroutine(WeaponShader());
    }

    IEnumerator WeaponShader()
    {
        bool a = m.GetFloat("_Value") > -0.08f;
        while (a)
        {
            a = m.GetFloat("_Value") > -0.08f;
            Debug.Log(a);
            m.SetFloat("_Value", Mathf.Lerp(m.GetFloat("_Value"), -0.1f, 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
