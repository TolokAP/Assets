﻿using UnityEngine;
<<<<<<< dev
<<<<<<< dev

using UnityEngine.EventSystems;
using UnityEngine.UI;

using Photon.Bolt;
using Photon.Bolt.Utils;
=======
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
>>>>>>> Добавлен UI эллементы
=======

using UnityEngine.EventSystems;
using UnityEngine.UI;

using Photon.Bolt;
using Photon.Bolt.Utils;
>>>>>>> все внесено

namespace Player
{
    public class InventoryDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, IPointerDownHandler
    {
        
        public GameObject inventory;
        public GameObject itemSlot;
        public int slot = -1;
        public Transform startParent;
        public GameObject dragPosition;
       
        public GameObject info;


        public void OnPointerClick(PointerEventData eventData)
        {
            inventory.GetComponent<InventoryPlayer>().OpenWindowItemInfo(gameObject.transform, slot);

        }
        private void Start()
        {
            startParent = transform.parent;
            inventory = GameObject.FindGameObjectWithTag("Inventory");
            dragPosition = GameObject.FindGameObjectWithTag("Canvas");
        }
        public void OnBeginDrag(PointerEventData eventData)
        {
           
            
           


            if (inventory == null) return;
            GetComponent<Image>().raycastTarget = false;
           
            BoltLog.Warn("Метод ON BEgin Drag");

            if (inventory.GetComponent<InventoryPlayer>().selectedSlot == null)
                inventory.GetComponent<InventoryPlayer>().selectedSlot = transform.parent.gameObject;
            else if (inventory.GetComponent<InventoryPlayer>().selectedSlot == transform.parent.gameObject)
                inventory.GetComponent<InventoryPlayer>().selectedSlot = null;
            transform.SetParent(dragPosition.transform, true);
            inventory.GetComponent<InventoryPlayer>().CloseWindowItemInfo();
        }

        public void OnDrag(PointerEventData eventData)
        {
          
            transform.position = Input.mousePosition;
      
            
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<Image>().raycastTarget = true;
            transform.SetParent(startParent.transform, true);
            inventory.GetComponent<InventoryPlayer>().selectedSlot = null;
            
                if (eventData.pointerCurrentRaycast.gameObject.GetComponent<InventoryDrop>() == null)
                {
                    transform.localPosition = Vector3.zero;
                    if (eventData.pointerCurrentRaycast.gameObject.GetComponentInParent<Image>() == null)
                    {
                        if (startParent.GetComponent<InventoryDrop>().slotType == InventoryDrop.SlotType.inventory)
                        {
                            BoltLog.Warn("Удаление предмета");
<<<<<<< dev
<<<<<<< dev
                            var evnt = destroyItem.Create(GlobalTargets.OnlySelf);
=======
                            var evnt = destroyItem.Create(Bolt.GlobalTargets.OnlySelf);
>>>>>>> Добавлен UI эллементы
=======
                            var evnt = destroyItem.Create(GlobalTargets.OnlySelf);
>>>>>>> все внесено
                            evnt.slot = slot;
                            evnt.Send();
                        }

                    }


                }
                if(eventData.pointerCurrentRaycast.gameObject.transform == startParent.transform)
                {
                    transform.localPosition = Vector3.zero;
                }
              

        }
       
        public void OnPointerDown(PointerEventData eventData)
        {
          
          
        }
    }
}