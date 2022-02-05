# Taking the Books Challenge
All work for this position is done using _.NET Core 3.1_, _C#_, and _Sql Server_.

# Overview
This exercise is intended to take no longer than 8 hours. Please limit the detail of your solution with that time in mind.  Please include a README with your submission detailing your solution. The solution must be COMPLETE and RUNNABLE.

## Data definition

```C#
// TODO: TBD: how 'fluid' is the definition for challenge purposes
// TODO: TBD: i.e. this is a rough sketch what we will need to think about and are free to ellaborate, refactor, etc?
public class Book
{
    public string Publisher { get; set; }
    public DateTimeOffset AddedOn { get; set; }
    public string Title { get; set; }
    public string AuthorLastName { get; set; }
    public string AuthorFirstName { get; set; }
    public DateTimeOffset PublishedOn { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int StartPage { get; set; }
    public int PageCount { get; set; }
    public decimal TotalPrice => Price * Quantity;
    public int EndPage => StartPage + PageCount - 1;
}
```

## Problem
1. Create a REST API using ASP.NET MVC and write a method to return a sorted list of these by Publisher, Author (last, first), then title.
1. Write another API method to return a sorted list by Author (last, first) then title.
1. If you had to create one or more tables to store the Book data in a MS SQL database, outline the table design along with fields and their datatypes. 
1. Write stored procedures in MS SQL Server for steps 1 and 2, and use them in separate API methods to return the same results.
1. Write an API method to return the total price of all books in the database.
1. If you have a large list of these in memory and want to save the entire list to the MS SQL Server database, what is the most efficient way to save the list with only one call to the DB server?
1. Add a property to the Book class that outputs the MLA ([Modern Language Association](https://images.app.goo.gl/YkFgbSGiPmie9GgWA)) style citation as a string. Please add whatever additional properties the Book class needs to generate the citation.
1. Add another property to generate a Chicago style citation ([Chicago Manual of Style](https://images.app.goo.gl/w3SRpg2ZFsXewdAj7)).

___

## Submission
* Send an [email](mailto:shiva@cascadefintech.com) to your Cascade contact with a link to your solution on your github account when completed.

1. Do not submit a PR. 
1. Do not ask for external assistance. 
1. Do not share solution or assessment with outside sources.
1. Do not reuse previously written code.

## Solutions
1. Presented the database with randomized data for test purposes.
1. Elaborated a little bit on the properties; `AddedOn`, `PublishedOn`, `Quantity`, `StartPage`, `PageCount`, `TotalPrice`, `EndPage`.
1. Corrected issues with the `GetBooksBy` SP invocation, works fantastic.
1. Approached the question of the citation formatting as `IFormatProvider` and `ICustomFormatter` implementations; properly by the `ChicagoBookCitationFormatProvider` and `MlaBookCitationFormatProvider` implementations.
1. Added `TotalPrice` comprehension extending through the _MVC API_.

## Pending
1. Ran out of time this afternoon before my earlier COB commitment, so will have pushed what I have and round out the remaining couple of questions perhaps into the weekend or Monday at the latest.

## Known issues
None at this time.