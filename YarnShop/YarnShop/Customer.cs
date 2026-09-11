using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnShop
{
    public class Customer
    {
        // Attributes
        private int ID {  get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string EmailAddress { get; set; }
        private string PhoneNum { get; set; }
        private string MemType { get; set; }
        private int TotalStars { get; set; }
        private int VoucherNum { get; set; }

        public Customer(int newID, string newFirstName, string newLastName, string newPhoneNum, string newEmailAddress, string newMemType, int newTotalStars, int newVoucherNum) // Constructor
        {
            ID = newID;
            FirstName = newFirstName;
            LastName = newLastName;
            PhoneNum = newPhoneNum;
            EmailAddress = newEmailAddress;
            MemType = newMemType;
            TotalStars = newTotalStars;
            VoucherNum = newVoucherNum;
        }

        // Getters
        public int id
        {
            get{return ID;}
        }
        public string firstName
        {
            get { return FirstName; }
        }
        public string lastName
        {
            get { return LastName; }
        }
        public string phoneNum
        {
            get { return PhoneNum; }
        }
        public string emailAddress
        {
            get { return EmailAddress; }
        }
        public string memType
        {
            get { return MemType; }
        }
        public int totalStars
        {
            get
            {
                return TotalStars;
            }
        }
        public int voucherNum
        {
            get
            {
                return VoucherNum;
            }
        }
        public string fullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }
        public string idName
        {
            get
            {
                return ("(" + ID + ")" + " " + fullName);
            }
        }

        // Setters
        public void SetMemType(string newMemType)
        {
            MemType = newMemType;
        }
        public void SetTotalStars(int newTotalStars)
        {
            TotalStars = newTotalStars;
        }
        public void SetVoucherNum(int newVoucherNum)
        {
            VoucherNum = newVoucherNum;
        }
    }
}
