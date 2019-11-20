import React from "react";
import { Segment, Form, Button } from "semantic-ui-react";

interface IProps {
  setEditMode: (EditMode: boolean) => void;
}

export const ActivityForm: React.FC<IProps> = ({ setEditMode }) => {
  return (
    <Segment clearing>
      <Form>
        <Form.Input placeholder="Title" />
        <Form.TextArea rows={2} placeholder="Description" />
        <Form.Input placeholder="Category" />
        <Form.Input type="date" placeholder="Date" />
        <Form.Input placeholder="City" />
        <Form.Input placeholder="Venue" />
        <Button
          onClick={() => setEditMode(false)}
          floated="right"
          type="submit"
          content="Cancel"
        />
        <Button floated="right" positive type="submit" content="Submit" />
      </Form>
    </Segment>
  );
};