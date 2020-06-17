import React from 'react';
import "./index.css";
export default function Session({startTime, onDelete}) {
    const date = new Date(startTime);
    const days = date.getDate().toString().padStart(2, "0");
    const months = (date.getMonth()+1).toString().padStart(2, "0");
    return (
        <li className={"session__item"}>
            <p className={"session__start-time"}>{`${days}.${months} ${date.getHours()}:${date.getMinutes()}`}</p>
            <button className={"session__remove"} onClick={() => onDelete()}>Удалить</button>
        </li>
    )
}
