
using System;

abstract class Goods
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; protected set; }
    private static int _nextId = 1;
    public int Article { get; private set; }

    public Goods(string name, decimal price)
    {
        Name = name;
        Price = price;
        Description = $"Для товара {name} описание не задано";
        Article = _nextId++;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Артикул: {Article}, Название: {Name}, Описание: {Description}, Цена: {Price:C2} рублей");
    }

    public bool ChangeDescription(string newDescription)
    {
        if (newDescription.Length >= 20 && newDescription.Length <= 200)
        {
            Description = newDescription;
            return true;
        }
        return false;
    }

    
    public abstract void UpdatePrice();
}

class Beverage : Goods
{
    public double SugarConcentration { get; private set; }

    public Beverage(string name, decimal price, double sugarConcentration) : base(name, price)
    {
        SugarConcentration = sugarConcentration;
        UpdatePrice();
    }

    public override void UpdatePrice()
    {
        if (SugarConcentration > 5)
        {
            Price *= 1.10m; 
        }
    }
}

class Food : Goods
{
    public int ShelfLife { get; private set; }

    public Food(string name, decimal price, int shelfLife) : base(name, price)
    {
        ShelfLife = shelfLife;
        UpdatePrice();
    }

    public override void UpdatePrice()
    {
        if (ShelfLife < 30)
        {
            Price *= 1.05m; 
        }
        else if (ShelfLife > 365)
        {
            Price *= 0.95m; 
        }
    }
}

class Program
{
    static void Main()
    {
        Beverage[] beverages = new Beverage[5]
        {
            new Beverage("Напиток 1", 100.00m, 4.5),
            new Beverage("Напиток 2", 150.00m, 5.5),
            new Beverage("Напиток 3", 120.00m, 6.0),
            new Beverage("Напиток 4", 110.00m, 3.0),
            new Beverage("Напиток 5", 130.00m, 7.0)
        };

        Food[] foods = new Food[5]
        {
            new Food("Продукт 1", 80.00m, 20),
            new Food("Продукт 2", 200.00m, 400),
            new Food("Продукт 3", 150.00m, 10),
            new Food("Продукт 4", 90.00m, 700),
            new Food("Продукт 5", 160.00m, 50)
        };

       
        SortGoods(beverages);
        Console.WriteLine("Напитки:");
        PrintGoodsArray(beverages);

       
        SortGoods(foods);
        Console.WriteLine("\nПродукты:");
        PrintGoodsArray(foods);
    }

    static void SortGoods(Goods[] goodsArray)
    {
       
        for (int i = 0; i < goodsArray.Length - 1; i++)
        {
            for (int j = i + 1; j < goodsArray.Length; j++)
            {
                if (goodsArray[i].Price > goodsArray[j].Price)
                {
                    Goods temp = goodsArray[i];
                    goodsArray[i] = goodsArray[j];
                    goodsArray[j] = temp;
                }
            }
        }
    }

    static void PrintGoodsArray(Goods[] goodsArray)
    {
        Console.WriteLine("Артикул | Название | Описание | Цена");
        Console.WriteLine("--------------------------------------");
        foreach (var item in goodsArray)
        {
            item.PrintInfo();
        }
    }
}
