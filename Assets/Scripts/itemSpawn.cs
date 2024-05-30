using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawn : MonoBehaviour
{
    [SerializeField] GameObject itemPrefab;

    void Start()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        if (transform.childCount == 0)
        {
            Instantiate(itemPrefab, transform);
        }
    }

    void Update()
    {
        CheckItem();
    }

    void CheckItem()
    {
        if (transform.childCount == 0)
        {
            StartCoroutine(CheckChild());
        }
    }

    IEnumerator CheckChild()
    {
        yield return new WaitForSeconds(5);
        SpawnItem();
    }
}
