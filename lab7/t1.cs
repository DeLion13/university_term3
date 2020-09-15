using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab2
{
    class ProductStruct
    {
        public string name;
        public int code;
        public int cash;

        public ProductStruct(string name, int code, int cash) {
            this.name = name;
            this.code = code;
            this.cash = cash;
        }
    }

    class DiscountStruct
    {
        public int code;
        public int percent;

        public DiscountStruct(int percent, int code) {
            this.percent = percent;
            this.code = code;
        }
    }
    //interface
    abstract class DiscountClub
    {
        public abstract void DoDiscount(List<ProductStruct> product);
    }
    //realsubject
    class Discount : DiscountClub
    {
        public override void DoDiscount(List<ProductStruct> product)
        {
            foreach (ProductStruct p in product) {
                Console.WriteLine("Product: \"" + p.name + "\". New cash: " + p.cash);
            }
        }
    }
    //proxy
    class DiscountChecker : DiscountClub
    {
        Discount dis = new Discount();
        private List<DiscountStruct> dis_list = new List<DiscountStruct>();
        public DiscountChecker(List<DiscountStruct> dis_list)
        {
            this.dis_list = dis_list;
        }
        public override void DoDiscount(List<ProductStruct> product)
        {
            List<ProductStruct> discounted = new List<ProductStruct>();
            foreach (ProductStruct p in product) {
                foreach (DiscountStruct d in dis_list) {
                    if (p.code == d.code) {
                        ProductStruct new_prod = p;
                        new_prod.cash = p.cash * d.percent / 100;
                        discounted.Add(new_prod);
                    }
                }
            }
            this.dis.DoDiscount(discounted);
        }
    }
}

