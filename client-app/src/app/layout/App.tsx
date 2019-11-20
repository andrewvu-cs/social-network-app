import React, { useState, useEffect } from "react";
import { Header, Icon, List } from "semantic-ui-react";
import "./styles.css";
import axios from "axios";
import { IActivity } from "../models/activity";
import { NavBar } from "../../components/NavBar";

const App = () => {
  const [activities, setActivities] = useState<IActivity[]>([]);

  // the 2nd param [], ensures that our effect only runs once and not every render
  // componentDiDMount equivalent
  useEffect(() => {
    axios
      .get<IActivity[]>("http://localhost:5000/api/activities")
      .then(response => {
        console.log(response);
        setActivities(response.data)
      });
  },[]);
 

  return (
    <div>
      <NavBar />
      <List>
        {activities.map(activity => (
          <List.Item key={activity.id}>{activity.title}</List.Item>
        ))}
      </List>
    </div>
  );
};

export default App;
