import React, { useState, useEffect, Fragment } from "react";
import { Header, Icon, List, Container } from "semantic-ui-react";
import "./styles.css";
import axios from "axios";

import { IActivity } from "../models/activity";
import { NavBar } from "../../components/NavBar";
import { ActivityDashboard } from "../../components/activities/dashboard/ActivityDashboard";

const App = () => {
  const [activities, setActivities] = useState<IActivity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<IActivity | null>(
    null
  );

  const handleSelectActivity = (id: string) => {
    setSelectedActivity(activities.filter(a => a.id === id)[0]);
  };
  // the 2nd param [], ensures that our effect only runs once and not every render
  // componentDiDMount equivalent
  useEffect(() => {
    axios
      .get<IActivity[]>("http://localhost:5000/api/activities")
      .then(response => {
        console.log(response);
        setActivities(response.data);
      });
  }, []);

  return (
    <Fragment>
      <NavBar />
      <Container style={{ marginTop: "7em" }}>
        <ActivityDashboard
          activities={activities}
          selectActivity={handleSelectActivity}
          selectedActivity={selectedActivity}
        />
      </Container>
    </Fragment>
  );
};

export default App;
