


using System;

class Goods
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
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
        Console.WriteLine($"Артикул: {Article}, Название: {Name}, Описание: {Description}, Цена: {Price}");
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
}

class Program
{
    static void Main()
    {
        Goods[] goodsArray = new Goods[5]
        {
            new Goods("Товар 1", 150.00m),
            new Goods("Товар 2", 270.00m),
            new Goods("Товар 3", 90.00m),
            new Goods("Товар 4", 230.00m),
            new Goods("Товар 5", 110.00m)
        };

        goodsArray[0].ChangeDescription("описание товара 1, которое болоьше или 20 символов.");
        goodsArray[2].ChangeDescription("описание товара 3 с изменениями и достаточной длиной.");
        goodsArray[4].ChangeDescription("это описание товара 5, я не знаю, что сюда написать.");

      
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

    
        Console.WriteLine("Артикул | Название | Описание | Цена");
        Console.WriteLine("--------------------------------------");
        foreach (var item in goodsArray)
        {
            item.PrintInfo();
        }
    }
}








