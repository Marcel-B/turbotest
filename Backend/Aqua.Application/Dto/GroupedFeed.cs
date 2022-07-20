using com.marcelbenders.Aqua.Domain.Sql;

namespace com.marcelbenders.Aqua.Application.Dto;

public record GroupedFeed(DateTimeOffset Datum, IEnumerable<IFeedItem> FeedItems);