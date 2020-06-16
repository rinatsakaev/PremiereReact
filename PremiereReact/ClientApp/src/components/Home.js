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
            .then(x => this.updateSessionsAndFilms(x))
            .catch(x => alert(x));
    }

    updateSessionsAndFilms(data){
        this.setState({sessions: data});
        const films = data.map(x => x.Film);
        this.setState({films: films});
    }

    render() {
        const sessions = this.state.sessions.map(x => <div>
            <p>Название фильма: {x.Name}</p>
            <p>Время начала: {x.StartTime}</p>
        </div>);
        const filmComponents = this.state.films.map(x => <Film props={x}/>);
        return <React.Fragment>
            {filmComponents}
        
            {sessions.length?sessions:<p>No sessions</p>}
        </React.Fragment>
    }
}
