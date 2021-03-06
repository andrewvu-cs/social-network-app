import React from "react";
import { Menu, Container, Button } from "semantic-ui-react";
import { observer } from "mobx-react-lite";

import { NavLink } from "react-router-dom";

const NavBar: React.FC = () => {
  return (
    <Menu fixed="top" inverted>
      <Container>
        <Menu.Item header exact as={NavLink} to='/'>
          <img
            src="/assets/logo.png"
            alt="logo"
            style={{ marginRight: "20px" }}
          />
          Droo Hangouts
        </Menu.Item>
        <Menu.Item name="Activities"  as={NavLink} to='/activities' />
        <Menu.Item>
          <Button
            positive
            content="Create Activity"
            as = {NavLink} to='/createActivity'
          ></Button>
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default observer(NavBar);
