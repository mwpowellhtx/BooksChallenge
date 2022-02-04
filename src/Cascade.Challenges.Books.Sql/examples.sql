
-- For purposes of exercising lorem randomized data
-- delete from Books
-- select * from [Books] b

-- All of which appear to work correctly via manager query session
exec GetBooksBy @key = 'auth'
exec GetBooksBy @key = 'pub'
exec GetBooksBy @key = 'auth'

-- 'None' of these appear to work correctly, I'm not sure (yet) why the arguments are not relayed correctly
-- The 'auth' use case only appears to work correctly because it also happens to be the @key default value in the SP itself
exec sp_executesql N'exec GetBooksBy',N'@key varchar(9)',@key='auth'
exec sp_executesql N'exec GetBooksBy',N'@key varchar(9)',@key='pub'
exec sp_executesql N'exec GetBooksBy'