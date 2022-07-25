import React from "react";
import PropTypes from "prop-types";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { deleteRoom } from "../../utils/api/rooms.api";
import classes from "./Room.module.scss";

function Room(props) {
  return (
    <div className={classes.Room}>
      <div>
        <div className={classes.Title}>{props.name}</div>
        <div>
          {props.devicesCount} {props.devicesCount === 1 ? "Device" : "Devices"}
        </div>
        <button onClick={() => deleteRoom(props.id).then(alert("Xoá thành công !"))}>Xoá</button>
      </div>
      {props.icon ? (
        <FontAwesomeIcon icon={props.icon} className={classes.Icon} />
      ) : null}
    </div>
  );
}

Room.propTypes = {
  id: PropTypes.string,
  name: PropTypes.string,
  icon: PropTypes.string,
  devicesCount: PropTypes.number
};

export default Room;
