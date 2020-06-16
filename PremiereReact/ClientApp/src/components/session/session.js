import React from 'react';
import "./index.css";
export default function Session({startTime, onDelete}) {
    const date = new Date(startTime);
    const days = date.getDate().toString().padStart(2, "0");
    const months = (date.getMonth()+1).toString().padStart(2, "0");
    return (
        <div>
            <p>Время начала</p>
            <p>{`${days}.${months} ${date.getHours()}:${date.getMinutes()}`}</p>
            <button onClick={() => onDelete()}>Удалить</button>
        </div>
    )
}
