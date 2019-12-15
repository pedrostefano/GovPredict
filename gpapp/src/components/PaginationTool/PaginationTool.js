import React from "react";
import Pagination from "material-ui-flat-pagination";
import { FormControl, InputLabel, Select, MenuItem } from "@material-ui/core";

import "./PaginationTool.css";

const PaginationTool = props => {
  return (
    <div className="pagination-container">
      <Pagination
        className="pagination-component"
        limit={props.limit}
        offset={props.offset}
        total={props.total}
        onClick={(_e, offset, page) => {
          return props.handlePaginationClick(offset, page);
        }}
      />

      <FormControl className="pagination-limit">
        <InputLabel>Limit</InputLabel>
        <Select
          value={props.limit}
          onChange={e => props.handlePaginationLimitChange(e)}
        >
          <MenuItem value={10}>10</MenuItem>
          <MenuItem value={20}>20</MenuItem>
          <MenuItem value={50}>50</MenuItem>
          <MenuItem value={100}>100</MenuItem>
        </Select>
      </FormControl>
    </div>
  );
};

export default PaginationTool;
