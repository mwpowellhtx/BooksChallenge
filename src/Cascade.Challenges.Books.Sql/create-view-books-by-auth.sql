-- need to use the 'offset' portion supporting the ORDER BY clause
-- https://stackoverflow.com/questions/5945851/sql-error-the-order-by-clause-is-invalid-in-views
create view [BooksByAuth] as
    select *
    from [Books] b
    order by b.[AuthorLastName], b.[AuthorFirstName], b.[Title] offset 0 rows
