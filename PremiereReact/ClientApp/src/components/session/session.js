import React from 'react';
import "./index.css";
export default function Session({sessionId, startTime, onDelete}) {
    return (
        <div>
            <p>Время начала</p>
            <p>{startTime}</p>
            <button onClick={() => onDelete(sessionId)}>Удалить</button>
        </div>
    )
}
