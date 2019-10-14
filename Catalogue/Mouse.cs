﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace Catalogue
{
    class Mouse
    {
        int _id;
        string _brand;
        string _model;
        int _price;

        public Mouse(int id, string brand, string model, int price)
        {
            this._id = id;
            this._brand = brand;
            this._model = model;
            this._price = price;
        }

        public int Id { get { return _id; } }
        public string Brand { get { return _brand; } }
        public string Model { get { return _model; } }
        public int Price { get { return _price; } }
    }
    class Mouseread
    { 
        public void mousedisplay()
        {
           XElement xelement =  XElement.Load("Mouse.xml");
            IEnumerable<XElement> Mouse = xelement.Elements();
                Console.WriteLine("--------------------Available Mouse Variants------------------------");
            foreach (var mouse in Mouse)
            {
                String id = mouse.Element("ID").Value;
                String brandname = mouse.Element("brand").Value;
                String price_detail =mouse.Element("price").Value;
                String model_detail = mouse.Element("model").Value;
               
                Console.WriteLine("Id: {0}",id);
                Console.WriteLine("Brand: {0}",brandname);
                Console.WriteLine("Model: {0}",model_detail);
                Console.WriteLine("Price: Rs. {0}",price_detail);
                Console.WriteLine("--------------------------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("----Please Enter the Item Id you wish to buy---");
            mousedisplay1();
        }
        public void mousedisplay1()
        {
            int price = 0;
            int qty = 0;
            String user_id = Console.ReadLine();
            Console.Clear();
            XElement xelement =  XElement.Load("Mouse.xml");
            IEnumerable<XElement> Mouses = xelement .Elements();
            var x = from Mouse in xelement.Elements("Mouse")
                    where (string)Mouse.Element("ID") == user_id
                    select Mouse;
            Console.WriteLine("---------------------------Your Selection-----------------------------");
            Console.WriteLine();
            foreach (XElement mouse in x)
            {
                String id = mouse.Element("ID").Value;
                String brandname =  mouse.Element("brand").Value;
                String price_detail =  mouse.Element("price").Value;
                String model_detail =  mouse.Element("model").Value;

                price = Convert.ToInt32(price_detail);

                Console.WriteLine("Id: {0}",id);
                Console.WriteLine("Brand: {0}",brandname);
                Console.WriteLine("Model: {0}",model_detail);
                Console.WriteLine("Price: Rs. {0}",price_detail);
                Console.WriteLine("----------------------------------------------------------------------");
            }
            String user_choice;
            do
            {
                Console.WriteLine("Enter the Quantity Required");
                qty = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Total Price: Rs. {0}", qty * price);

                Console.WriteLine();
                Console.WriteLine("Do you want to Change quantity? (y/n)");
                user_choice = Console.ReadLine();
                Console.WriteLine();

                if (user_choice == "n")

                    Console.WriteLine("Thank you for visiting us...");

                while ((user_choice != "y") && (user_choice != "n"))
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Option. Please Choose 'y' or 'n'");
                    user_choice = Console.ReadLine();
                }
            } while (user_choice == "y");
        }
    }
}