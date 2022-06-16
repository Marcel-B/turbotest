import { Box, Divider, List, ListItem, Pagination, Paper, Stack, Typography } from "@mui/material";
import React, { SyntheticEvent, useEffect } from "react";
import FeedItem from "./FeedItem";
import { useStore } from "store";
// @ts-ignore
import moment from "moment/min/moment-with-locales";

const Feed = () => {
  const feed = useStore(state => state.feed);
  const fetchFeed = useStore(state => state.fetchFeed);

  useEffect(() => {
    fetchFeed(1, 7).catch(e => console.error(e));
  }, [fetchFeed]);

  const formatValue = (date: Date) => {
    return moment(new Date(date)).locale("de").fromNow();
  };

  return (
    <Box>
      <Typography variant="h4">Feed</Typography>
      <Divider orientation="horizontal" sx={{ mb: 2 }} />

      <Stack
        direction="column"
        divider={<Divider orientation="horizontal" />}
        spacing={2}
        sx={{
          height: "calc(100vh - 190px)"
        }}
      >
        <List
          sx={{
            width: "100%",
            overflow: "auto"
          }}>
          {feed && feed.groupedFeeds && feed.groupedFeeds.length > 0 ? feed.groupedFeeds.map(groupedFeed =>
            <ListItem key={groupedFeed.datum.toString()}>
              <Paper
                sx={{
                  p: 3,
                  m: 0,
                  mb: 2,
                  width: "100%"
                }}>
                <Typography variant="h4">{formatValue(groupedFeed.datum)}</Typography>
                <Divider orientation="horizontal" sx={{
                  mb: 2
                }} />
                {groupedFeed.feedItems.map(feedItem => (
                  <FeedItem
                    key={feedItem.id}
                    aquaType={feedItem.aquaType}
                    item={feedItem.item}
                    datum={moment(new Date(feedItem.item.datum)).locale("de").format("LLLL")}
                    id={feedItem.id} />
                ))}
              </Paper>
            </ListItem>
          ) : <Typography variant="h1">...</Typography>}
        </List>
        {feed && feed.total > 0 && <Pagination
          count={Math.floor(feed.total / 7)}
          onChange={(data: SyntheticEvent<unknown>, page: number) => fetchFeed(page, 7)}
          color="primary" />}
      </Stack>
    </Box>);
};

export default Feed;