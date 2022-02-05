create table [Books] (
  -- for performance reasons not using a NEWSEQUENTIALID() or a COMB method
  [BookID] uniqueidentifier not null default newid()
  -- time stamp when a Book was introduced to the system
  , [AddedOn] datetimeoffset not null default getdate()
  , [Publisher] varchar(512) not null
  , [Title] varchar(512) not null
  , [PublishedOn] datetimeoffset not null
  , [AuthorFirstName] varchar(128) not null
  , [AuthorLastName] varchar(128) not null
  , [Price] decimal not null default 0
  , [Quantity] int not null default 0
  , [StartPage] int not null default 1
  , [PageCount] int not null default 1
  , constraint [PriceLowerBound] check ([Price] >= 0)
  , constraint [QuantityLowerBound] check ([Quantity] >= 0)
  , constraint [StartPageLowerBound] check ([StartPage] > 0)
  , constraint [PageCountLowerBound] check ([PageCount] > 0)
)

/*
-- -- TODO: TBD: could add things like Container Title/Issue, Series Title, etc...
-- -- TODO: TBD: and for that matter, normalizing publisher, authors, etc, to separate tables...
-- -- TODO: TBD: but for academic, demo, example purposes, keeping it simpler, straightforward
-- public string Publisher { get; set; }
-- public string Title { get; set; }
-- public string AuthorLastName { get; set; }
-- public string AuthorFirstName { get; set; }
-- public DateTimeOffset PublishedOn { get; set; }
-- public decimal Price { get; set; }
-- public int Quantity { get; set; }
-- public int StartPage { get; set; }
-- public int PageCount { get; set; }
*/
