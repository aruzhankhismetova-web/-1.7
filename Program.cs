//Console.WriteLine("l");

//class Student
//{
//    public string Name;
//    public int Grade1, Grade2, Grade3;


//    public Student(string name, int g1, int g2, int g3)
//    {
//        Name = name;
//        Grade1 = g1;
//        Grade2 = g2;
//        Grade3 = g3;
//    }

//}



using System;

class Student
{
    public string Name;
    public int G1, G2, G3;

    public Student(string n, int g1, int g2, int g3)
    {
        Name = n;
        G1 = g1; 
        G2 = g2; 
        G3 = g3;
    }

    public double GetAverage() => (G1 + G2 + G3) / 3.0;

    public string GetLetterGrade()
    {
        double a = GetAverage();
        if (a >= 90) return "A";
        if (a >= 75) return "B";
        if (a >= 60) return "C";
        return "F";
    }

    public void Print() =>
        Console.WriteLine($"{Name} | Avg: {GetAverage():F1} | Grade: {GetLetterGrade()}");
}

class BankAccount
{
    public string Owner { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string owner, decimal deposit)
    {
        Owner = owner;
        if (deposit >= 0) Balance = deposit;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0) Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance) throw new InvalidOperationException("Insufficient funds");
        if (amount > 0) Balance -= amount;
    }

    public void PrintStatement() => Console.WriteLine($"{Owner}: ${Balance}");
}

class Program
{
    static void Main()
    {
        
        Student[] roster = {
            new Student("Alice", 95, 88, 92),
            new Student("Bob", 70, 75, 80),
            new Student("Charlie", 60, 55, 62),
            new Student("Diana", 85, 90, 88)
        };

        foreach (var s in roster) s.Print();

        Student best = roster[0];
        foreach (var s in roster)
        {
            if (s.GetAverage() > best.GetAverage()) best = s;
        }
        Console.WriteLine("Best student: " + best.Name + "\n");

        BankAccount acc = new BankAccount("John", 100m);
        acc.Deposit(50m);
        acc.Withdraw(30m);
        acc.PrintStatement();

        

        try
        {
            acc.Withdraw(1000m);
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}
