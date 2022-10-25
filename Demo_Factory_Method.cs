using System;
 
namespace FactoryMethod
{
  /// <summary>
  /// Абстрактен клас 'Product'
  /// </summary>
  abstract class Product
  {
  }
 
  /// <summary>
  /// Конкретен клас 'ConcreteProductА'
  /// </summary>
  class ConcreteProductA : Product
  {
  }
 
  /// <summary>
  /// Конкретен клас 'ConcreteProductВ'
  /// </summary>
  class ConcreteProductB : Product
  {
  }
 
  /// <summary>
  /// Абстрактен клас 'Creator'
  /// </summary>
  abstract class Creator
  {
    public abstract Product FactoryMethod();
  }
 
  /// <summary>
  /// Конкретен клас 'ConcreteCreatorА'
  /// </summary>
  class ConcreteCreatorA : Creator
  {
    public override Product FactoryMethod()
    {
      return new ConcreteProductA();
    }
  }
 
  /// <summary>
  /// Конкретен клас 'ConcreteCreatorВ'
  /// </summary>
  class ConcreteCreatorB : Creator
  {
    public override Product FactoryMethod()
    {
      return new ConcreteProductB();
    }
  }
  
  /// <summary>
  /// MainApp Стартиращия клас
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Входна точка на нашето приложение
    /// </summary>
    static void Main()
    {
      // Масив от създатели
      Creator[] creators = new Creator[2];
 
      creators[0] = new ConcreteCreatorA();
      creators[1] = new ConcreteCreatorB();
 
      // Итерираме през създателите и създаваме съответния продукт
      foreach (Creator creator in creators)
      {
        Product product = creator.FactoryMethod();
        Console.WriteLine("Created {0}",
          product.GetType().Name);
      }
 
      // Изчакване на потребителя
      Console.ReadKey();
    }
  }
 
}
