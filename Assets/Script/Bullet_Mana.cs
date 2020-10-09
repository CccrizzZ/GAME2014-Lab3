using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Bullet_Mana : MonoBehaviour
{
    public GameObject bullet;
    private Queue<GameObject> m_bulletPool;
    public int MaxBullets;

    // Start is called before the first frame update
    void Start()
    {
        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        m_bulletPool = new Queue<GameObject>();
        for (int i = 0; i < MaxBullets; i++)
        {
            var tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);
            tempBullet.transform.parent = transform;
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
