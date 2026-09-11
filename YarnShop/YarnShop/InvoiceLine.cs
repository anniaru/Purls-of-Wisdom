using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YarnShop
{
    // Used to create a list of lines to print on the invoice for an order.
    public class InvoiceLine
    {
        // Attributes
        private string Text { get; set; }
        private Font Font { get; set; }
        private float Width { get; set; }
        private StringFormat Format { get; set; }
        private float HeightInc { get; set; }

        public InvoiceLine(string text, Font font, float width, StringFormat format, float heightInc) // Constructor
        {
            this.Text = text;
            this.Font = font;
            this.Width = width;
            this.Format = format;
            this.HeightInc = heightInc;
        }

        // Getters
        public string text
        {
            get { return Text; }
        }
        public Font font
        {
            get { return Font; }
        }
        public float width
        {
            get { return Width; }
        }
        public StringFormat format
        {
            get { return Format; }
        }
        public float heightInc
        {
            get { return HeightInc; }
        }
    }
}
