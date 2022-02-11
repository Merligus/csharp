using System;
using System.Linq;
using Exercicio1.Entities;
using Exercicio1.Services;
using Exercicio1.Entities.Enums;
using Exercicio1.Entities.Exceptions;
using System.IO;
using System.Globalization;
using System.Text;
using System.Collections.Generic;

namespace Exercicio1
{
    delegate double BinaryNumericOperation(double n1, double n2);

    abstract class Conta
    {
        public double Balance { get; set; }

        public Conta ()
        {

        }

        public Conta(double balance)
        {
            Balance = balance;
        }
    }

    class Poupanca : Conta
    {
        public double Rate { get; set; }

        public Poupanca()
        {

        }

        public Poupanca(double balance, double rate)
            : base(balance)
        {
            Rate = rate;
        }
    }

    struct Ponto
    {
        public double x, y;

        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }

    class Triangulo
    {
        private double _a, _b;
        // auto property
        public double C { private get; set; }
        private double _area;

        public Triangulo()
        {
            _area = -1;
        }

        public Triangulo(double a, double b, double c) : this()
        {
            _a = a;
            _b = b;
            C = c;
        }

        // Properties
        public double A
        {
            get { return _a; }
            set
            {
                if (value >= 0)
                    _a = value;
            }
        }

        public double B
        {
            get { return _b; }
            set
            {
                if (value >= 0)
                    _b = value;
            }
        }

        public double Area()
        {
            if (_area < 0)
            {
                double p = (_a + _b + C) / 2;
                _area = Math.Sqrt(p * (p - _a) * (p - _b) * (p - C));
            }
            return _area;
        }

        public override string ToString()
        {
            return $"Lado A {_a.ToString("F2", CultureInfo.InvariantCulture)}, lado B {_b.ToString("F2", CultureInfo.InvariantCulture)} e lado C {C.ToString("F2", CultureInfo.InvariantCulture)}";
        }
    }

    class Calculadora
    {
        public static double PI = 3.1415926;

        public static double Perimetro(double r)
        {
            return r * 2 * PI;
        }

        public static double Perimetro(double a, double b, double c)
        {
            return a + b + c;
        }

        public static double SomaVet(double[] n)
        {
            double sum = 0;
            for (int i = 0; i < n.Length; i++)
                sum += n[i];
            return sum;
        }

        public static double Soma(params double[] n)
        {
            double sum = 0;
            for (int i = 0; i < n.Length; i++)
                sum += n[i];
            return sum;
        }

        public static void Triplica(ref double a)
        {
            a = 3 * a;
        }

        public static void Triplica(double ao, out double af)
        {
            af = 3 * ao;
        }
    }

    class Produto
    {
        public double price { get; set; }
        public string nome { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //string a = "teste";
            //int b = 0x0A;
            //long c = 100000000L;
            //char d = 'A';
            //char e = '\u0041';
            //float f = 4.5f;
            //double g = 4.37845;
            //object h = 4.5f;
            //object i = "Outro nome";

            // Max value and formatting

            //Console.WriteLine(g.ToString("F2", CultureInfo.InvariantCulture));
            //Console.WriteLine(double.MaxValue);
            //Console.WriteLine(decimal.MaxValue);
            //Console.WriteLine("Maximo valor de decimal é {0} e o g vale {1:F2}", decimal.MaxValue, g);
            //Console.WriteLine($"a: {a} e g: {g:F2}");
            //Console.WriteLine("a: " + a + " e g: " + g.ToString("F2"));


            // Math
            //Console.WriteLine(Math.Pow(2, 4));
            //Console.WriteLine(Math.Sqrt(4));


            // Input and cast
            //string[] frase_vet = Console.ReadLine().Split();
            //Console.WriteLine(frase_vet[0]);
            //Console.WriteLine(frase_vet[1]);
            //Console.WriteLine(frase_vet[2]);
            //int idade = int.Parse(Console.ReadLine());
            //char genero = char.Parse(Console.ReadLine());
            //double n2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //Console.WriteLine(idade);
            //Console.WriteLine(genero);
            //Console.WriteLine(n2.ToString("F2", CultureInfo.InvariantCulture));

            // Função
            //double n1 = 5.7, n2 = 5.6, n3 = 2.5;
            //Console.WriteLine("Maior = " + Maior(n1, n2, n3));

            // Classes e override metodos
            //Triangulo X, Y;
            //X = new Triangulo(2, 2, 3);
            //Y = new Triangulo(3, 3, 2);
            //Console.WriteLine("Triangulo X: " + X);
            //Console.WriteLine("Triangulo Y: " + Y);
            //Console.WriteLine($"Area do X: {X.Area().ToString("F2", CultureInfo.InvariantCulture)}");
            //Console.WriteLine($"Area do Y: {Y.Area().ToString("F2", CultureInfo.InvariantCulture)}");
            //Console.WriteLine("O maior é o " + ((X.Area() > Y.Area()) ? "X" : "Y"));

            // Static methods
            //Console.WriteLine(Calculadora.Perimetro(2));

            // Instanciação, properties e sobrecarga
            //Triangulo t = new Triangulo { A = 2.23, B = 2.4, C = 3 };
            //Triangulo t = new Triangulo();
            //t.A = 2;
            //t.B = 2;
            //t.C = 3;
            //Console.WriteLine(t.Area());
            //Console.WriteLine(Calculadora.Perimetro(2));
            //Console.WriteLine(Calculadora.Perimetro(2, 3, 4));

            // Struct
            //Ponto p;
            //p.x = 2;
            //p.y = 3;
            //Console.WriteLine(p);

            // Nullable
            //double? x = null;
            //double a = x ?? 4; // se nao for null pega x
            //Console.WriteLine(x.GetValueOrDefault());
            //Console.WriteLine(x.HasValue? x.Value : 0);
            //Console.WriteLine(a);

            // Vetor
            //double[] heights = { 2.14, 2.07, 2.00 };
            //Console.WriteLine(Media(heights).ToString("F2", CultureInfo.InvariantCulture));
            //double[] heights = new double[3];
            //for (int i = 0; i < heights.Length; i++)
            //    heights[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //Console.WriteLine(Media(heights).ToString("F2", CultureInfo.InvariantCulture));
            //Produto[] p_v = new Produto[3];
            //for (int i = 0; i < p_v.Length; i++)
            //{
            //    string n;
            //    n = Console.ReadLine();
            //    double p;
            //    p = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //    p_v[i] = new Produto() { nome = n, price = p };
            //}
            //Console.WriteLine(Media(p_v).ToString("F2", CultureInfo.InvariantCulture));

            // params
            //Console.WriteLine(Calculadora.Soma(1, 2, 3));

            // ref e out
            //double a = 3, b;
            //Calculadora.Triplica(ref a);
            //Calculadora.Triplica(a, out b);
            //Console.WriteLine(b);

            // foreach
            //string[] vet = new string[] { "Nome1", "Nome2" };
            //foreach (string s in vet)
            //    Console.WriteLine(s);

            // Lista
            //List<string> list = new List<string>();
            //List<string> list2 = new List<string> { "Nome2", "Nome1" };
            //list.Add("Nome1");
            //list.Add("Nome2");
            //list.Insert(2, "Nome3");
            //list.Add("Nome4");
            //list.Add("AVA");
            //list.Add("BOB");
            //list.RemoveAt(3);
            //string s1 = list.Find(Finder);
            //Console.WriteLine($"Find = {s1}");
            //int i = list.FindIndex(x => x[4] == '2');
            //Console.WriteLine($"FindIndex = {list[i]}");
            //List<string> l = list.FindAll(x => x.Length == 3);
            //foreach (string s in l)
            //    Console.WriteLine($"FindAll = {s}");

            // Matrizes matrix
            //double[,] mat = new double[2, 3];
            //for (int i = 0; i < mat.GetLength(0); i++)
            //{
            //    string[] values = Console.ReadLine().Split(' ');
            //    for (int j = 0; j < mat.GetLength(1); j++)
            //        mat[i, j] = double.Parse(values[j], CultureInfo.InvariantCulture);
            //}
            //foreach (double v in mat)
            //    Console.WriteLine(v);

            // auto em C#
            //var x = new Produto();

            // Switch case
            //int x = 6;
            //string day;
            //switch (x)
            //{
            //    case 1:
            //        day = "Domingo";
            //        break;
            //    case 2:
            //        day = "Segunda";
            //        break;
            //    case 3:
            //        day = "Terça";
            //        break;
            //    case 4:
            //        day = "Quarta";
            //        break;
            //    case 5:
            //        day = "Quinta";
            //        break;
            //    case 6:
            //        day = "Sexta";
            //        break;
            //    default:
            //        day = "Sábado";
            //        break;
            //}
            //Console.WriteLine(day);

            // Strings
            //string original = "abcde FGHIJ ABC abc DEFG    ";
            //string s1 = original.Trim(); // strip em python
            //int index = original.IndexOf("bc"); // ou LastIndexOf
            //string s2 = original.Substring(3, 4); // substr em C++
            //string s3 = original.Replace("abc", "xy");
            //bool empty1 = String.IsNullOrEmpty(original);
            //bool empty2 = String.IsNullOrWhiteSpace(original.Substring(24, 3));
            //Console.WriteLine($"-{s1}-");
            //Console.WriteLine($"bc em {index}");
            //Console.WriteLine($"-{s2}-");
            //Console.WriteLine($"-{s3}-");
            //Console.WriteLine($"-{empty1}-");
            //Console.WriteLine($"-{empty2}-");

            // DateTime
            //DateTime d0 = DateTime.UtcNow;
            //DateTime d1 = DateTime.Now; // Today, UtcNow em Greenwich
            //DateTime d2 = new DateTime(2018, 10, 5);
            //DateTime d3 = new DateTime(2018, 10, 5, 21, 20, 3);
            //DateTime d4 = DateTime.Parse("2000-10-3 13:05:50");
            //DateTime d5 = DateTime.Parse("05/10/2021 13:05:50");
            //DateTime d6 = DateTime.ParseExact("2000-08-12 08:07:06", "yyyy-dd-MM HH:mm:ss", CultureInfo.InvariantCulture);
            //Console.WriteLine(d1); // d1.Ticks
            //Console.WriteLine(d2);
            //Console.WriteLine(d3);
            //Console.WriteLine(d4);
            //Console.WriteLine(d5);
            //Console.WriteLine(d6);
            //Console.WriteLine($"Date: " + d1.DayOfWeek);
            //Console.WriteLine($"Date: " + d1.DayOfYear);
            //string s1 = d1.ToLongDateString();
            //string s2 = d1.ToShortDateString();
            //string s3 = d1.ToString("yyyy-MM-dd HH:mm");
            //Console.WriteLine(s1);
            //Console.WriteLine(s2);
            //Console.WriteLine(s3);
            //DateTime d7 = d1.AddDays(-7);
            //Console.WriteLine(d7);
            //if (d0.Kind == DateTimeKind.Local) // unspecified soma e subtrai pro greenwich
            //    Console.WriteLine(d0.ToUniversalTime());
            //else
            //    Console.WriteLine(d0.ToLocalTime());
            //if (d1.Kind == DateTimeKind.Utc)
            //    Console.WriteLine(d1.ToLocalTime());
            //else
            //    Console.WriteLine(d1.ToUniversalTime());
            //DateTime d2 = DateTime.Parse("2015-08-15T13:05:58Z");
            //Console.WriteLine(d2.ToUniversalTime().ToString("dd/MM/yyTHH:mmZ"));

            // Timespan
            //TimeSpan t1 = new TimeSpan();
            //TimeSpan t2 = new TimeSpan(900000000L);
            //TimeSpan t3 = new TimeSpan(2, 11, 21);
            //TimeSpan t4 = new TimeSpan(1, 2, 11, 21);
            //TimeSpan t5 = new TimeSpan(1, 2, 11, 21, 321);
            //TimeSpan t6 = TimeSpan.FromDays(1.5);
            //TimeSpan t7 = TimeSpan.FromMinutes(1.5);
            //Console.WriteLine(t2);
            //Console.WriteLine(t3);
            //Console.WriteLine(t4);
            //Console.WriteLine(t5);
            //Console.WriteLine(t6);
            //Console.WriteLine(t7);
            //TimeSpan t = d3.Subtract(d2);
            //Console.WriteLine(t);
            //TimeSpan t8 = TimeSpan.MaxValue;
            //TimeSpan t9 = TimeSpan.MinValue;
            //TimeSpan t10 = TimeSpan.Zero;
            //Console.WriteLine(t5.Days);
            //Console.WriteLine(t5.Milliseconds);
            //Console.WriteLine(t5.TotalDays);
            //Console.WriteLine(t5.TotalHours);
            //Console.WriteLine(t3.Add(t4));
            //Console.WriteLine(t4.Subtract(t3));
            //Console.WriteLine(t3.Multiply(2.0));
            //Console.WriteLine(t3.Divide(2.0));

            // Enumeration
            //Order order = new Order
            //{
            //    ID = 1080,
            //    Moment = DateTime.Now,
            //    Status = OrderStatus.PendingPayment
            //};
            //Console.WriteLine(order);
            //string txt = OrderStatus.PendingPayment.ToString();
            //OrderStatus os = Enum.Parse<OrderStatus>("Delivered");
            //Console.WriteLine(os);
            //Console.WriteLine(txt);

            // UML
            //Console.Write("Enter department's name:");
            //string deptName = Console.ReadLine();
            //Console.WriteLine("Enter worker data:");
            //Console.Write("Name:");
            //string name = Console.ReadLine();
            //Console.Write("Level (Junior/MidLevel/Senior):");
            //WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            //Console.Write("Base salary:");
            //double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //Department dept = new Department(deptName);
            //Worker worker = new Worker(name, level, baseSalary, dept);
            //Console.Write("How many contracts:");
            //int n = int.Parse(Console.ReadLine());
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"Enter #{i + 1} contract data:");
            //    Console.Write("Date (DD/MM/YYYY):");
            //    DateTime date = DateTime.Parse(Console.ReadLine());
            //    Console.Write("Value per hour:");
            //    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //    Console.Write("Duration (hours):");
            //    int hours = int.Parse(Console.ReadLine());
            //    HourContract hourContract = new HourContract(date, valuePerHour, hours);
            //    worker.AddContract(hourContract);
            //}

            //Console.WriteLine();
            //Console.Write("Enter month and year to calculate income (MM/YYYY):");
            //string monthYear = Console.ReadLine();
            //int month = int.Parse(monthYear.Substring(0, 2));
            //int year = int.Parse(monthYear.Substring(3, 4));
            //Console.WriteLine($"Name: {worker.Name}");
            //Console.WriteLine($"Department name: {worker.Department.Name}");
            //Console.WriteLine($"Income for {monthYear}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");

            // StringBuilder
            //string Title = "All";
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine(Title);
            //sb.Append(" Likes - ");
            //Console.WriteLine(sb.ToString());

            // Herança
            //BusinessAccount ba = new BusinessAccount(2, "Alex", 450, 100);
            //ba.Loan(100);
            //Console.WriteLine(ba.Balance);
            // casting
            //Account acc = new Account(3, "Pablo", 0.0);
            //BusinessAccount bacc = new BusinessAccount(4, "Maria", 50.0, 500);
            //SavingsAccount sacc = new SavingsAccount(5, "Jordan", 50.0, 0.01);
            //Account acc1 = bacc; // upcasting
            //Account acc2 = sacc; // upcasting
            //BusinessAccount bacc2 = (BusinessAccount)acc1;
            //bacc2.Loan(100);
            //Console.WriteLine(bacc2.Balance);
            //if (acc2 is BusinessAccount) // nao eh busacc
            //{
            //    // BusinessAccount acc3 = (BusinessAccount)acc2;
            //    BusinessAccount acc3 = acc2 as BusinessAccount;
            //    acc3.Loan(50);
            //    Console.WriteLine(acc3.Balance);
            //}
            //else if (acc2 is SavingsAccount)
            //{
            //    SavingsAccount acc3 = (SavingsAccount)acc2;
            //    acc3.UpdateBalance();
            //    Console.WriteLine("Update!");
            //    Console.WriteLine(acc3.Balance);
            //}

            // polymorph
            //virtual/override (sobreposicao)
            //acc1.WithDraw(40);
            //acc2.WithDraw(40);
            //Console.WriteLine(acc1.Balance);
            //Console.WriteLine(acc2.Balance);

            // sealed class (n pode ser herdada)
            // selaed class SavingsAccount
            // public sealed override void Method1()

            // abstract class
            //List<Conta> l = new List<Conta>();
            //l.Add(new Poupanca(100, 0.01));
            //l.Add(new Poupanca(200, 0.02));
            //foreach(Conta c in l)
            //    Console.WriteLine(c.Balance);

            // try catch
            // try except do python
            //try
            //{
            //    int n1 = int.Parse(Console.ReadLine());
            //    int n2 = int.Parse(Console.ReadLine());

            //    Console.WriteLine(n1 / n2);

            //    if (n1 == n2)
            //    {
            //        throw new DomainException("They\'re equal");
            //    }
            //}
            //// catch (Exception e)
            //catch (DivideByZeroException e)
            //{
            //    Console.WriteLine($"Error. 0 division");
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine($"Error. Not formatted");
            //}
            //catch (DomainException e)
            //{
            //    Console.WriteLine($"Error. Equal");
            //}
            //finally
            //{
            //    Console.WriteLine("Executar de qualquer maneira");
            //}

            // File
            // file copy and read
            //string sourcePath = @"C:\temp\Source.txt";
            //string destPath = @"C:\temp\Dest.txt";
            //try
            //{
            //    FileInfo fileInfo = new FileInfo(sourcePath);
            //    // fileInfo.CopyTo(destPath);

            //    string[] lines = File.ReadAllLines(sourcePath);
            //    foreach (string line in lines)
            //        Console.WriteLine(line);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"Error {e.Message}");
            //}

            // file read
            //string path = @"C:\temp\Source.txt";
            //FileStream fs = null;
            //StreamReader sr = null;
            //try
            //{
            //    // opcao 1
            //    //fs = new FileStream(path, FileMode.Open);
            //    //sr = new StreamReader(fs);
            //    // opcao 2
            //    sr = File.OpenText(path);
            //    while (!sr.EndOfStream)
            //    {
            //        string line = sr.ReadLine();
            //        Console.WriteLine(line);
            //    }
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine($"{e.Message}");
            //}
            //finally
            //{
            //    if (sr != null) sr.Close();
            //    if (fs != null) sr.Close();
            //}

            // file read
            // string path = @"C:\temp\Source.txt";
            //try
            //{
            //    // opcao 1
            //    using (StreamReader sr = File.OpenText(path))
            //    {
            //        while (!sr.EndOfStream)
            //        {
            //            string line = sr.ReadLine();
            //            Console.WriteLine(line);
            //        }
            //    }

            //    // opcao 2
            //    using (FileStream fs = new FileStream(path, FileMode.Open))
            //    {
            //        using (StreamReader sr = new StreamReader(fs))
            //        {
            //            while (!sr.EndOfStream)
            //            {
            //                string line = sr.ReadLine();
            //                Console.WriteLine(line);
            //            }
            //        }
            //    }
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            // file write
            //string sourcePath = @"C:\temp\Source.txt";
            //string destPath = @"C:\temp\Dest.txt";
            //try
            //{
            //    string[] lines = File.ReadAllLines(sourcePath);
            //    using (StreamWriter sw = File.AppendText(destPath))
            //    {
            //        foreach (String line in lines)
            //            sw.WriteLine(line.ToUpper());
            //    }
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            // file tree and create
            //string path = @"C:\temp\folder";
            //try
            //{
            //    // list folders
            //    IEnumerable<string> folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
            //    Console.WriteLine("Folders:");
            //    foreach (string s in folders)
            //        Console.WriteLine(s);

            //    // list files
            //    IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
            //    Console.WriteLine("Files:");
            //    foreach (string s in files)
            //        Console.WriteLine(s);

            //    // create folder
            //    Directory.CreateDirectory(path + @"\sub3");
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            // path functions
            //string path = @"C:\temp\folder\Source1.txt";
            //Console.WriteLine($"DirectorySeparatorChar: {Path.DirectorySeparatorChar}");
            //Console.WriteLine($"PathSeparator: {Path.PathSeparator}");
            //Console.WriteLine($"GetDirectoryName: {Path.GetDirectoryName(path)}");
            //Console.WriteLine($"GetFileName: {Path.GetFileName(path)}");
            //Console.WriteLine($"GetExtension: {Path.GetExtension(path)}");
            //Console.WriteLine($"GetFileNameWithoutExtension: {Path.GetFileNameWithoutExtension(path)}");
            //Console.WriteLine($"GetFullPath: {Path.GetFullPath(path)}");
            //Console.WriteLine($"GetTempPath: {Path.GetTempPath()}");

            // interfaces
            //Console.WriteLine("Enter rental data");
            //Console.WriteLine("Car model: ");
            //string model = Console.ReadLine();
            //Console.WriteLine("Pickup (dd/MM/yyyy hh:mm):");
            //DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            //Console.WriteLine("Return(dd/MM/yyyy hh:mm):");
            //DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            //Console.WriteLine("Enter price per hour: ");
            //double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            //Console.WriteLine("Enter price per day: ");
            //double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            //// acoplamento fraco
            //RentalService rental = new RentalService(hour, day, new BrazilTaxService());
            //rental.ProcessInvoice(carRental);
            //Console.WriteLine(carRental.invoice.ToString());

            // sort IComparable e generics (template)
            //List<Employee<double>> emps = new List<Employee<double>>();
            //emps.Add(new Employee<double>("Merli", 1000.0));
            //emps.Add(new Employee<double>("Gustavo", 1000.0));
            //emps.Add(new Employee<double>("Jesus", 800.0));

            //emps.Sort();
            //foreach (Employee<double> e in emps)
            //    Console.WriteLine($"{e.name} {e.salary}");

            // get hash code e equals
            //Client a = new Client() { name = "gustavo", email = "gmail" };
            //Client b = new Client() { name = "merli", email = "gmail" };
            //Console.WriteLine(a.Equals(b));
            //Console.WriteLine(a == b);
            // get hash code:
            //      class => gera por posicao na memoria
            //      struct => gera por conteudo da memoria
            //Console.WriteLine(a.GetHashCode());
            //Console.WriteLine(b.GetHashCode());

            // hash set O(1)
            //HashSet<string> set = new HashSet<string>();
            //set.Add("Tv");
            //set.Add("Mesa");
            //set.Add("Cama");
            //Console.WriteLine(set.Contains("Tva"));
            //foreach (string s in set)
            //    Console.WriteLine(s);
            // sorted O(lg n)
            //SortedSet<int> a = new SortedSet<int>() { 0, 2, 4, 5, 6, 8, 10 };
            //SortedSet<int> b = new SortedSet<int>() { 5, 6, 7, 8, 9, 10 };
            //PrintCollection(a);
            //PrintCollection(b);
            //// union
            //SortedSet<int> c = new SortedSet<int>(a);
            //c.UnionWith(b);
            //PrintCollection(c);
            //// intersection
            //SortedSet<int> d = new SortedSet<int>(a);
            //d.IntersectWith(b);
            //PrintCollection(d);
            //// difference
            //SortedSet<int> e = new SortedSet<int>(a);
            //e.ExceptWith(b);
            //PrintCollection(e);

            // dictionary
            //Dictionary<string, string> dict = new Dictionary<string, string>();
            //dict["user"] = "maria";
            //dict["email"] = "gmail";
            //Console.WriteLine(dict.ContainsKey("user"));
            //// KeyValuePair<string, string> item
            //foreach (string s in dict.Keys)
            //    Console.WriteLine($"{s} : {dict[s]}");

            // extension methods
            //DateTime dt = new DateTime(2022, 2, 5, 8, 10, 45);
            //Console.WriteLine(dt.ElapsedTime());
            //String s1 = "Good morning students";
            //Console.WriteLine(s1.Cut(10));

            // comparison
            //List<Employee<double>> l = new List<Employee<double>>();
            //l.Add(new Employee<double>("Merli", 1250.0));
            //l.Add(new Employee<double>("Merli", 1000.0));
            //l.Add(new Employee<double>("Gustavo", 850.0));
            //// delegate
            //Comparison<Employee<double>> comp1 = CompareEmployee;
            //// lambda para delegate
            //Comparison<Employee<double>> comp2 = (p1, p2) => p1.name.ToUpper().CompareTo(p2.name.ToUpper());
            //l.Sort(comp1);
            //foreach (Employee<double> e in l)
            //    Console.WriteLine(e.name + $" {e.salary}");

            // delegate
            //double a = 10;
            //double b = 12;
            //BinaryNumericOperation op = CalculationService.Sum;
            //// multicast delegate
            //op += CalculationService.Max;
            //op(a, b);

            // predicate
            //List<Employee<double>> l = new List<Employee<double>>();
            //l.Add(new Employee<double>("Merli", 1250.0));
            //l.Add(new Employee<double>("Merli", 1000.0));
            //l.Add(new Employee<double>("Gustavo", 850.0));
            //// lambda
            //// l.RemoveAll(p => p.salary >= 1000.0);
            //// funcao
            //l.RemoveAll(EmplTest);
            //foreach (Employee<double> e in l)
            //    Console.WriteLine(e.name + $" {e.salary}");

            // action
            //List<Employee<double>> l = new List<Employee<double>>();
            //l.Add(new Employee<double>("Merli", 1250.0));
            //l.Add(new Employee<double>("Merli", 1000.0));
            //l.Add(new Employee<double>("Gustavo", 850.0));
            //// opcao 1
            //Action<Employee<double>> act1 = UpdateSalary;
            //l.ForEach(act1);
            //// opcao 2
            //Action<Employee<double>> act2 = e => { e.salary += e.salary * 0.1;  };
            //l.ForEach(act2);
            //// opcao 3
            //l.ForEach(UpdateSalary);
            //foreach (Employee<double> e in l)
            //    Console.WriteLine(e.name + $" {e.salary}");

            // select
            //List<Employee<double>> l = new List<Employee<double>>();
            //l.Add(new Employee<double>("Merli", 1250.0));
            //l.Add(new Employee<double>("Merli", 1000.0));
            //l.Add(new Employee<double>("Gustavo", 850.0));
            //// opcao 1
            //List<string> result1 = l.Select(NameUpper).ToList();
            //// opcao 2
            //Func<Employee<double>, string> func1 = NameUpper;
            //List<string> result2 = l.Select(func1).ToList();
            //// opcao 3 lambda
            //Func<Employee<double>, string> func2 = e => e.name.ToUpper();
            //Func<Employee<double>, string> func3 = e => { return e.name.ToUpper(); };
            //List<string> result3 = l.Select(func3).ToList();
            //foreach (string e in result3)
            //    Console.WriteLine(e);

            // linq (sql)
            //int[] numbers = new int[] { 2, 3, 4, 5 };
            //// def query
            //IEnumerable<int> result = numbers.Where(n => n % 2 == 0).Select(n => n * 10);
            //// exec query
            //foreach(int n in result)
            //    Console.WriteLine(n);

            // sql
            //Category c1 = new Category() { id = 1, name = "tool", tier = 1 };
            //Category c2 = new Category() { id = 2, name = "comp", tier = 2 };
            //Category c3 = new Category() { id = 3, name = "elect", tier = 3 };
            //List<Employee<double>> l = new List<Employee<double>>()
            //{
            //    new Employee<double>() {id = 1, name = "merli", salary = 1000.0, category = c2},
            //    new Employee<double>() {id = 2, name = "gustavo", salary = 1200.0, category = c1},
            //    new Employee<double>() {id = 3, name = "jesus", salary = 1030.0, category = c3},
            //    new Employee<double>() {id = 4, name = "mohammed", salary = 1000.0, category = c2},
            //    new Employee<double>() {id = 5, name = "abda", salary = 2000.0, category = c2},
            //    new Employee<double>() {id = 6, name = "veiga", salary = 3000.0, category = c3},
            //    new Employee<double>() {id = 7, name = "dudu", salary = 1230.0, category = c3},
            //    new Employee<double>() {id = 8, name = "mason", salary = 1480.0, category = c1}
            //};
            //IEnumerable<Employee<double>> result1 = l.Where(e => e.category.tier == 1 && e.salary < 1300.0);
            //var r1 =
            //    from e in l
            //    where e.category.tier == 1 && e.salary < 1300.0
            //    select e;
            //Print("Tier 1 e Salary < 1300: ", r1);
            //IEnumerable<string> result2 = l.Where(e => e.category.name == "tool").Select(e => e.name);
            //var r2 =
            //    from e in l
            //    where e.category.name == "tool"
            //    select e.name;
            //Print("Name of employees from tool: ", r2);
            //var result3 = l.Where(e => e.name[0] == 'm').Select(e => new { e.name, e.salary, CategoryName = e.category.name });
            //var r3 =
            //    from e in l
            //    where e.name[0] == 'm'
            //    select new { e.name, e.salary, CategoryName = e.category.name };
            //Print("Name of employees starting with m: ", r3);
            //var result4 = l.Where(e => e.category.tier == 2).OrderBy(e => e.salary).ThenBy(e => e.name);
            //var r4 =
            //    from e in l
            //    where e.category.tier == 2
            //    orderby e.name
            //    orderby e.salary
            //    select e;
            //Print("Tier 1: ", r4);
            //var result5 = result4.Skip(2).Take(1);
            //var r5 =
            //    (from e in r4
            //     select e).Skip(2).Take(1);
            //Print("Tier 1 skip 2 take 1: ", r5);
            //var result6 = l.FirstOrDefault();
            //var r6 =
            //    (from e in l
            //     select e).FirstOrDefault();
            //Console.WriteLine("First: " + r6);
            //var result7 = l.Where(e => e.salary > 5000.0).FirstOrDefault();
            //Console.WriteLine("First: " + result7);
            //var result8 = l.Where(e => e.id == 25).SingleOrDefault();
            //Console.WriteLine("First: " + result8);
            //var result9 = l.Where(e => e.id == 3).SingleOrDefault();
            //Console.WriteLine("First: " + result9);
            //var result10 = l.Max(e => e.salary);
            //Console.WriteLine("Max: " + result10);
            //var result11 = l.Where(e => e.category.id == 1).Sum(e => e.salary);
            //Console.WriteLine("Category 1 sum: " + result11);
            //var result12 = l.Where(e => e.category.id == 2).Average(e => e.salary);
            //Console.WriteLine("Category 2 average: " + result12);
            //var result13 = l.Where(e => e.category.id == 5).Select(e => e.salary).DefaultIfEmpty().Average();
            //Console.WriteLine("Category 5 average: " + result13);
            //var result14 = l.Where(e => e.category.id == 1).Select(e => e.salary).Aggregate(0.0, (x, y) => x + y);
            //Console.WriteLine("Category 1 aggregate sum: " + result14);
            //var result15 = l.GroupBy(e => e.category);
            //var r15 =
            //    from e in l
            //    group e by e.category;
            //foreach (IGrouping<Category, Employee<double>> group in r15)
            //{
            //    Console.WriteLine($"Category {group.Key.name}: ");
            //    foreach (Employee<double> e in group)
            //        Console.WriteLine("\t" + e);
            //}

        }

        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T c in collection)
                Console.WriteLine(c);
        }

        // select
        static string NameUpper(Employee<double> e)
        {
            return e.name.ToUpper();
        }

        // action
        static void UpdateSalary(Employee<double> e)
        {
            e.salary += e.salary * 0.1;
        }

        // predicate
        public static bool EmplTest(Employee<double> e)
        {
            return e.salary >= 1000.0;
        }

        // delegate
        static int CompareEmployee(Employee<double> e1, Employee<double> e2)
        {
            return e1.name.ToLower().CompareTo(e2.name.ToLower());
        }

        static void PrintCollection<T>(IEnumerable<T> collection) 
        {
            foreach (T obj in collection)
                Console.Write($"{obj} ");
            Console.WriteLine();
        }

        static bool Finder(string s)
        {
            return s[4] == '3';
        }

        static double Media(Produto[] p)
        {
            double sum = 0;
            for (int i = 0; i < p.Length; i++)
                sum += p[i].price;
            return sum / p.Length;
        }

        static double Media(double[] h)
        {
            double sum = 0;
            for (int i = 0; i < h.Length; i++)
                sum += h[i];
            return sum / h.Length;
        }

        double Maior(double n1, double n2, double n3)
        {
            if (n1 > n2 && n1 > n3)
                return n1;
            else if (n2 > n3)
                return n2;
            else
                return n3;
        }
    }
}
