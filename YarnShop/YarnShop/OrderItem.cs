using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnShop
{
    public class OrderItem
    {
        // Attributes
        private Product Product {  get; set; }
        private int Quantity;
        private int QuantityRemaining;
        private int QuantityVoided;
        private int QuantityReturned;
        public OrderItem(Product product, int quantity, int quantityVoided, int quantityReturned) // Constructor
        {
            this.Quantity = quantity;
            this.QuantityVoided = quantityVoided;
            this.QuantityReturned = quantityReturned;
            this.QuantityRemaining = quantity - quantityVoided - quantityReturned;
            this.Product = product;
        }

        // Getters
        public int quantity
        {
            get { return Quantity; }
        }
        public int quantityVoided
        {
            get { return QuantityVoided; }
        }
        public int quantityReturned
        {
            get { return QuantityReturned; }
        }
        public int quantityRemaining
        {
            get { return QuantityRemaining; }
        }
        public Product product
        {
            get { return Product; }
        }
        public void SetQuantity(int newQuantity)
        {
            Quantity = newQuantity;
        }
        //Used as display members
        public string QuantityString
        {
            get
            {
                return Convert.ToString(quantity);
            }
        }
        public string name
        {
            get { return product.name; }
        }
        public string CostString
        {
            get { return product.CostString; }
        }
        public string Desc
        {
            get
            {
                return "x" + Convert.ToString(quantity) + " " + product.name;
            }
        }
        public string CostTotalString
        {
            // Returns the total cost of this specific order item in the order.
            get
            {
                return "£" + (product.cost*quantity).ToString("0.00");
            }
        }
    }
}
