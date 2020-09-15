using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace lab3
{

    public class Drink
    {
        public string Base;
        public string Sirup;
        public int Water;
        public int Milk;
        public int Sugar;
    }
    
    public abstract class DrinkBuilder
    {
        public Drink drink;
        public void CraftDrink()
        {
            drink = new Drink();
        }
        public abstract void SetBase();
        public abstract void SetSirup();
        public abstract void SetMilk();
        public abstract void SetSugar();
        public abstract void SetWater();
        public Drink GiveUp()
        {
            return drink;
        }
    }
    public class Espresso : DrinkBuilder
    {
        public override void SetBase()
        {
            drink.Base = "Coffee";
        }
        public override void SetSirup()
        {
            drink.Sirup = "None";
        }
        public override void SetMilk()
        {
            drink.Milk = 0;
        }
        public override void SetSugar()
        {
            drink.Sugar = 0;
        }
        public override void SetWater()
        {
            drink.Water = 50;
        }
    }
    public class Americano : DrinkBuilder
    {
        public override void SetBase()
        {
            drink.Base = "Espresso";
        }
        public override void SetSirup()
        {
            drink.Sirup = "None";
        }
        public override void SetMilk()
        {
            drink.Milk = 0;
        }
        public override void SetSugar()
        {
            drink.Sugar = 0;
        }
        public override void SetWater()
        {
            drink.Water = 200;
        }
    }

    public class VanillaLatte : DrinkBuilder
    {
        public override void SetBase()
        {
            drink.Base = "Espresso";
        }
        public override void SetSirup()
        {
            drink.Sirup = "Vanilla";
        }
        public override void SetMilk()
        {
            drink.Milk = 50;
        }
        public override void SetSugar()
        {
            drink.Sugar = 2;
        }
        public override void SetWater()
        {
            drink.Water = 200;
        }
    }

    public class Tea : DrinkBuilder
    {
        public override void SetBase()
        {
            drink.Base = "Tea";
        }
        public override void SetSirup()
        {
            drink.Sirup = "None";
        }
        public override void SetMilk()
        {
            drink.Milk = 0;
        }
        public override void SetSugar()
        {
            drink.Sugar = 2;
        }
        public override void SetWater()
        {
            drink.Water = 250;
        }
    }

    public class Cocoa : DrinkBuilder
    {
        public override void SetBase()
        {
            drink.Base = "Nesquick";
        }
        public override void SetSirup()
        {
            drink.Sirup = "None";
        }
        public override void SetMilk()
        {
            drink.Milk = 250;
        }
        public override void SetSugar()
        {
            drink.Sugar = 0;
        }
        public override void SetWater()
        {
            drink.Water = 0;
        }
    }

    
    public class Controller
    {
        public Drink GiveDrink(DrinkBuilder drinkBuilder)
        {
            drinkBuilder.CraftDrink();
            drinkBuilder.SetBase();
            drinkBuilder.SetMilk();
            drinkBuilder.SetSirup();
            drinkBuilder.SetSugar();
            drinkBuilder.SetWater();
            return drinkBuilder.GiveUp();
        }
    }
}
