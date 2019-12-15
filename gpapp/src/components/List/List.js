import React from 'react';
import {Paper} from '@material-ui/core';

import './List.css';

const List = (props) => {
  const list = props.posts.map((e, i) => (
    <Paper key={i} className="card">{e.account}</Paper>
  ))

  return ( 
    <div className="list"> 
      {list}
    </div>
   );
}
 
export default List;