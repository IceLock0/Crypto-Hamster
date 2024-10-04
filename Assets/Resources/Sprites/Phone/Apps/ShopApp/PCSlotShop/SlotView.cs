using Enums.Slot;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Phone.Apps.ShopApp.RepairKitShop.PCSlotShop
{
    public class SlotView : MonoBehaviour
    {
        public PCSlotType Type { get; private set; }

        public void Buy()
        {
            Type = PCSlotType.Unavailable;
            GetComponent<Image>().color = Color.red;
        }
    }
}