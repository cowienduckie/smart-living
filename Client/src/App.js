import React from "react";
import { Route, Switch } from "react-router-dom";

import "./App.module.scss";
import Layout from "./hoc/Layout/Layout";
import RoomsDashboard from "./containers/RoomsDashboard/RoomsDashboard";
import asyncComponent from "./hoc/asyncComponent/asyncComponent";
import AddRoom from "./containers/AddRoom/AddRoom";
import AddDevice from "./containers/AddDevice/AddDevice";

function App() {
  const AsyncRoomsDevices = asyncComponent(() =>
    import("./containers/RoomsDashboard/RoomDevices/RoomDevices")
  );

  return (
    <Layout>
      <Switch>
        <Route path="/room/:id" exact component={AsyncRoomsDevices} />
        <Route path="/" exact component={RoomsDashboard} />
        <Route path="/add-room" exact component={AddRoom} />
        <Route path="/add-device" exact component={AddDevice} />
      </Switch>
    </Layout>
  );
}

export default App;
