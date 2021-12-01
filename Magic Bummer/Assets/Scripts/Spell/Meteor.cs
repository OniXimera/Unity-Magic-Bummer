using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Spell
{
    //fix 30.11.2021
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private MeteorPacket[] _meteorPacket;
    [SerializeField] private bool _testmode;

    private float _lifeTimeTemp;
    private int _final;
    private void OnEnable()
    {
        this._lifeTimeTemp = this._lifeTime;
        foreach (MeteorPacket item in this._meteorPacket)
        {
            item.Fly.transform.position = _player.transform.position + item.position;
            item.Fly.transform.rotation = Quaternion.Euler(0, 0, item.quaternion);
            item.Fly.GetComponent<MeteorFly>().Effect = item.Effect;
            item.Fly.SetActive(true);
            item.Effect.SetActive(false);
        }
    }

    private void Update()
    {

        if (this._lifeTimeTemp > 0)
        {
            foreach (MeteorPacket item in this._meteorPacket)
            {
                if (this._testmode)
                    Debug.DrawRay(item.Fly.transform.position, item.Fly.transform.right * -40, Color.green);
                else
                    if(item.Fly.activeSelf)
                        item.Fly.transform.Translate(Vector2.left * this._speed * Time.deltaTime);
            }
            if (!this._testmode)
                this._lifeTimeTemp -= Time.deltaTime;
        }
        else
            gameObject.SetActive(false);
    }

    public void Fanal()
    {
        this._final++;
        if(this._final == this._meteorPacket.Length)
            gameObject.SetActive(false);
    }
}
[System.Serializable]
public class MeteorPacket
{
    public GameObject Fly;
    public GameObject Effect;
    public float quaternion;
    public Vector3 position;
}
