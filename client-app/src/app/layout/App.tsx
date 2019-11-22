import React, {
  useEffect,
  Fragment,
  useContext
} from "react";
import { observer } from "mobx-react-lite";
import { Route } from "react-router-dom";
import { Container } from "semantic-ui-react";
import "./styles.css";
import NavBar from "../../components/NavBar";
import ActivityDashboard from "../../components/activities/dashboard/ActivityDashboard";
import { LoadingComponent } from "./LoadingComponent";
import ActivityStore from "../stores/activityStore";
import HomePage from "../../components/home/HomePage";
import ActivityForm from "../../components/activities/form/ActivityForm";

const App = () => {
  const activityStore = useContext(ActivityStore);

  // the 2nd param [], ensures that our effect only runs once and not every render
  // componentDiDMount equivalent
  useEffect(() => {
    activityStore.loadActivities();
  }, [activityStore]);

  if (activityStore.loadingInitial)
    return <LoadingComponent content="Loading activities..." />;

  return (
    <Fragment>
      <NavBar />
      <Container style={{ marginTop: "7em" }}>
        <Route exact path='/' component={HomePage}></Route>
        <Route path='/activities' component={ActivityDashboard}></Route>
        <Route path='/createActivity' component={ActivityForm}></Route>
      </Container>
    </Fragment>
  );
};

export default observer(App);
