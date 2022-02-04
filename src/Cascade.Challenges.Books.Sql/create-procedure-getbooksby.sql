-- Create one single SP which supports AUTH|AUTHOR|PUB|PUBLISHER
create procedure GetBooksBy (
  @key varchar(9) = 'auth'
) as
    if (lower(@key) = 'auth' or lower(@key) = 'author') begin
        select * from [BooksByAuth]
    end
    else if (lower(@key) = 'pub' or lower(@key) = 'publisher') begin
        select * from [BooksByPub]
    end
    else begin
        select * from [Books]
    end
