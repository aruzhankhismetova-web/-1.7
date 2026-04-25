//using System;

//class Person
//{
//    public string Name { get; } 
//    private int _age;

//    public int Age
//    {
//        get => _age;
//        set => _age = (value >= 0 && value <= 120) ? value : throw new ArgumentException("Age must be 0-120");
//    }

//    public Person(string name, int age)
//    {
//        Name = name;
//        Age = age; 
//    }

//    public void Greet() => Console.WriteLine($"Hi, I'm {Name} and I'm {Age} years old.");
//}


//class Program
//{
//    static void Main()
//    {
//        var p = new Person("Alice", 17);
//        p.Greet();

//        try { p.Age = 200; }
//        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
//    }
//}



//class BankAccount
//{
//    public string Owner { get; }

//    public decimal Balance { get; private set; }

//    public BankAccount(string owner, decimal initialDeposit)
//    {
//        if (initialDeposit < 0) throw new ArgumentException("Initial deposit cannot be negative");
//        Owner = owner;
//        Balance = initialDeposit;
//    }

//    public void Deposit(decimal amount)
//    {
//        if (amount <= 0) throw new ArgumentException("Deposit must be positive");
//        Balance += amount;
//    }

//    public void Withdraw(decimal amount)
//    {
//        if (amount <= 0) throw new ArgumentException("Withdrawal must be positive");
//        if (amount > Balance) throw new InvalidOperationException("Insufficient funds");
//        Balance -= amount;
//    }

//    public void PrintStatement() => Console.WriteLine($"{Owner}'s balance: ${Balance}");
//}

//class Program
//{
//    static void Main()
//    {
//        var acc = new BankAccount("John Doe", 100m);
//        acc.Deposit(50m);
//        acc.Withdraw(30m);
//        acc.PrintStatement();


//        try { acc.Withdraw(1000m); }
//        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }



//    }
//}







//240426

//using System.ComponentModel.DataAnnotations;

//Student Aru = new Student { Name = "Nurda", Email = "nurda@mail.com",GPA = 4.01};
//Aru.Greet();

//class Person
//{
//    public string Name { get; set; }
//    public string Email { get; set; }

//    public void Greet() =>
//        Console.WriteLine($"Hi, I'm {Name}.");
//}

//class Student : Person       // Student "is-a" Person
//{
//    public double GPA { get; set; }
//}

//class Teacher : Person       // Teacher "is-a" Person
//{
//    public string Subject { get; set; }
//}



//240426 2
//class Person
//{
//    public string Name { get; set; }

//    public string email { get; set;  }
//    // constructor
//    public Person(string name, string email)
//    {
//        name = name;
//        this.email = email;
//    }
//    public virtual void Greet() =>
//        Console.WriteLine($"Hi, I'm {Name}.");
//}

//class Teacher : Person
//{
//    public string Subject { get; set; }
//    // const suda inherits from person
//    public Teacher(string name, string email, string subject) : base(name, email)
//    {
//        Name = name;
//        this.email = email;
//        Subject = subject;
//    }
//    public override void Greet() =>
//        Console.WriteLine($"Hi, I'm {Name}, I teach {Subject}.");

//    public override void WriteOnEmail()
//    {
//        base.WriteOnEmail();
//    }

//}






//240226 3

//using System;

//class Animal
//{
//    public string Name; 

//    public virtual void Speak()
//    {
//        Console.WriteLine("some sound");
//    }
//}

//class Dog : Animal
//{
//    public override void Speak()
//    {
//        Console.WriteLine(Name + " says: Woof!");
//    }
//}

//class Cat : Animal
//{
//    public override void Speak()
//    {
//        Console.WriteLine(Name + " says: Meow!");
//    }
//}

//class Cow : Animal
//{
//    public override void Speak()
//    {
//        Console.WriteLine(Name + " says: Moo!");
//    }
//}

//class Program
//{
//    static void Main()
//    {

//        Animal[] animals = new Animal[3];

//        animals[0] = new Dog() { Name = "Шарик" };
//        animals[1] = new Cat() { Name = "Мурка" };
//        animals[2] = new Cow() { Name = "Бурёнка" };


//        foreach (Animal a in animals)
//        {
//            a.Speak();
//        }
//    }
//}





using System;

class Student
{
    public string Name;
    public int Grade1;
    public int Grade2;
    public int Grade3;

    public double GetAverage()
    {
        return (Grade1 + Grade2 + Grade3) / 3.0;
    }

    public string GetLetterGrade()
    {
        double avg = GetAverage();
        if (avg >= 90) return "A";
        if (avg >= 75) return "B";
        if (avg >= 60) return "C";
        return "F";
    }

    public void Print()
    {
        Console.WriteLine(Name + " | Average: " + GetAverage() + " | Grade: " + GetLetterGrade());
    }
}

class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal initialDeposit)
    {
        if (initialDeposit < 0) throw new ArgumentException("Negative deposit");
        Owner = owner;
        Balance = initialDeposit;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0) Balance = Balance + amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds");
        if (amount > 0) Balance = Balance - amount;
    }

    public void PrintStatement()
    {
        Console.WriteLine("Owner: " + Owner + " | Balance: " + Balance);
    }
}

class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get { return _celsius; }
        set
        {
            if (value < -273.15) throw new Exception("Error");
            _celsius = value;
        }
    }

    public double Fahrenheit
    {
        get { return _celsius * 9 / 5 + 32; }
        set { Celsius = (value - 32) * 5 / 9; }
    }

    public Temperature(double c)
    {
        Celsius = c;
    }

    public void Print()
    {
        Console.WriteLine(Celsius + "°C / " + Fahrenheit + "°F");
    }
}

class Program
{
    static void Main()
    {
        Student[] roster = new Student[4];
        roster[0] = new Student { Name = "Alice", Grade1 = 95, Grade2 = 88, Grade3 = 92 };
        roster[1] = new Student { Name = "Bob", Grade1 = 70, Grade2 = 65, Grade3 = 80 };
        roster[2] = new Student { Name = "Charlie", Grade1 = 50, Grade2 = 60, Grade3 = 55 };
        roster[3] = new Student { Name = "Diana", Grade1 = 85, Grade2 = 90, Grade3 = 88 };

        for (int i = 0; i < roster.Length; i++)
        {
            roster[i].Print();
        }

        Student best = roster[0];
        for (int i = 1; i < roster.Length; i++)
        {
            if (roster[i].GetAverage() > best.GetAverage()) best = roster[i];
        }
        Console.WriteLine("Best student: " + best.Name);

        Console.WriteLine("----------------------");

        BankAccount acc = new BankAccount("John", 100m);
        acc.Deposit(50m);
        acc.Withdraw(30m);
        acc.PrintStatement();

        try { acc.Withdraw(1000m); } catch (Exception e) { Console.WriteLine(e.Message); }

        Console.WriteLine("----------------------");

        Temperature t = new Temperature(25);
        t.Print();
        t.Fahrenheit = 100;
        t.Print();

        try { t.Celsius = -300; } catch (Exception e) { Console.WriteLine(e.Message); }
    }
}
