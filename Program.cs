using System;

class Student
{
    public string Name;
    public int Grade1;
    public int Grade2;
    public int Grade3;

    
    public Student(string name, int g1, int g2, int g3)
    {
        Name = name;
        Grade1 = g1;
        Grade2 = g2;
        Grade3 = g3;
    }

    public double GetAverage()
    {
        return (Grade1 + Grade2 + Grade3) / 3.0;
    }

    public string GetLetterGrade()
    {
        double avg = GetAverage();

        if (avg >= 90) return "A";
        else if (avg >= 75) return "B";
        else if (avg >= 60) return "C";
        else return "F";
    }

    public void Print()
    {
        Console.WriteLine($"{Name} | Avg: {GetAverage():F2} | Grade: {GetLetterGrade()}");
    }
}

class Program
{
    static void Main()
    {
        
        Student[] roster = new Student[4]
        {
            new Student("Kaussar", 96, 90, 92),
            new Student("Max", 70, 75, 72),
            new Student("Arman", 60, 65, 58),
            new Student("Korkem", 85, 90, 87)
        };

       
        Console.WriteLine("Student List:");
        foreach (Student s in roster)
        {
            s.Print();
        }

        
        Student best = roster[0];

        foreach (Student s in roster)
        {
            if (s.GetAverage() > best.GetAverage())
            {
                best = s;
            }
        }

        
        Console.WriteLine("\nTop Student:");
        best.Print();
    }
}