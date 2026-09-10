enum BookLoan
{
    Borrowed,
    Returned,
    Overdue,
    Lost
}

struct LoanPeriod
{
    public DateTime BorrowedDate { get; }
    public DateTime DueDate { get; }

    public LoanPeriod(DateTime borrowedDate, DateTime dueDate)
    {
        BorrowedDate = borrowedDate;
        DueDate = dueDate;
    }

    public override string ToString()
    {
        return $"Borrowed Date: {BorrowedDate.ToShortDateString()}, Due Date: {DueDate.ToShortDateString()}";
    }
}

record Loan(string BookTitle, string BorrowerName, LoanPeriod Loaned, BookLoan Status);

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Losman Library!");

        List<Loan> by = new List<Loan>
        {
            new Loan("Good Self, Bad Self", "Losman", new LoanPeriod(DateTime.Now, DateTime.Now.AddDays(14)), BookLoan.Borrowed),
            new Loan("The Great Gatsby", "Itumeleng Modiba", new LoanPeriod(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(4)), BookLoan.Borrowed),
            new Loan("1984", "Shaun Mahlogonolo", new LoanPeriod(DateTime.Now.AddDays(-20), DateTime.Now.AddDays(-5)), BookLoan.Overdue),
            new Loan("To Kill a Mockingbird", "Kim Lee", new LoanPeriod(DateTime.Now.AddDays(-30), DateTime.Now.AddDays(-15)), BookLoan.Lost),
            new Loan("Pride and Prejudice", "Nkholo Bambo", new LoanPeriod(DateTime.Now.AddDays(-5), DateTime.Now.AddDays(9)), BookLoan.Borrowed)
        };

        by.Add(new Loan("Things Fall Apart", "Mike Phiri", new LoanPeriod(DateTime.Now.AddDays(-12), DateTime.Now.AddDays(2)), BookLoan.Returned));
        by.Add(new Loan("Life Of Pi", "Katlego Monama", new LoanPeriod(DateTime.Now.AddDays(-16), DateTime.Now.AddDays(-2)), BookLoan.Overdue));

        foreach (var loan in by)
        {
            Console.WriteLine($"Book Title: {loan.BookTitle}\nBorrower Name: {loan.BorrowerName}\nLoaned Period: {loan.Loaned}\nStatus: {loan.Status}\n");
        }

        DateTime testDate = DateTime.Now.AddDays(4);
        DateTime testDueDate = DateTime.Now.AddDays(10);

        var firstTest = new Loan("My Book", "Losman", new LoanPeriod(testDate, testDueDate), BookLoan.Borrowed);
        var secondTest = new Loan("My Book", "Losman", new LoanPeriod(testDate, testDueDate), BookLoan.Borrowed);

        Console.WriteLine(firstTest == secondTest);

    }
}