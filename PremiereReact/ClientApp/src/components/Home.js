import React from 'react';
import Film from './FIlm';

export default class Home extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            sessions: [],
            films: []
        }
    }
    componentDidMount() {
        fetch('/api/session/get')
            .then(x => x.json())
            .then(x =>  this.setState({sessions: x}))
            .catch(x => alert(x));
        fetch('/api/film/get')
            .then(x => x.json())
            .then(x => this.setState({films: x}))
            .catch(x => alert(x));
    }

    render() {
        const sessions = this.state.sessions.map(x => <div>
            <p>Название фильма: {x.Film.Name}</p>
            <p>Время начала: {x.StartTime}</p>
        </div>);
        const filmComponents = this.state.films.map(x => <Film data={x}/>);
        return <React.Fragment>
            <div>
            {filmComponents}
            </div>
        
            {sessions.length?sessions:<p>No sessions</p>}
        </React.Fragment>
    }
}
