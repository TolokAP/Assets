using UnityEngine;
<<<<<<< dev
<<<<<<< dev

using UnityEngine.EventSystems;
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
using Photon.Bolt;
using Photon.Bolt.Utils;
>>>>>>> все внесено
namespace Player
{
    public class InventoryDrop : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public int slot = -1;
        public enum SlotType { inventory, equipment };
       
       
        public SwapType swapType;
        public SlotType slotType;
        public GameObject inventorySlot;
        public TypeEquipment typeEquipment;
       
        private void Start()
        {
            inventorySlot = GameObject.FindGameObjectWithTag("Inventory");
            
        }




        public void OnDrop(PointerEventData eventData)
        {

            switch (slotType)
            {
                case SlotType.inventory:
                    if (inventorySlot.GetComponent<InventoryPlayer>().selectedSlot.GetComponent<InventoryDrop>().slotType == SlotType.inventory) swapType = SwapType.swapSlotInventory;
                    else
                    {
                       swapType = SwapType.fromEquipment;
                    }
                    break;
                case SlotType.equipment:
                    if (inventorySlot.GetComponent<InventoryPlayer>().selectedSlot.GetComponent<InventoryDrop>().slotType == SlotType.inventory) swapType = SwapType.toEquipment;
                    else return;
                    break;
            }

            


            if (inventorySlot.GetComponent<InventoryPlayer>().selectedSlot == null)
            { BoltLog.Warn("Пустой слот"); }
            else
            {
<<<<<<< dev
<<<<<<< dev
                var evnt = swapSlots.Create(GlobalTargets.OnlySelf);
=======
                var evnt = swapSlots.Create(Bolt.GlobalTargets.OnlySelf);
>>>>>>> Добавлен UI эллементы
=======
                var evnt = swapSlots.Create(GlobalTargets.OnlySelf);
>>>>>>> все внесено
                evnt.from = inventorySlot.GetComponent<InventoryPlayer>().selectedSlot.GetComponent<InventoryDrop>().slot;
                evnt.to = slot;
                evnt.swapType = swapType.GetHashCode();
                evnt.Send();
                //BoltLog.Warn("Отправка события дроп " + slot);
                inventorySlot.GetComponent<InventoryPlayer>().selectedSlot = null;
               
            }

        }
       
        public void OnPointerEnter(PointerEventData eventData)
        {
          
        }

        public void OnPointerExit(PointerEventData eventData)
        {

        }



    }
}