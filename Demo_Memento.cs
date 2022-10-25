using System;
 
namespace Memento
{
  /// <summary>
  /// Класа 'Originator'
  /// </summary>
  class Originator
  {
    private string _state;
 
    // Свойство
    public string State
    {
      get { return _state; }
      set
      {
        _state = value;
        Console.WriteLine("Състояние = " + _state);
      }
    }
 
    // Създава спомен
    public Memento CreateMemento()
    {
      return (new Memento(_state));
    }
 
    // Връща оригиналното състояние
    public void SetMemento(Memento memento)
    {
      Console.WriteLine("Връщане оригиналното състояние...");
      State = memento.State;
    }
  }
 
  /// <summary>
  /// Класа 'Memento'
  /// </summary>
  class Memento
  {
    private string _state;
 
    // Конструктор
    public Memento(string state)
    {
      this._state = state;
    }
 
    // Gets или sets на състоянието
    public string State
    {
      get { return _state; }
    }
  }
 
  /// <summary>
  /// класа 'Caretaker'
  /// </summary>
  class Caretaker
  {
    private Memento _memento;
 
    // Gets или sets на спомена
    public Memento Memento
    {
      set { _memento = value; }
      get { return _memento; }
    }
  }
  
  /// <summary>
  /// MainApp стартиращия клас
  /// </summary>
  class MainApp
  {
    /// <summary>
    /// Входна точка на приложението
    /// </summary>
    static void Main()
    {
      Originator o = new Originator();
      o.State = "Включено";
 
      // Променя вътрешното състояние
      Caretaker c = new Caretaker();
      c.Memento = o.CreateMemento();
 
      // Продължава да променя оригинала
      o.State = "Изключено";
 
      // Връща предишното състояние
      o.SetMemento(c.Memento);
 
      // Изчаква потребителя
      Console.ReadKey();
    }
  }
}
