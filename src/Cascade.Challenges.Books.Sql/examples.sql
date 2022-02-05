
-- For purposes of exercising lorem randomized data
-- delete from Books
-- select * from [Books] b

-- All of which appear to work correctly via manager query session
exec GetBooksBy @key = 'auth'
exec GetBooksBy @key = 'pub'
exec GetBooksBy

-- Fixed these, needed to include the argument in the dynamic SQL format
exec sp_executesql N'exec GetBooksBy @key',N'@key varchar(9)',@key='auth'
exec sp_executesql N'exec GetBooksBy @key',N'@key varchar(9)',@key='pub'
exec sp_executesql N'exec GetBooksBy'