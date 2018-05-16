using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingLibrary
{
    public class Processing
    {
        public Processing()
        {

        }
        public void ReduceItemUnitQuantity(string itemId, int qty)
        {
            var stockItem = new Stockitem().Load_record_with(Stockitem_support.Column.ItemId, Stockitem_support.LogicalOperator.EQUAL_TO, itemId);
            var newQty = int.Parse(stockItem.UnitQuantity) - qty;
            if(newQty <= 0)
            {
                var unit = ReduceQuantityPerUnit(stockItem.UnitId);
                stockItem.updateRow(stockItem.Id, itemId, stockItem.UnitId, unit.Unit_number);
            }
            else { stockItem.updateRow(stockItem.Id, itemId, stockItem.UnitId, newQty.ToString()); }
        }
        private Unit ReduceQuantityPerUnit(string unitId)
        {
            var unit = new Unit(unitId);
            var unitQty = int.Parse(unit.QuantutyPerUnit) - 1;
            unit.updateRow(unitId, unit.Unit_number, unitQty.ToString());
            return unit;
        }
        public void ManagagingOrders(List<Cart> cartItems, DateTime timeStamp, string buyerId, int amounToPay, string paymentInfo)
        {
            foreach (var itemObject in cartItems)
            {
                var item = new Item(itemObject.ItemID);
                paymentInfo += $"{itemObject.Qty} of {item.Name} at {item.Price} a total of {int.Parse(itemObject.Qty) * int.Parse(item.Price)}. ";
            }
            paymentInfo += $" --- Grand total of {amounToPay} transport inclusive!";
            var newPayment = new Payment();
            newPayment.insert(timeStamp.ToString("yyyy/MM/dd HH:mm:ss"), buyerId, paymentInfo);
            var newOrder = new Orders();
            newOrder.insert(newPayment.Id, buyerId, "");
        }
    }
    public class Cart
    {
        public string ItemID { get; set; }
        public string Qty { get; set; }
    }
}
