import React from 'react';

export default class Film extends React.Component {
    constructor(props) {
        super(props);
        this.setState({id: props.id});
        this.inputRef = React.createRef();
    }

    createSession(){
        fetch('/api/session/create', {
            method: 'POST',
            body: JSON.stringify({id: this.state.id, dateTime: this.inputRef.current.value} )
        }).then(r => console.log(r));
    }

    render() {
        return (<React.Fragment>
            <input type={'datetime'} ref={this.inputRef}/>
            <button onClick={() => this.createSession()}>Создать сеанс</button>
        </React.Fragment>)
    }
}
