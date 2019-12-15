import React from "react";
import {
  Button,
  Chip,
  FormControl,
  Input,
  InputLabel,
  MenuItem,
  Select,
  TextField
} from "@material-ui/core";
import {
  MuiPickersUtilsProvider,
  KeyboardDatePicker
} from "@material-ui/pickers";
import DateFnsUtils from "@date-io/date-fns";

import "./Filters.css";

const Filters = props => {
  return (
    <div className="Filters">
      {/* LISTS */}
      <FormControl className="filter formcontrol" style={{ minWidth: 200 }}>
        <InputLabel>Lists</InputLabel>
        <Select
          multiple
          value={props.filter.lists}
          onChange={e => props.handleChangeLists(e)}
          input={<Input />}
          renderValue={selected => (
            <div className="chips">
              {selected.map(value => (
                <Chip key={value} label={value} className="chip" />
              ))}
            </div>
          )}
        >
          {props.options.lists.map(name => (
            <MenuItem key={name} value={name}>
              {name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>

      {/* SOCIAL NETWORKS */}
      <FormControl className="filter formControl" style={{ minWidth: 200 }}>
        <InputLabel>Social Networks</InputLabel>
        <Select
          id="scs-select"
          multiple
          value={props.filter.socialNetworks}
          onChange={e => props.handleChangeSocialNetworks(e)}
          input={<Input />}
          renderValue={selected => (
            <div className="chips">
              {selected.map(value => (
                <Chip key={value} label={value} className="chip" />
              ))}
            </div>
          )}
        >
          {props.options.socialNetworks.map(name => (
            <MenuItem key={name} value={name}>
              {name}
            </MenuItem>
          ))}
        </Select>
      </FormControl>

        {/* InitialData */}
        <MuiPickersUtilsProvider utils={DateFnsUtils}>
        <KeyboardDatePicker
          className="filter"
          disableToolbar
          variant="inline"
          format="MM/dd/yyyy"
          margin="normal"
          label="Initial Date"
          value={props.filter.initialDate}
          onChange={e => props.handleInitialDateChange(e)}
          KeyboardButtonProps={{
            "aria-label": "change date"
          }}
        />

        {/* FinalData */}
        <KeyboardDatePicker
          className="filter"
          disableToolbar
          variant="inline"
          format="MM/dd/yyyy"
          margin="normal"
          label="Final Date"
          value={props.filter.finalDate}
          onChange={e => props.handleFinalDateChange(e)}
          KeyboardButtonProps={{
            "aria-label": "change date"
          }}
        />
      </MuiPickersUtilsProvider>

      {/* Content */}
      <TextField
        className="filter"
        label="Search Content"
        value={props.filter.content}
        onChange={e => props.handleChangeContent(e)}
      />
      <Button
        variant="contained"
        color="primary"
        className="filter"
        onClick={() => props.getFilteredPosts()}
      >
        Search
      </Button>
    </div>
  );
};

export default Filters;
