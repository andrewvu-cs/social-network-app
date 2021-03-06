import React, {  Fragment } from "react";
import { observer } from "mobx-react-lite";
import { Route, withRouter, RouteComponentProps } from "react-router-dom";
import { Container } from "semantic-ui-react";
import "./styles.css";
import NavBar from "../../components/NavBar";
import ActivityDashboard from "../../components/activities/dashboard/ActivityDashboard";

import HomePage from "../../components/home/HomePage";
import ActivityForm from "../../components/activities/form/ActivityForm";
import ActivityDetails from "../../components/activities/details/ActivityDetails";

const App: React.FC<RouteComponentProps> = ({ location }) => {

  return (
    <Fragment>
      <Route exact path="/" component={HomePage}></Route>
      {/* If we have anything else after the initial then render everything else */}
      <Route
        path={"/(.+)"}
        render={() => (
          <Fragment>
            <NavBar />
            <Container style={{ marginTop: "7em" }}>
              <Route
                exact
                path="/activities"
                component={ActivityDashboard}
              ></Route>
              <Route path="/activities/:id" component={ActivityDetails}></Route>
              <Route
                key={location.key}
                path={["/createActivity", "/manage/:id"]}
                component={ActivityForm}
              ></Route>
            </Container>
          </Fragment>
        )}
      />
    </Fragment>
  );
};

export default withRouter(observer(App));
