import React from 'react';
import Film from '../components/film/film';
import "./index.css";
export default class Home extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            sessions: [],
            films: []
        }
    }

    componentDidMount() {
        this.updateSessionList();
        fetch('/api/film/get')
            .then(x => x.json())
            .then(x => this.setState({films: x}))
            .catch(x => alert(x));
    }

    updateSessionList() {
        fetch('/api/session/get')
            .then(x => x.json())
            .then(x => this.setState({sessions: x}))
            .catch(x => alert(x));
    }

    render() {
        const filmComponents = this.state.films.map(x => <Film filmId={x.Id} name={x.Name} onAdd={() => this.updateSessionList()}/>);
        return <div className={"main"}>
            {filmComponents}
        </div>
    }
}
