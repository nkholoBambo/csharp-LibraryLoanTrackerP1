# csharp-LibraryLoanTrackerP1
Console application made using C# enum, struct and record, it also includes DateTime to actually track how long a book has been out of the library

Losman Library Loan Tracker
A second enum/struct/record project, built independently (without IntelliSense) to reinforce concepts from the Order Processing System.

What it does:
-Defines a BookLoan enum for loan status (Borrowed, Returned, Overdue, Lost)
-Defines a LoanPeriod struct combining a borrowed date and due date, with a custom ToString() override for readable output
-Defines a Loan record combining a book title, borrower name, the LoanPeriod struct, and the BookLoan status
-Stores and prints a list of loans with realistic sample data
-Demonstrates record value-equality using two independently created Loan objects with identical data

Tech used
-C#
-.NET Console Application
-How to run:
   1. Clone this repo
   2. Navigate to the project folder
   3. Run:
      dotnet run

Concepts practiced:
-enum, struct, and record used together
-Custom ToString() override on a struct for meaningful output
-Record value-equality (== compares contents, not object identity)

Bug found and fixed during development:
An initial equality test compared two Loan records built from separate DateTime.Now calls and unexpectedly returned false. The cause: DateTime.Now captures the exact moment down to fractions of a millisecond, so two separate calls — even on consecutive lines — almost never produce identical values. Since record equality compares every field's actual value, the two LoanPeriod structs were genuinely different by a tiny margin. Fixed by capturing the date into a variable once and reusing it for both test objects, which correctly returns true.
