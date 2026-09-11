using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YarnShop
{
    public class Supplier
    {
        // Attributes
        private int ID { get; set; }
        private string SupplierName { get; set; }
        private string EmailAddress { get; set; }
        private string PhoneNum { get; set; }
        private string Address { get; set; }
        private string Postcode { get; set; }
        private string URL { get; set; }

        public Supplier(int newID, string newSupplierName, string newEmailAddress, string newPhoneNum, string newAddress, string newPostcode, string newurl) // Constructor
        {
            ID = newID;
            SupplierName = newSupplierName;
            EmailAddress = newEmailAddress;
            PhoneNum = newPhoneNum;
            Address = newAddress;
            Postcode = newPostcode;
            URL = newurl;
        }

        // Getters
        public int id
        {
            get { return ID; }
        }
        public string supplierName
        {
            get { return SupplierName; }
        }
        public string emailAddress
        {
            get { return EmailAddress; }
        }
        public string phoneNum
        {
            get { return PhoneNum; }
        }
        public string address
        {
            get { return Address; }
        }
        public string postcode
        {
            get { return Postcode; }
        }
        public string url
        {
            get { return URL; }
        }
        public string idName
        {
            get { return "[" + id + "] " + supplierName; }
        }
    }
}
