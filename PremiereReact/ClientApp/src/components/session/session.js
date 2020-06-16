import React from 'react';
import "./index.css";
export default function Session({startTime, onDelete}) {
    return (
        <div>
            <p>Время начала</p>
            <p>{startTime}</p>
            <button onClick={() => onDelete()}>Удалить</button>
        </div>
    )
}
