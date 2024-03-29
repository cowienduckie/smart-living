import React, { Component } from "react";
import PropTypes from "prop-types";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

import classes from "./ModeControl.module.scss";
import { changeMode, changeVane, changeFan } from "../../../../utils/api/rooms.api";

export default class ModeControl extends Component {
  static propTypes = {
    deviceID: PropTypes.string,
    controlId: PropTypes.string,
    name: PropTypes.string,
    value: PropTypes.string,
    onUpdateValue: PropTypes.func,
    options: PropTypes.object
  };

  onChangeModeHandler = event => {
    const updatedValue = event.target.value;
    if (updatedValue !== this.props.value) {
      this.props.onUpdateValue(this.props.controlId, updatedValue);
      if (this.props.name == "Mode") { changeMode(this.props.controlId, this.props.deviceId, updatedValue).then() }
      else if (this.props.name == "Vane") changeVane(this.props.controlId, this.props.deviceId, updatedValue).then()
      else if (this.props.name == "Intensity") changeFan(this.props.controlId, this.props.deviceId, updatedValue).then()

    }
  };


  render() {
    if (!this.props.options) return null;

    const options = Object.entries(this.props.options).map(optionData => {
      const openKey = optionData[0];
      const option = optionData[1];

      const isChecked = this.props.value === openKey;
      const radioId = `${this.props.controlId}-${openKey}`;

      return (
        <div className={classes.ModeControl} key={openKey}>
          <input
            type="radio"
            id={radioId}
            value={openKey}
            className={classes.Radio}
            checked={isChecked}
            onChange={this.onChangeModeHandler}
          />
          <label htmlFor={radioId} className={classes.Label}>
            {option.icon ? (
              <FontAwesomeIcon icon={{ prefix: "fa", iconName: option.icon }} className={classes.Icon} />
            ) : (
              <span className={classes.OptionText}>{option.name}</span>
            )}
          </label>
        </div>
      );
    });
    return <div className={classes.ModeControlContainer}>{options}</div>;
  }
}
