import GroupedFeed from "./groupedFeed";

export interface Feed {
  total: number;
  groupedFeeds: GroupedFeed[];
}

export default Feed;