import React from "react";
import { Paper } from "@material-ui/core";
import LinkIcon from "@material-ui/icons/Link";
import FacebookIcon from "@material-ui/icons/Facebook";
import TwitterIcon from "@material-ui/icons/Twitter";
import WebIcon from "@material-ui/icons/Web";

import "./List.css";

const List = props => {
  const list = props.posts.map((e, i) => (
    <Paper key={i} elevation={3} className="card">
      <div className="header">
        <div className="item">
          {(() => {
            switch (e.socialNetwork) {
              case "Facebook":
                return <FacebookIcon />;
              case "Twitter":
                return <TwitterIcon />;
              default:
                return <WebIcon />;
            }
          })()}
        </div>

        <div className="item">
          <h4>{e.account}</h4>
        </div>
      </div>

      <div className="content item">
        <p>{e.content}</p>
      </div>

      <div className="footer">
        <div className="item lists">
          {e.lists.map(li => (
            <div key={li}>{li}</div>
          ))}
        </div>

        <div className="item">{new Date(e.date).toLocaleDateString()}</div>

        <div className="item">
          <a href={e.link}>
            <LinkIcon />
          </a>
        </div>
      </div>
    </Paper>
  ));

  return <div className="list">{list}</div>;
};

export default List;
