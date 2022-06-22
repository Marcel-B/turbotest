import FeedItem from "./feedItem";

export interface GroupedFeed {
  datum: Date;
  feedItems: FeedItem[];
}

export default GroupedFeed;