import React from "react";
import { Menu, Container, Button } from "semantic-ui-react";

export const NavBar = () => {
  return (
    <Menu fixed="top" inverted>
      <Container>
          <Menu.Item header>
              <img src="/assets/logo.png" alt="logo" />
              Droo Hangouts
          </Menu.Item>
        <Menu.Item name="Activities" />
        <Menu.Item >
            <Button positive content="Create Activity"></Button>
        </Menu.Item>
        <Menu.Item name="friends" />
      </Container>
    </Menu>
  );
};
