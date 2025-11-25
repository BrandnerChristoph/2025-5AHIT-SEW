// Client

using DesignPatternAdapter;

Console.WriteLine("Adapter Example");
float inputVal = 3.1415f;
ICalculator calculator = new CalculatorMultiplication();

//Console.WriteLine(calculator.CalculateValue(inputVal).ToString());  // Fehler, da kein korrekter Typ übergeben wird (int / float)

Target t = new Adapter(calculator);
Console.WriteLine(t.CalculateValue(inputVal));
