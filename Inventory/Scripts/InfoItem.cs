
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player {
    public class InfoItem : MonoBehaviour, IPointerClickHandler
    {
        public int slotID;
        [SerializeField]
        private TMP_Text _nameItem;
        [SerializeField]
        private TMP_Text _damage;
        [SerializeField]
        private TMP_Text _descriptionAbility;
   

      
      

        public void OnPointerClick(PointerEventData eventData)
        {
            Destroy(gameObject);
        }


        public void SetStringInfo(string itemName, string itenDamage, string itemSpecialAttack)
        {
          
<<<<<<< dev
<<<<<<< dev
        
=======
            BoltLog.Warn("��� �������� � ���������" + itemName + itenDamage + itemSpecialAttack);
>>>>>>> Добавлен UI эллементы
=======
        
>>>>>>> все внесено
            _nameItem.text = itemName;
            _damage.text = itenDamage;
            _descriptionAbility.text = itemSpecialAttack;

        }
    }
}