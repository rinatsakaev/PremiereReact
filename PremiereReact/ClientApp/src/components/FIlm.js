import React from 'react';

export default class Film extends React.Component {
    constructor(props) {
        super(props);
        this.inputRef = React.createRef();
    }

    createSession() {
        fetch('/api/session/create', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({Film: {Id: this.props.data.Id}, StartTime: this.inputRef.current.value})
        }).catch((e) => alert(e))
            .then(() => {
                this.props.onAdd();
                this.inputRef.current.value = undefined;
            });
    }

    render() {
        return (<React.Fragment>
            <p>Название: {this.props.data.Name}</p>
            <input type={'datetime-local'} ref={this.inputRef}/>
            <button onClick={() => this.createSession()}>Создать сеанс</button>
        </React.Fragment>)
    }
}
