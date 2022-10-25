using System;
 
namespace Bridge
{
  /// <summary>
  /// Класа 'Abstraction'
  /// </summary>
  class Abstraction
  {
    protected Implementor implementor;
 
    // Свойство
    public Implementor Implementor
    {
      set { implementor = value; }
    }
 
    public virtual void Operation()
    {
      implementor.Operation();
    }
  }
 
  /// <summary>
  /// Абстрактен клас'Implementor'
  /// </summary>
  abstract class Implementor
  {
    public abstract void Operation();
  }
 
  /// <summary>
  /// Класа 'RefinedAbstraction'
  /// </summary>
  class RefinedAbstraction : Abstraction
  {
    public override void Operation()
    {
      implementor.Operation();
    }
  }
 
  /// <summary>
  /// Конкретен клас 'ConcreteImplementorA'
  /// </summary>
  class ConcreteImplementorA : Implementor
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteImplementorA Операция");
    }
  }
 
  /// <summary>
  /// Конкретен клас 'ConcreteImplementorВ'
  /// </summary>
  class ConcreteImplementorB : Implementor
  {
    public override void Operation()
    {
      Console.WriteLine("ConcreteImplementorB Операция");
    }
  }
  
  /// <summary>
  /// MainApp е стартиращия клас
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Входна точка на нашето приложение
    /// </summary>
    static void Main()
    {
      Abstraction ab = new RefinedAbstraction();
 
      // Сетва имплементацията и оперира
      ab.Implementor = new ConcreteImplementorA();
      ab.Operation();
 
      // Променя имплементацията и оперира
      ab.Implementor = new ConcreteImplementorB();
      ab.Operation();
 
      // Изчаква потребителя
      Console.ReadKey();
    }
  }
 
}
