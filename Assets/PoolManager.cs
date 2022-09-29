using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [SerializeField] GameObject prefabs;
    public static PoolManager instance;
    public Stack<GameObject> weapons = new Stack<GameObject>();
    void Awake()
    {
        instance = this;
        GameObject weapon;
        for (int i = 0; i < 20; i++)
        {
            weapon = GameObject.Instantiate(prefabs, transform);
            weapon.SetActive(false);
            weapon.transform.SetParent(this.transform);
            weapons.Push(weapon);
        }
    }
    public GameObject Pop()
    {
        GameObject weapon;
        if (weapons.Count > 0)
            weapon = weapons.Pop();
        else
        {
            weapon = GameObject.Instantiate(prefabs,transform);
            weapon.SetActive(false);
        }
        weapon.transform.rotation = Quaternion.identity;
        weapon.SetActive(true);
        return weapon;
    }
    public void Push(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = transform.position;
        weapons.Push(obj);
    }
}
