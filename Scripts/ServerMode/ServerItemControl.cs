<<<<<<< dev
<<<<<<< dev

using UnityEngine;
using Photon.Bolt;
using Photon.Bolt.Utils;

=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;
>>>>>>> Добавлен UI эллементы
=======

using UnityEngine;
using Photon.Bolt;
using Photon.Bolt.Utils;

>>>>>>> все внесено

namespace Player
{
    [BoltGlobalBehaviour(BoltNetworkModes.Server, "GameScene")]
    public class ServerItemControl : GlobalEventListener
    {
        public ItemDB itemDB;
      
        public ItemData lookUpID(int ID)// ��������� �������� �� ���� ���������.
        {
           
            foreach (ItemData ItemData in itemDB.itemDatabase)
            {
                if (ItemData.ID == ID)
                {
                    return ItemData;
                }
            }
            return null;

        }

<<<<<<< dev
<<<<<<< dev
        public override void SceneLoadLocalDone(string scene, IProtocolToken token)
=======
        public override void SceneLoadLocalDone(string scene)
>>>>>>> Добавлен UI эллементы
=======
        public override void SceneLoadLocalDone(string scene, IProtocolToken token)
>>>>>>> все внесено
        {
            itemDB = GameObject.FindGameObjectWithTag("ItemDB").GetComponent<ItemDB>();
        }
        

        public override void OnEvent(instatiateItemInWorld evnt)//������� ���������� �������, ������� ����� ������� � ��������� ���.
        {
            BoltLog.Warn("�������� ��������");
            var NetIDToken = new NetworkIDToken
            {
                Hand = (int)WeaponHandPosition.None,
                NetworkID = evnt.NetworkID.PackedValue,
                ID = evnt.ID
            };
            BoltNetwork.Instantiate(lookUpID(evnt.ID).prefab, NetIDToken);


        }

        public override void OnEvent(PickUpItem evnt)//��������� ������� �������� �������� (�������� ��������: ������). �������� ������� ������ ������� ������ �������.
        {
            GameObject gameObject = BoltNetwork.FindEntity(evnt.NetworkID);
            BoltNetwork.Destroy(gameObject);
            var ert = PickUpItem.Create(evnt.Entity, EntityTargets.Everyone);
            ert.Entity = evnt.Entity;
            ert.ID = evnt.ID;
            ert.Send();
            BoltLog.Warn("������� �� ������� �������");

        }




    }
}