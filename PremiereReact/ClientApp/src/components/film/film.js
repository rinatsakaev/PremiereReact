import React, {useEffect, useState} from 'react';
import './index.css';
import Session from '../session/session';

export default function Film({onAdd, filmId, name}) {
    const [sessionDate, setSessionDate] = useState(undefined);
    const [existingSessions, setExistingSessions] = useState([]);
    const createSession = () => {
        fetch('/api/session/create', {
            method: 'POST',
            headers: {
                'Content-type': 'application/json'
            },
            body: JSON.stringify({Film: {Id: filmId}, StartTime: sessionDate})
        })
            .then(fetchSessions)
            .catch(e => console.log("Create session error", e));
    };

    const onSessionDateChanged = (e) => {
        setSessionDate(e.target.value);
    };

    const onSessionDeleted = (sessionId) => {
        fetch(`/api/session/delete/${sessionId}`)
            .then(fetchSessions)
            .catch(e => console.log("Delete session error", e))
    };

    const fetchSessions = () => {
        fetch(`/api/session/getByFilmId/${filmId}`)
            .then(x => x.json())
            .then(x => setExistingSessions(x))
            .catch(e => console.log("Fetch sessions error", e));
    };

    useEffect(() => {
        fetchSessions();
    }, []);

    const sessionsComponents = existingSessions.map(x =>
        <li><Session sessionId={x.Id}
                     startTime={x.StartTime}
                     onDelete={() => onSessionDeleted(x.Id)}/>
        </li>);
    return (
        <div className={'film-container'}>
            <div className={'film'}>
                <p className={'film__title'}> {name}
                </p>
                <input className={'film__input'} type={'datetime-local'} onChange={(e) => onSessionDateChanged(e)}/>
                <button className={'film__button'} onClick={() => createSession()}>Создать сеанс</button>
            </div>
            <ul className={'sessions'}>
                {sessionsComponents}
            </ul>
        </div>
    )

}
