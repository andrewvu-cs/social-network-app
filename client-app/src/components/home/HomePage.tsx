import React from 'react'
import { Container, Segment, Header, Button, Image } from 'semantic-ui-react'
import { Link } from 'react-router-dom'

const HomePage = () => {
    return (
           <Segment inverted textAlign='center' vertical className='masthead' >
               <Container text>
                   <Header as='h1' inverted>
                       <Image size='massive' src='/assets/logo.png' alt='logo' style={{marginBottom: 12}}/>
                       Droo-Hangouts
                   </Header>
                   <Header as='h2' inverted content='Lets go hangout somewhere' />
                   <Button as={Link} to='/activities' size='huge' inverted>
                       To Hangouts!
                   </Button>
               </Container>
           </Segment>
    )
}

export default HomePage;
